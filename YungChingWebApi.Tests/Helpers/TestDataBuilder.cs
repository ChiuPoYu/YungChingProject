using YungChingWebApi.Models.Entities;
using YungChingWebApi.Models.Enums;
using YungChingWebApi.Models.ViewModels;
using YungChingWebApi.Models.Views;

namespace YungChingWebApi.Tests.Helpers
{
    /// <summary>
    /// 測試資料建構器，用於快速建立測試資料
    /// </summary>
    public static class TestDataBuilder
    {
        /// <summary>
        /// 建立測試用的 House 實體
        /// </summary>
        public static House CreateHouse(
            Guid? id = null,
            string? name = null,
            string? address = null,
            decimal totalPrice = 50000000,
            decimal area = 30)
        {
            return new House
            {
                Id = id ?? Guid.NewGuid(),
                Name = name ?? "測試房屋",
                Address = address ?? "台北市測試地址",
                TotalPrice = totalPrice,
                Area = area,
                Floor = "5樓/10樓",
                Layout = "3房2廳2衛",
                BuildingType = (short)BuildingType.Apartment,
                UnitPrice = totalPrice / area,
                ViewCount = 0,
                EmployeeId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        /// <summary>
        /// 建立測試用的 HouseView
        /// </summary>
        public static HouseView CreateHouseView(
            Guid? id = null,
            string? name = null,
            string? address = null,
            decimal totalPrice = 50000000,
            decimal area = 30)
        {
            return new HouseView
            {
                Id = id ?? Guid.NewGuid(),
                Name = name ?? "測試房屋",
                Address = address ?? "台北市測試地址",
                TotalPrice = totalPrice,
                Area = area,
                BuildingTypeName = "電梯大樓"
            };
        }

        /// <summary>
        /// 建立測試用的 HouseViewModel
        /// </summary>
        public static HouseViewModel CreateHouseViewModel(
            Guid? id = null,
            string? name = null,
            string? address = null,
            decimal totalPrice = 50000000,
            decimal area = 30)
        {
            return new HouseViewModel
            {
                Id = id ?? Guid.NewGuid(),
                Name = name ?? "測試房屋",
                Address = address ?? "台北市測試地址",
                TotalPrice = totalPrice,
                Area = area,
                BuildingType = (short)BuildingType.Apartment
            };
        }

        /// <summary>
        /// 建立測試用的 HouseDetailView
        /// </summary>
        public static HouseDetailView CreateHouseDetailView(
            string? name = null,
            string? address = null,
            decimal totalPrice = 50000000,
            decimal area = 30)
        {
            return new HouseDetailView
            {
                Name = name ?? "測試房屋",
                Address = address ?? "台北市測試地址",
                TotalPrice = totalPrice,
                Area = area,
                Floor = "5樓/10樓",
                Layout = "3房2廳2衛",
                BuildingTypeName = "電梯大樓",
                UnitPrice = totalPrice / area,
                EmployeeName = "張經理",
                EmployeePhone = "0912345678",
                EmployeeAddress = "台北市"
            };
        }

        /// <summary>
        /// 建立測試用的 HouseDetailViewModel
        /// </summary>
        public static HouseDetailViewModel CreateHouseDetailViewModel(
            Guid? id = null,
            string? name = null,
            string? address = null,
            decimal totalPrice = 50000000,
            decimal area = 30)
        {
            return new HouseDetailViewModel
            {
                Id = id ?? Guid.NewGuid(),
                Name = name ?? "測試房屋",
                Address = address ?? "台北市測試地址",
                TotalPrice = totalPrice,
                Area = area,
                Floor = "5樓/10樓",
                Layout = "3房2廳2衛",
                BuildingType = (short)BuildingType.Apartment,
                UnitPrice = totalPrice / area,
                EmployeeName = "張經理",
                EmployeePhone = "0912345678",
                EmployeeAddress = "台北市"
            };
        }

        /// <summary>
        /// 建立多筆測試用的 House 列表
        /// </summary>
        public static List<House> CreateHouseList(int count = 5)
        {
            var houses = new List<House>();
            for (int i = 0; i < count; i++)
            {
                houses.Add(CreateHouse(
                    name: $"測試房屋{i + 1}",
                    address: $"台北市測試地址{i + 1}",
                    totalPrice: 50000000 + (i * 10000000),
                    area: 30 + (i * 5)
                ));
            }
            return houses;
        }

        /// <summary>
        /// 建立多筆測試用的 HouseView 列表
        /// </summary>
        public static List<HouseView> CreateHouseViewList(int count = 5)
        {
            var houseViews = new List<HouseView>();
            for (int i = 0; i < count; i++)
            {
                houseViews.Add(CreateHouseView(
                    name: $"測試房屋{i + 1}",
                    address: $"台北市測試地址{i + 1}",
                    totalPrice: 50000000 + (i * 10000000),
                    area: 30 + (i * 5)
                ));
            }
            return houseViews;
        }

        /// <summary>
        /// 建立多筆測試用的 HouseViewModel 列表
        /// </summary>
        public static List<HouseViewModel> CreateHouseViewModelList(int count = 5)
        {
            var viewModels = new List<HouseViewModel>();
            for (int i = 0; i < count; i++)
            {
                viewModels.Add(CreateHouseViewModel(
                    name: $"測試房屋{i + 1}",
                    address: $"台北市測試地址{i + 1}",
                    totalPrice: 50000000 + (i * 10000000),
                    area: 30 + (i * 5)
                ));
            }
            return viewModels;
        }
    }
}
