using Microsoft.EntityFrameworkCore;
using YungChingWebApi.Data;
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
    }
}
