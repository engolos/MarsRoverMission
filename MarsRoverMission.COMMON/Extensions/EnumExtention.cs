namespace MarsRoverMission.COMMON.Extensions
{
    using System;

    public static class EnumExtention
    {
        public static T GetEnumValue<T>(this string value) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
