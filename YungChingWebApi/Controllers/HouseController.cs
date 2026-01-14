using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ResponseModel;
using YungChingWebApi.Models.Views;
using YungChingWebApi.Services.Interfaces;

namespace YungChingWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        /// <summary>
        /// 根據條件取得房屋屋件
        /// </summary>
        /// <param name="address">地址（模糊搜尋）</param>
        /// <param name="price">總價上限</param>
        /// <param name="pageNumber">頁碼（預設1）</param>
        /// <param name="pageSize">每頁筆數（預設10）</param>
        /// <returns></returns>
        [HttpGet("GetHouseListByParam")]
        public async Task<ListResponse<HouseView>> GetHouseListByParam(
            string? address, 
            string? price,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var result =  await _houseService.GetHouseListByParamAsync(address, price, pageNumber, pageSize);

            return new ListResponse<HouseView>(result);
        }

        /// <summary>
        /// 取得熱門房屋列表 (查詢次數 Top 5)
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetHotHouse")]
        public async Task<ListResponse<HouseView>> GetHotHouseList()
        {
            var result = await _houseService.GetHotHouseListAsync();
            return new ListResponse<HouseView>(result);
        }

        /// <summary>
        /// 根據ID取得房屋詳細資訊
        /// </summary>
        /// <param name="Id">房屋ID</param>
        /// <returns></returns>
        [HttpGet("GetHouse/{Id}")]
        public async Task<DataResponse<HouseDetailView>> GetHouseById(Guid Id)
        {
            var result = await _houseService.GetHouseByIdAsync(Id);
            return new DataResponse<HouseDetailView>(result);
        }
    }
}
