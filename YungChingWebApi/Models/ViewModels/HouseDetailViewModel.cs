namespace YungChingWebApi.Models.ViewModels
{
    public class HouseDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public decimal TotalPrice { get; set; }
        public string Floor { get; set; }
        public string Layout { get; set; }
        public short BuildingType { get; set; }
        public decimal UnitPrice { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeAddress { get; set; }
    }
}
