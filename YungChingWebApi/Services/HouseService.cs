using WebApi.Resources;
using YungChingWebApi.Models.Views;
using YungChingWebApi.Repositories.Interfaces;
using YungChingWebApi.Resources.Exceptions;
using YungChingWebApi.Resources.Extensions;
using YungChingWebApi.Services.Interfaces;

namespace YungChingWebApi.Services
{
    /// <summary>
    /// 房屋業務邏輯層實作
    /// </summary>
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;

        /// <summary>
        /// 建構函式
        /// </summary>
        /// <param name="houseRepository">房屋資料存取介面</param>
        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        /// <summary>
        /// 依條件取得房屋列表
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="price">價格</param>
        /// <param name="pageNumber">頁碼</param>
        /// <param name="pageSize">每頁數量</param>
        /// <returns>符合條件的房屋列表</returns>
        public async Task<List<HouseView>> GetHouseListByParamAsync(
            string? address, 
            string? price, 
            int pageNumber = 1, 
            int pageSize = 10)
        {
            // 解析 price 參數
            decimal? maxPrice = null;

            if (!string.IsNullOrWhiteSpace(price) && decimal.TryParse(price, out var parsedPrice))
            {
                maxPrice = parsedPrice;
            }

            // 從 Repository 取得資料
            var houseViewModels = await _houseRepository.GetHousesByConditionAsync(
                address, 
                maxPrice, 
                pageNumber, 
                pageSize);

            // 轉換為 View
            var houseViews = houseViewModels.Select(vm => new HouseView
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
                Area = vm.Area,
                TotalPrice = vm.TotalPrice,
                BuildingTypeName = BuildingTypeExtensions.GetDisplayName(vm.BuildingType)
            }).ToList();

            return houseViews;
        }

        /// <summary>
        /// 取得熱門房屋列表
        /// </summary>
        /// <returns>熱門房屋列表</returns>
        public async Task<List<HouseView>> GetHotHouseListAsync()
        {
            // 從 Repository 取得 Top 5 熱門房屋
            var houseViewModels = await _houseRepository.GetHotHousesAsync();

            // 轉換為 View
            var houseViews = houseViewModels.Select(vm => new HouseView
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
                Area = vm.Area,
                TotalPrice = vm.TotalPrice,
                BuildingTypeName = BuildingTypeExtensions.GetDisplayName(vm.BuildingType)
            }).ToList();

            return houseViews;
        }

        /// <summary>
        /// 依 ID 取得房屋詳細資料
        /// </summary>
        /// <param name="id">房屋 ID</param>
        /// <returns>房屋詳細資料</returns>
        /// <exception cref="HttpException">若找不到對應房屋，則擲回 404 錯誤</exception>
        public async Task<HouseDetailView> GetHouseByIdAsync(Guid id)
        {
            // 從 Repository 取得詳細資料
            var houseDetailViewModel = await _houseRepository.GetHouseByIdAsync(id);

            if (houseDetailViewModel == null)
            {
                throw new HttpException(404, ResponseMessage.HouseNotFound, ResponseMessage.HouseNotFoundCode);
            }

            // 增加查詢次數
            await _houseRepository.IncrementViewCountAsync(id);

            // 轉換為 View
            var houseDetailView = new HouseDetailView
            {
                Name = houseDetailViewModel.Name,
                Address = houseDetailViewModel.Address,
                Area = houseDetailViewModel.Area,
                TotalPrice = houseDetailViewModel.TotalPrice,
                Floor = houseDetailViewModel.Floor,
                Layout = houseDetailViewModel.Layout,
                BuildingTypeName = BuildingTypeExtensions.GetDisplayName(houseDetailViewModel.BuildingType),
                UnitPrice = houseDetailViewModel.UnitPrice,
                EmployeeName = houseDetailViewModel.EmployeeName,
                EmployeePhone = houseDetailViewModel.EmployeePhone,
                EmployeeAddress = houseDetailViewModel.EmployeeAddress
            };

            return houseDetailView;
        }

        /// <summary>
        /// 刪除所有房屋資料（僅限測試使用）
        /// </summary>
        public async Task DeleteDataAsync()
        {
            await _houseRepository.DeleteDataAsync();
        }

        /// <summary>
        /// 建立測試用房屋資料（僅限測試使用）
        /// </summary>
        public async Task CreateDataAsync()
        {
            await _houseRepository.CreateDataAsync();
        }
    }
}
