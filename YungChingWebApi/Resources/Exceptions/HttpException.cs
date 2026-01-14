namespace YungChingWebApi.Resources.Exceptions
{
    /// <summary>
    /// HTTP 例外類別，用於在 Service 層拋出 HTTP 相關的錯誤
    /// </summary>
    public class HttpException : Exception
    {
        /// <summary>
        /// HTTP 狀態碼
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// 錯誤代碼
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// 建構函式
        /// </summary>
        /// <param name="statusCode">HTTP 狀態碼</param>
        /// <param name="message">錯誤訊息</param>
        /// <param name="errorCode">錯誤代碼</param>
        public HttpException(int statusCode, string message, string errorCode) 
            : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }
    }
}
