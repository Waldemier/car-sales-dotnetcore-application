using System;
using CarSales.Application.Constants;

namespace CarSales.Application.Helpers
{
    public static class GeneralHelpers
    {
        public static string GetPhoneFormat(uint phoneNumber)
        {
            string formattedNumber = String.Format(GeneralConstants.PhoneFormat, phoneNumber);
            return formattedNumber;
        }
    }
}