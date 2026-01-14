namespace WebApi.Models.ResponseModel;

/// <summary>
/// 結果回應類別（不包含資料，僅表示操作成功或失敗）
/// </summary>
public class ResultResponse : BaseResponse
{
    /// <summary>
    /// 結果回應建構函式
    /// </summary>
    /// <param name="success">是否成功</param>
    /// <param name="message">訊息內容</param>
    /// <param name="errorCode">錯誤代碼</param>
    public ResultResponse(bool success = true, string? message = null, string? errorCode = null)
        : base(success, message, errorCode)
    {
    }
}

