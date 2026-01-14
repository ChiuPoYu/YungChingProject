using YungChingWebApi.Models.ViewModels;

namespace YungChingWebApi.Repositories.Interfaces
{
    /// <summary>
    /// 房屋資料存取介面
    /// </summary>
    public interface IHouseRepository
    {
        /// <summary>
        /// 根據條件取得房屋列表（分頁）
        /// </summary>
        /// <param name="address">地址（模糊搜尋）</param>
        /// <param name="maxPrice">總價上限</param>
        /// <param name="pageNumber">頁碼</param>
        /// <param name="pageSize">每頁筆數</param>
        /// <returns>房屋視圖模型集合</returns>
        Task<IEnumerable<HouseViewModel>> GetHousesByConditionAsync(
            string? address, 
            decimal? maxPrice, 
            int pageNumber, 
            int pageSize);

        /// <summary>
        /// 取得熱門房屋列表（按查詢次數排序）
        /// </summary>
        /// <param name="topCount">取得筆數</param>
        /// <returns>熱門房屋視圖模型集合</returns>
        Task<IEnumerable<HouseViewModel>> GetHotHousesAsync(int topCount = 5);

        /// <summary>
        /// 根據ID取得房屋詳細資訊
        /// </summary>
        /// <param name="id">房屋編號</param>
        /// <returns>房屋詳細視圖模型，若不存在則返回 null</returns>
        Task<HouseDetailViewModel?> GetHouseByIdAsync(Guid id);

        /// <summary>
        /// 增加房屋查詢次數
        /// </summary>
        /// <param name="id">房屋編號</param>
        Task IncrementViewCountAsync(Guid id);

        /// <summary>
        /// 軟刪除所有假資料
        /// </summary>
        Task DeleteDataAsync();

        /// <summary>
        /// 建立測試用假資料
        /// </summary>
        Task CreateDataAsync();
    }
}
