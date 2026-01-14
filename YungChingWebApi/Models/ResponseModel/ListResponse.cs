namespace WebApi.Models.ResponseModel;

/// <summary>
/// 列表資料回應類別
/// </summary>
/// <typeparam name="T">列表項目型別</typeparam>
public class ListResponse<T> : BaseResponse
{
    /// <summary>
    /// 列表資料（唯讀）
    /// </summary>
    public IReadOnlyList<T> Data { get; }

    /// <summary>
    /// 列表回應建構函式
    /// </summary>
    /// <param name="items">列表項目集合</param>
    /// <param name="message">訊息內容</param>
    /// <param name="errorCode">錯誤代碼</param>
    /// <param name="success">是否成功</param>
    public ListResponse(IEnumerable<T> items, string? message = null, string? errorCode = null, bool success = true)
        : base(success, message, errorCode)
    {
        Data = items.ToList();
    }

    /// <summary>
    /// 建立空的列表回應
    /// </summary>
    /// <param name="message">訊息內容</param>
    /// <returns>空列表回應</returns>
    public static ListResponse<T> Empty(string? message = "No data")
        => new ListResponse<T>(Array.Empty<T>(), message);

    /// <summary>
    /// 建立失敗的列表回應
    /// </summary>
    /// <param name="message">錯誤訊息</param>
    /// <param name="errorCode">錯誤代碼</param>
    /// <returns>失敗的列表回應</returns>
    public static ListResponse<T> Fail(string message, string? errorCode = null)
        => new ListResponse<T>(Array.Empty<T>(), message, errorCode, success: false);
}


