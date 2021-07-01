using CarSales.Domain.Enums;

namespace CarSales.Application.Helpers
{
    public static class OfferHelpers
    {
        public static string GetEngineType(this EngineTypes type)
        {
            switch (type)
            {
                case EngineTypes.Fuel:
                    return "Бензин";
                case EngineTypes.Gas:
                    return "Газ";
                case EngineTypes.Battery:
                    return "Батарея";
                default:
                    return "";
            }
        }

        public static string GetTransmission(this TransmissionTypes type)
        {
            switch (type)
            {
                case TransmissionTypes.ManualTransmission:
                    return "Механічна";
                case TransmissionTypes.AutomaticTransmission:
                    return "Автоматична";
                default:
                    return "";
            }
        }

        public static string GetDrive(this DriveTypes type)
        {
            switch (type)
            {
                case DriveTypes.FrontWheelDrive:
                    return "Передній";
                case DriveTypes.RearWheelDrive:
                    return "Задній";
                case DriveTypes.AllWheelDrive:
                    return "Повний";
                default:
                    return "";
            }
        }
    }
}