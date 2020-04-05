using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bill.CacheIntegration
{
   public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举类型的Description说明
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            var type = value.GetType();
            var info = type.GetField(value.ToString());
            var attrs = info.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs.Length < 1)
                return string.Empty;

            return attrs[0] is DescriptionAttribute
                descriptionAttribute
                ? descriptionAttribute.Description
                : value.ToString();
        }
    }
}
