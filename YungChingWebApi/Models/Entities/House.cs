namespace YungChingWebApi.Models.Entities
{
    public class House : BaseEntityConfig
    {
        /// <summary>
        /// 物件名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 坪數
        /// </summary>
        public decimal Area { get; set; }

        /// <summary>
        /// 樓層
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// 格局 (例如: 3房2廳2衛)
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// 單價(每坪)
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 總價
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 建物型態 (BuildingType)
        /// </summary>
        public short BuildingType { get; set; }

        /// <summary>
        /// 負責業務 ID
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// 負責業務
        /// </summary>
        public Employee Employee { get; set; }
    }
}
