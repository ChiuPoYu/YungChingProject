using YungChingWebApi.Models.Enums;

namespace YungChingWebApi.Resources.Extensions
{
    /// <summary>
    /// 建物型態擴充方法類別
    /// </summary>
    public static class BuildingTypeExtensions
    {
        /// <summary>
        /// 取得建物型態的顯示名稱
        /// </summary>
        /// <param name="buildingType">建物型態列舉</param>
        /// <returns>建物型態的中文名稱</returns>
        public static string GetDisplayName(this BuildingType buildingType)
        {
            return buildingType switch
            {
                BuildingType.Apartment => "公寓",
                BuildingType.Building => "大樓",
                BuildingType.Townhouse => "透天",
                _ => "未知"
            };
        }

        /// <summary>
        /// 根據建物型態代碼取得顯示名稱
        /// </summary>
        /// <param name="buildingTypeValue">建物型態數值代碼</param>
        /// <returns>建物型態的中文名稱</returns>
        public static string GetDisplayName(short buildingTypeValue)
        {
            if (Enum.IsDefined(typeof(BuildingType), buildingTypeValue))
            {
                return ((BuildingType)buildingTypeValue).GetDisplayName();
            }
            return "未知";
        }
    }
}
