namespace WebApi1.Models
{
    public class DeliveryAddress
    {
        public long Id { get; set; }
        public string? City {  get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Flat {  get; set; }
        public string? Postcode {  get; set; }
        public bool IsDeleted { get; set; }=false;
    }
}
