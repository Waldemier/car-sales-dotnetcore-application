namespace CarSales.Application.DataTrasferObjects
{
    public class ImageDto: BaseDto
    {
        public OfferDto Offer { get; set; }
        
        public byte[] OfferImage { get; set; }
    }
}