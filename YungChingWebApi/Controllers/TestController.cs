using Microsoft.AspNetCore.Mvc;
using WebApi.Models.ResponseModel;
using YungChingWebApi.Models.Views;
using YungChingWebApi.Services.Interfaces;

namespace YungChingWebApi.Controllers
{
    /// <summary>
    /// 測試用，建立假資料
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public TestController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        /// <summary>
        /// 假資料建立 (先員工再房屋)
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateData")]
        public async Task<ResultResponse> CreateData()
        {
            await _houseService.CreateDataAsync();
            return new ResultResponse(true, "假資料建立成功");
        }

        /// <summary>
        /// 假資料清除 (軟刪除所有員工和房屋)
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteData")]
        public async Task<ResultResponse> DeleteData()
        {
            await _houseService.DeleteDataAsync();
            return new ResultResponse(true, "假資料已軟刪除");
        }
    }
}
