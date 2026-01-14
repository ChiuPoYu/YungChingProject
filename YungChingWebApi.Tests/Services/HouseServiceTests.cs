using FluentAssertions;
using Moq;
using YungChingWebApi.Models.Enums;
using YungChingWebApi.Models.ViewModels;
using YungChingWebApi.Repositories.Interfaces;
using YungChingWebApi.Services;

namespace YungChingWebApi.Tests.Services
{
    /// <summary>
    /// HouseService 測試
    /// </summary>
    public class HouseServiceTests
    {
        private readonly Mock<IHouseRepository> _mockHouseRepository;
        private readonly HouseService _service;

        public HouseServiceTests()
        {
            _mockHouseRepository = new Mock<IHouseRepository>();
            _service = new HouseService(_mockHouseRepository.Object);
        }

        [Fact]
        public async Task GetHouseListByParamAsync_ShouldSendCorrectParamToRepository()
        {
            // Arrange
            string address = "台北市";
            string price = "50000000";
            int pageNumber = 1;
            int pageSize = 10;

            var expectedResult = new List<HouseViewModel>
            {
                new HouseViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "測試房屋",
                    Address = "台北市信義區",
                    Area = 30,
                    TotalPrice = 50000000,
                    BuildingType = (short)BuildingType.Apartment
                }
            };

            _mockHouseRepository
                .Setup(r => r.GetHousesByConditionAsync(address, 50000000m, pageNumber, pageSize))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _service.GetHouseListByParamAsync(address, price, pageNumber, pageSize);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Name.Should().Be("測試房屋");
            _mockHouseRepository.Verify(
                r => r.GetHousesByConditionAsync(address, 50000000m, pageNumber, pageSize),
                Times.Once);
        }

        [Fact]
        public async Task GetHotHouseListAsync_ShouldCallRepository()
        {
            // Arrange
            var expectedHotHouses = new List<HouseViewModel>
            {
                new HouseViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "熱門房屋1",
                    Address = "台北市",
                    Area = 30,
                    TotalPrice = 50000000,
                    BuildingType = (short)BuildingType.Apartment
                },
                new HouseViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "熱門房屋2",
                    Address = "台中市",
                    Area = 35,
                    TotalPrice = 60000000,
                    BuildingType = (short)BuildingType.Apartment
                }
            };

            _mockHouseRepository
                .Setup(r => r.GetHotHousesAsync(5))
                .ReturnsAsync(expectedHotHouses);

            // Act
            var result = await _service.GetHotHouseListAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            _mockHouseRepository.Verify(r => r.GetHotHousesAsync(5), Times.Once);
        }

        [Fact]
        public async Task GetHouseByIdAsync_ShouldReturnCorrectHouse()
        {
            // Arrange
            var houseId = Guid.NewGuid();
            var expectedHouse = new HouseDetailViewModel
            {
                Id = houseId,
                Name = "測試房屋",
                Address = "測試地址",
                Area = 30,
                TotalPrice = 50000000,
                Floor = "5樓/10樓",
                Layout = "3房2廳2衛",
                BuildingType = (short)BuildingType.Apartment,
                UnitPrice = 1666667,
                EmployeeName = "張經理",
                EmployeePhone = "0912345678",
                EmployeeAddress = "台北市"
            };

            _mockHouseRepository
                .Setup(r => r.GetHouseByIdAsync(houseId))
                .ReturnsAsync(expectedHouse);

            _mockHouseRepository
                .Setup(r => r.IncrementViewCountAsync(houseId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.GetHouseByIdAsync(houseId);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("測試房屋");
            result.Address.Should().Be("測試地址");
            _mockHouseRepository.Verify(r => r.GetHouseByIdAsync(houseId), Times.Once);
            _mockHouseRepository.Verify(r => r.IncrementViewCountAsync(houseId), Times.Once);
        }
    }
}
