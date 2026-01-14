using WebApi.Models.ResponseModel;
using YungChingWebApi.Models.Views;

namespace YungChingWebApi.Services.Interfaces
{
    public interface IHouseService
    {
        /// <summary>
        /// 根據條件取得房屋列表
        /// </summary>
        Task<List<HouseView>> GetHouseListByParamAsync(
            string? address, 
            string? price, 
            int pageNumber = 1, 
            int pageSize = 10);

        /// <summary>
        /// 取得熱門房屋列表（Top 5）
        /// </summary>
        Task<List<HouseView>> GetHotHouseListAsync();

        /// <summary>
        /// 根據ID取得房屋詳細資訊
        /// </summary>
        Task<HouseDetailView> GetHouseByIdAsync(Guid id);
    }
}
