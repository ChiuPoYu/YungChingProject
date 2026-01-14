namespace YungChingWebApi.Models.Views
{
    /// <summary>
    /// 房屋列表視圖模型
    /// </summary>
    public class HouseView
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
        /// 建物型態名稱
        /// </summary>
        public string BuildingTypeName { get; set; }
    }
}
