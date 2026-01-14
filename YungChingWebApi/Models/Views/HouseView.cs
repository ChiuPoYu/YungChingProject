namespace YungChingWebApi.Models.Views
{
    public class HouseView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public decimal TotalPrice { get; set; }
        public string BuildingTypeName { get; set; }
    }
}
