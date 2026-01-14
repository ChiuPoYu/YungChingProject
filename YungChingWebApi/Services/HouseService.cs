using WebApi.Models.ResponseModel;
using YungChingWebApi.Extensions;
using YungChingWebApi.Models.Views;
using YungChingWebApi.Repositories.Interfaces;
using YungChingWebApi.Services.Interfaces;

namespace YungChingWebApi.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

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
                Name = vm.Name,
                Address = vm.Address,
                Area = vm.Area,
                TotalPrice = vm.TotalPrice,
                BuildingTypeName = BuildingTypeExtensions.GetDisplayName(vm.BuildingType)
            }).ToList();

            return houseViews;
        }

        public async Task<List<HouseView>> GetHotHouseListAsync()
        {
            // 從 Repository 取得 Top 5 熱門房屋
            var houseViewModels = await _houseRepository.GetHotHousesAsync(5);

            // 轉換為 View
            var houseViews = houseViewModels.Select(vm => new HouseView
            {
                Name = vm.Name,
                Address = vm.Address,
                Area = vm.Area,
                TotalPrice = vm.TotalPrice,
                BuildingTypeName = BuildingTypeExtensions.GetDisplayName(vm.BuildingType)
            }).ToList();

            return houseViews;
        }

        public async Task<HouseDetailView> GetHouseByIdAsync(Guid id)
        {
            // 從 Repository 取得詳細資料
            var houseDetailViewModel = await _houseRepository.GetHouseByIdAsync(id);

            if (houseDetailViewModel == null)
            {
                return null;
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
    }
}
