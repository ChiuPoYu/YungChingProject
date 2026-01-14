namespace YungChingWebApi.Models.ViewModels
{
    /// <summary>
    /// 房屋詳細資訊資料庫視圖模型（用於 Repository 層）
    /// </summary>
    public class HouseDetailViewModel
    {
        /// <summary>
        /// 房屋編號
        /// </summary>
        public Guid Id { get; set; }
        
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
        /// 總價
        /// </summary>
        public decimal TotalPrice { get; set; }
        
        /// <summary>
        /// 樓層
        /// </summary>
        public string Floor { get; set; }
        
        /// <summary>
        /// 格局 (例如: 3房2廳2衛)
        /// </summary>
        public string Layout { get; set; }
        
        /// <summary>
        /// 建物型態代碼
        /// </summary>
        public short BuildingType { get; set; }
        
        /// <summary>
        /// 單價(每坪)
        /// </summary>
        public decimal UnitPrice { get; set; }
        
        /// <summary>
        /// 負責業務姓名
        /// </summary>
        public string EmployeeName { get; set; }
        
        /// <summary>
        /// 負責業務電話
        /// </summary>
        public string EmployeePhone { get; set; }
        
        /// <summary>
        /// 負責業務門市地址
        /// </summary>
        public string EmployeeAddress { get; set; }
    }
}
