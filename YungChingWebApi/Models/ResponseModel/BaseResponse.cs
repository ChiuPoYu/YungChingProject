namespace WebApi.Models.ResponseModel;

/// <summary>
/// 基礎回應類別，所有 API 回應的基底
/// </summary>
public abstract class BaseResponse
{
    /// <summary>
    /// 狀態資訊
    /// </summary>
    public StatusInfo Status { get; protected set; }

    /// <summary>
    /// 基礎回應建構函式
    /// </summary>
    /// <param name="success">是否成功</param>
    /// <param name="message">訊息內容</param>
    /// <param name="errorCode">錯誤代碼</param>
    protected BaseResponse(bool success, string? message = null, string? errorCode = null)
    {
        Status = new StatusInfo
        {
            Success = success,
            Message = message,
            ErrorCode = errorCode
        };
    }

    /// <summary>
    /// 狀態資訊類別
    /// </summary>
    public class StatusInfo
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// 訊息內容
        /// </summary>
        public string? Message { get; set; }
        
        /// <summary>
        /// 錯誤代碼
        /// </summary>
        public string? ErrorCode { get; set; }
    }
}
