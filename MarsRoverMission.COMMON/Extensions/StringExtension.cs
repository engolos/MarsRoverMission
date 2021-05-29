namespace MarsRoverMission.COMMON.Extensions
{
    public static class StringExtension
    {
        public static bool IsNull(this string p)
        {
            return string.IsNullOrWhiteSpace(p);
        }

        public static bool IsNotNull(this string p)
        {
            return !IsNull(p);
        }
    }
}
