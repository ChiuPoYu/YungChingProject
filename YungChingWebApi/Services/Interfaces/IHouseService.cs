using WebApi.Models.ResponseModel;
using YungChingWebApi.Models.Views;

namespace YungChingWebApi.Services.Interfaces
{
    /// <summary>
    /// 房屋業務邏輯介面
    /// </summary>
    public interface IHouseService
    {
        /// <summary>
        /// 根據條件取得房屋列表
        /// </summary>
        /// <param name="address">地址（模糊搜尋）</param>
        /// <param name="price">總價上限（字串格式）</param>
        /// <param name="pageNumber">頁碼（預設1）</param>
        /// <param name="pageSize">每頁筆數（預設10）</param>
        /// <returns>房屋視圖列表</returns>
        Task<List<HouseView>> GetHouseListByParamAsync(
            string? address, 
            string? price, 
            int pageNumber = 1, 
            int pageSize = 10);

        /// <summary>
        /// 取得熱門房屋列表（Top 5）
        /// </summary>
        /// <returns>熱門房屋視圖列表</returns>
        Task<List<HouseView>> GetHotHouseListAsync();

        /// <summary>
        /// 根據ID取得房屋詳細資訊
        /// </summary>
        /// <param name="id">房屋編號</param>
        /// <returns>房屋詳細視圖</returns>
        Task<HouseDetailView> GetHouseByIdAsync(Guid id);

        /// <summary>
        /// 軟刪除所有測試資料
        /// </summary>
        Task DeleteDataAsync();

        /// <summary>
        /// 建立測試用假資料（員工與房屋）
        /// </summary>
        Task CreateDataAsync();
    }
}
