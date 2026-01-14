namespace YungChingWebApi.Models.ViewModels
{
    public class HouseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public decimal TotalPrice { get; set; }
        public short BuildingType { get; set; }
    }
}
