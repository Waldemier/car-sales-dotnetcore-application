using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.Json;
using CarSales.Domain.Common;

namespace CarSales.Application.Helpers
{
    public static class CurrencyExchange
    {
        /// <summary>
        /// Method which converting from USD to UAH and EUR currency.
        /// </summary>
        /// <param name="usdCurrency"></param>
        /// <returns>ConvertedCurrencyModel object which represents UAH and EUR properties in CultureInfo format.</returns>
        public static ConvertedCurrencyModel ConvertCurrency(this double usdCurrency)
        {
            /*
                Example what we get from private bank api :
                [{"ccy":"USD","base_ccy":"UAH","buy":"27.00000","sale":"27.40000"},{"ccy":"EUR","base_ccy":"UAH","buy":"32.00000","sale":"32.60000"},{"ccy":"RUR","base_ccy":"UAH","buy":"0.35500","sale":"0.38500"},{"ccy":"BTC","base_ccy":"USD","buy":"33158.9150","sale":"36649.3272"}]
             */
            using var client = new WebClient();
            var jsonData = client.DownloadString("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
            
            // deserializing an a json array objects to List<ExchangeModel> objects. After deserialization we get only those which have USD and EUR.
            var deserializeJsonData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExchangeModel>>(jsonData)
                .Where(model => model.ccy == "USD" || model.ccy == "EUR").ToList();
            
            // currency manipulations
            var forSaleUSD = deserializeJsonData.SingleOrDefault(x => x.ccy == "USD")?.sale;
            var forBuyEUR = deserializeJsonData.SingleOrDefault(x => x.ccy == "EUR")?.buy;

            if (!forSaleUSD.HasValue || !forBuyEUR.HasValue)
            {
                throw new ArgumentNullException();
            }
            
            var convertedToUAH = (decimal) usdCurrency * forSaleUSD.Value;
            var convertedToEUR = (decimal) usdCurrency * forSaleUSD.Value / forBuyEUR.Value;
            
            return new ConvertedCurrencyModel
            {
                UAH = convertedToUAH.ToString("C0", new CultureInfo("uk-UA")),
                EUR = convertedToEUR.ToString("C0", new CultureInfo("fr-FR"))
            };
        }
    }
}