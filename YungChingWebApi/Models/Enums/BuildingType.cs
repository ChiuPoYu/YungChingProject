using System.ComponentModel;

namespace YungChingWebApi.Models.Enums
{
    public enum BuildingType : short
    {
        /// <summary>
        /// 公寓
        /// </summary>
        [Description("公寓")]
        Apartment = 1,

        /// <summary>
        /// 大樓
        /// </summary>
        [Description("大樓")]
        Building = 2,

        /// <summary>
        /// 透天
        /// </summary>
        [Description("透天")]
        Townhouse = 3
    }
}
