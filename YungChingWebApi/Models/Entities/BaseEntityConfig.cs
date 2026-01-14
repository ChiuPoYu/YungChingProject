namespace YungChingWebApi.Models.Entities
{
    public class BaseEntityConfig
    {
        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id { get; set; } = new Guid();

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// 刪除日期
        /// </summary>
        public DateTime DeletedAt { get; set; } = DateTime.Now;
    }
}
