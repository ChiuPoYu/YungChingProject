using FluentAssertions;
using Moq;
using WebApi.Models.ResponseModel;
using YungChingWebApi.Controllers;
using YungChingWebApi.Models.Views;
using YungChingWebApi.Services.Interfaces;

namespace YungChingWebApi.Tests.Controllers
{
    /// <summary>
    /// HouseController 測試
    /// </summary>
    public class HouseControllerTests
    {
        private readonly Mock<IHouseService> _mockHouseService;
        private readonly HouseController _controller;

        public HouseControllerTests()
        {
            // 建立 Mock 物件
            _mockHouseService = new Mock<IHouseService>();
            _controller = new HouseController(_mockHouseService.Object);
        }

        #region GetHouseListByParam 測試

        [Fact]
        public async Task GetHouseListByParam_ShouldReutrnHouseList()
        {
            // Arrange
            var expectedHouses = new List<HouseView>
            {
                new HouseView
                {
                    Id = Guid.NewGuid(),
                    Name = "溫馨小宅",
                    Address = "台北市信義區",
                    TotalPrice = 50000000,
                    Area = 30,
                    BuildingTypeName = "電梯大樓"
                },
                new HouseView
                {
                    Id = Guid.NewGuid(),
                    Name = "豪華套房",
                    Address = "台北市大安區",
                    TotalPrice = 60000000,
                    Area = 35,
                    BuildingTypeName = "電梯大樓"
                }
            };

            _mockHouseService
                .Setup(s => s.GetHouseListByParamAsync(It.IsAny<string>(), It.IsAny<string>(), 1, 10))
                .ReturnsAsync(expectedHouses);

            // Act
            var result = await _controller.GetHouseListByParam("台北", "6000萬", 1, 10);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ListResponse<HouseView>>();
            result.Data.Should().HaveCount(2);
            result.Data.Should().BeEquivalentTo(expectedHouses);
            result.Status.Success.Should().BeTrue();
        }

        [Fact]
        public async Task GetHouseListByParam_ShouldReutrnEmptyHouseList()
        {
            // Arrange
            _mockHouseService
                .Setup(s => s.GetHouseListByParamAsync(It.IsAny<string>(), It.IsAny<string>(), 1, 10))
                .ReturnsAsync(new List<HouseView>());

            // Act
            var result = await _controller.GetHouseListByParam("不存在的地址", null, 1, 10);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().BeEmpty();
            result.Status.Success.Should().BeTrue();
        }

        #endregion

        #region GetHotHouseList 測試

        [Fact]
        public async Task GetHotHouseList_ShouldReturnTOP5House()
        {
            // Arrange
            var expectedHotHouses = new List<HouseView>
            {
                new HouseView { Id = Guid.NewGuid(), Name = "熱門物件1", Address = "熱門地區1", TotalPrice = 50000000, Area = 30, BuildingTypeName = "電梯大樓" },
                new HouseView { Id = Guid.NewGuid(), Name = "熱門物件2", Address = "熱門地區2", TotalPrice = 60000000, Area = 35, BuildingTypeName = "電梯大樓" },
                new HouseView { Id = Guid.NewGuid(), Name = "熱門物件3", Address = "熱門地區3", TotalPrice = 70000000, Area = 40, BuildingTypeName = "電梯大樓" },
                new HouseView { Id = Guid.NewGuid(), Name = "熱門物件4", Address = "熱門地區4", TotalPrice = 80000000, Area = 45, BuildingTypeName = "電梯大樓" },
                new HouseView { Id = Guid.NewGuid(), Name = "熱門物件5", Address = "熱門地區5", TotalPrice = 90000000, Area = 50, BuildingTypeName = "電梯大樓" }
            };

            _mockHouseService
                .Setup(s => s.GetHotHouseListAsync())
                .ReturnsAsync(expectedHotHouses);

            // Act
            var result = await _controller.GetHotHouseList();

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(5);
            result.Status.Success.Should().BeTrue();
            _mockHouseService.Verify(s => s.GetHotHouseListAsync(), Times.Once);
        }

        #endregion

        #region GetHouseById 測試

        [Fact]
        public async Task GetHouseById_ShouldReturnHouseById()
        {
            // Arrange
            var houseId = Guid.NewGuid();
            var expectedHouse = new HouseDetailView
            {
                Name = "溫馨小宅",
                Address = "台北市信義區信義路五段7號",
                TotalPrice = 80000000,
                Area = 40,
                Floor = "5樓/10樓",
                Layout = "3房2廳2衛",
                BuildingTypeName = "電梯大樓",
                UnitPrice = 2000000,
                EmployeeName = "張經理",
                EmployeePhone = "0912345678",
                EmployeeAddress = "台北市信義區"
            };

            _mockHouseService
                .Setup(s => s.GetHouseByIdAsync(houseId))
                .ReturnsAsync(expectedHouse);

            // Act
            var result = await _controller.GetHouseById(houseId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<DataResponse<HouseDetailView>>();
            result.Data.Should().NotBeNull();
            result.Data.Name.Should().Be("溫馨小宅");
            result.Data.Address.Should().Be("台北市信義區信義路五段7號");
            result.Status.Success.Should().BeTrue();
        }

        [Fact]
        public async Task GetHouseById_WhenHouseIsNotExist_ShouldThrowException()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();
            _mockHouseService
                .Setup(s => s.GetHouseByIdAsync(nonExistentId))
                .ThrowsAsync(new KeyNotFoundException("找不到指定的房屋"));

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _controller.GetHouseById(nonExistentId);
            });
        }

        #endregion
    }
}
