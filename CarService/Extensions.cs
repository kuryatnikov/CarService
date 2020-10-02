using System;

namespace CarService
{
    public static class Extensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return (String.IsNullOrWhiteSpace(str));
        }
        
    }
}