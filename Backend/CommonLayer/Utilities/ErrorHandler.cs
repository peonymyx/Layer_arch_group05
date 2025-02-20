using System;
namespace Backend.CommonLayer.Utilities
{
    public static class ErrorHandler
    {
        /// <summary>
        /// Trả về thông báo lỗi từ Exception
        /// </summary>
        public static string GetErrorMessage(Exception ex)
        {
            // Bạn có thể mở rộng hàm này để log lỗi, thêm thông tin stacktrace, v.v.
            return ex.Message;
        }
    }
}
