using Microsoft.EntityFrameworkCore;
using YungChingWebApi.Data;
using YungChingWebApi.Models.Entities;
using YungChingWebApi.Models.Enums;
using YungChingWebApi.Models.ViewModels;
using YungChingWebApi.Repositories.Interfaces;

namespace YungChingWebApi.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly SqlDbContext _context;

        public HouseRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HouseViewModel>> GetHousesByConditionAsync(
            string? address, 
            decimal? maxPrice, 
            int pageNumber, 
            int pageSize)
        {
            var query = _context.Houses.AsQueryable();

            // 地址模糊搜尋
            if (!string.IsNullOrWhiteSpace(address))
            {
                query = query.Where(h => h.Address.Contains(address));
            }

            // 總價篩選
            if (maxPrice.HasValue)
            {
                query = query.Where(h => h.TotalPrice <= maxPrice.Value);
            }

            // 預設按總價排序
            query = query.OrderBy(h => h.TotalPrice);

            // 取得總筆數
            var totalCount = await query.CountAsync();

            // 分頁
            var houses = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(h => new HouseViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Address = h.Address,
                    Area = h.Area,
                    TotalPrice = h.TotalPrice,
                    BuildingType = h.BuildingType
                })
                .ToListAsync();

            return houses;
        }

        public async Task<IEnumerable<HouseViewModel>> GetHotHousesAsync(int topCount = 5)
        {
            return await _context.Houses
                .OrderByDescending(h => h.ViewCount)
                .Take(topCount)
                .Select(h => new HouseViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Address = h.Address,
                    Area = h.Area,
                    TotalPrice = h.TotalPrice,
                    BuildingType = h.BuildingType
                })
                .ToListAsync();
        }

        public async Task<HouseDetailViewModel?> GetHouseByIdAsync(Guid id)
        {
            return await _context.Houses
                .Include(h => h.Employee)
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Address = h.Address,
                    Area = h.Area,
                    TotalPrice = h.TotalPrice,
                    Floor = h.Floor,
                    Layout = h.Layout,
                    BuildingType = h.BuildingType,
                    UnitPrice = h.UnitPrice,
                    EmployeeName = h.Employee.Name,
                    EmployeePhone = h.Employee.Phone,
                    EmployeeAddress = h.Employee.Address
                })
                .FirstOrDefaultAsync();
        }

        public async Task IncrementViewCountAsync(Guid id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house != null)
            {
                house.ViewCount++;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDataAsync()
        {
            var now = DateTime.Now;

            // 軟刪除所有房屋資料
            var houses = await _context.Houses.ToListAsync();
            foreach (var house in houses)
            {
                house.DeletedAt = now;
            }

            // 軟刪除所有員工資料
            var employees = await _context.Employees.ToListAsync();
            foreach (var employee in employees)
            {
                employee.DeletedAt = now;
            }

            await _context.SaveChangesAsync();
        }

        public async Task CreateDataAsync()
        {
            var now = DateTime.Now;

            // 建立 5 筆員工假資料
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "王大明",
                    Phone = "02-2345-6789",
                    Ext = "101",
                    Address = "台北市中正區重慶南路一段100號",
                    CreatedAt = now,
                    UpdatedAt = now,
                    DeletedAt = DateTime.MaxValue
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "李小華",
                    Phone = "02-2345-6790",
                    Ext = "102",
                    Address = "台北市大安區忠孝東路四段50號",
                    CreatedAt = now,
                    UpdatedAt = now,
                    DeletedAt = DateTime.MaxValue
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "張美玲",
                    Phone = "02-2345-6791",
                    Ext = "103",
                    Address = "新北市板橋區中山路一段200號",
                    CreatedAt = now,
                    UpdatedAt = now,
                    DeletedAt = DateTime.MaxValue
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "陳志偉",
                    Phone = "02-2345-6792",
                    Ext = "104",
                    Address = "台北市信義區松仁路80號",
                    CreatedAt = now,
                    UpdatedAt = now,
                    DeletedAt = DateTime.MaxValue
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "林淑芬",
                    Phone = "02-2345-6793",
                    Ext = "105",
                    Address = "新北市新店區北新路三段150號",
                    CreatedAt = now,
                    UpdatedAt = now,
                    DeletedAt = DateTime.MaxValue
                }
            };

            await _context.Employees.AddRangeAsync(employees);
            await _context.SaveChangesAsync();

            // 建立 20 筆房屋假資料
            var random = new Random();
            var houses = new List<House>();
            
            var houseNames = new[]
            {
                "陽光美墅", "都會精品", "溫馨小窩", "豪景大廈", "幸福家園",
                "綠意莊園", "城市花園", "靜巷雅居", "景觀豪宅", "文山美居",
                "青田別墅", "永康華廈", "信義之星", "南港新城", "內湖雅築",
                "士林庭園", "北投溫泉宅", "木柵書香居", "萬華經典", "中和好宅"
            };

            var addresses = new[]
            {
                "台北市大安區敦化南路一段", "台北市信義區松仁路", "台北市中山區中山北路二段",
                "台北市松山區南京東路四段", "台北市內湖區成功路三段", "新北市板橋區文化路一段",
                "新北市新店區中正路", "新北市中和區中山路二段", "新北市永和區永和路",
                "新北市三重區重新路五段", "台北市文山區羅斯福路五段", "台北市北投區中央北路",
                "台北市士林區中山北路六段", "台北市萬華區西園路一段", "台北市南港區南港路",
                "新北市汐止區新台五路一段", "新北市淡水區中正東路", "新北市樹林區中正路",
                "新北市土城區中央路四段", "新北市蘆洲區中正路"
            };

            var layouts = new[] { "2房1廳1衛", "3房2廳2衛", "4房2廳2衛", "5房3廳3衛", "1房1廳1衛" };
            var floors = new[] { "3F/5F", "5F/12F", "8F/15F", "12F/20F", "1F/1F", "整棟" };
            var buildingTypes = new[] { BuildingType.Apartment, BuildingType.Building, BuildingType.Townhouse };

            for (int i = 0; i < 20; i++)
            {
                var employee = employees[i % 5]; // 平均分配給5位員工
                var area = random.Next(15, 60); // 15-60坪
                var unitPrice = random.Next(30, 80) * 10000; // 30-80萬/坪
                var totalPrice = area * unitPrice;

                houses.Add(new House
                {
                    Id = Guid.NewGuid(),
                    Name = houseNames[i],
                    Address = $"{addresses[i]}{random.Next(1, 300)}號",
                    Area = area,
                    Floor = floors[random.Next(floors.Length)],
                    Layout = layouts[random.Next(layouts.Length)],
                    UnitPrice = unitPrice,
                    TotalPrice = totalPrice,
                    BuildingType = (short)buildingTypes[random.Next(buildingTypes.Length)],
                    EmployeeId = employee.Id,
                    ViewCount = random.Next(0, 100),
                    CreatedAt = now,
                    UpdatedAt = now,
                    DeletedAt = DateTime.MaxValue
                });
            }

            await _context.Houses.AddRangeAsync(houses);
            await _context.SaveChangesAsync();
        }
    }
}
