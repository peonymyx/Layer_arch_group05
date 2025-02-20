using System;
namespace Backend.CommonLayer.Utilities
{
    public static class Logger
    {
        /// <summary>
        /// Log thông điệp ra Console (có thể thay đổi để ghi file hoặc sử dụng thư viện logging khác)
        /// </summary>
        public static void Log(string message)
        {
            Console.WriteLine($"[LOG - {DateTime.Now}] {message}");
        }
    }
}
