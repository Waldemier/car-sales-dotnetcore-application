namespace CarSales.Application.DataTrasferObjects
{
    public class ReviewDto: BaseDto
    {
        public UserDto User { get; set; }
        
        public string Comment { get; set; }
    }
}