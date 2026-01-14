using YungChingWebApi.Models.ViewModels;

namespace YungChingWebApi.Repositories.Interfaces
{
    public interface IHouseRepository
    {
        /// <summary>
        /// 根據條件取得房屋列表（分頁）
        /// </summary>
        Task<IEnumerable<HouseViewModel>> GetHousesByConditionAsync(
            string? address, 
            decimal? maxPrice, 
            int pageNumber, 
            int pageSize);

        /// <summary>
        /// 取得熱門房屋列表（按查詢次數排序）
        /// </summary>
        Task<IEnumerable<HouseViewModel>> GetHotHousesAsync(int topCount = 5);

        /// <summary>
        /// 根據ID取得房屋詳細資訊
        /// </summary>
        Task<HouseDetailViewModel?> GetHouseByIdAsync(Guid id);

        /// <summary>
        /// 增加房屋查詢次數
        /// </summary>
        Task IncrementViewCountAsync(Guid id);

        /// <summary>
        /// 刪除假資料
        /// </summary>
        /// <returns></returns>
        Task DeleteDataAsync();

        /// <summary>
        /// 建立假資料
        /// </summary>
        /// <returns></returns>
        Task CreateDataAsync();
    }
}
