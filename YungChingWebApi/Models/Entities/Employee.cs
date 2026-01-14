namespace YungChingWebApi.Models.Entities
{
    public class Employee : BaseEntityConfig
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 連絡電話
        /// </summary>
        public string Phone { get; set;}

        /// <summary>
        /// 分機
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// 門市地址 (可以擴充門市資料)
        /// </summary>
        public string Address { get; set; }
    }
}
