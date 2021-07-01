using System.Text.Json;

namespace CarSales.Domain.Common
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}