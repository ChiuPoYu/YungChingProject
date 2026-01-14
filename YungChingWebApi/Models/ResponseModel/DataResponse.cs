namespace WebApi.Models.ResponseModel;

/// <summary>
/// 單一資料回應類別
/// </summary>
/// <typeparam name="T">資料型別</typeparam>
public class DataResponse<T> : BaseResponse
{
    /// <summary>
    /// 回應資料
    /// </summary>
    public T? Data { get; }

    /// <summary>
    /// 單一資料回應建構函式
    /// </summary>
    /// <param name="data">回應資料</param>
    /// <param name="message">訊息內容</param>
    /// <param name="errorCode">錯誤代碼</param>
    /// <param name="success">是否成功</param>
    public DataResponse(T data, string? message = null, string? errorCode = null, bool success = true)
        : base(success, message, errorCode)
    {
        Data = data;
    }

    /// <summary>
    /// 建立失敗的資料回應
    /// </summary>
    /// <param name="message">錯誤訊息</param>
    /// <param name="errorCode">錯誤代碼</param>
    /// <returns>失敗的資料回應</returns>
    public static DataResponse<T> Fail(string message, string? errorCode = null)
        => new DataResponse<T>(default!, message, errorCode, success: false);
}

