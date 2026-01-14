using YungChingWebApi.Models.Enums;

namespace YungChingWebApi.Resources.Extensions
{
    public static class BuildingTypeExtensions
    {
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
