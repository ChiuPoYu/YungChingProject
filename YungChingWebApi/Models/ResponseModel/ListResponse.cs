namespace WebApi.Models.ResponseModel;

public class ListResponse<T> : BaseResponse
{
    public IReadOnlyList<T> Data { get; }

    public ListResponse(IEnumerable<T> items, string? message = null, string? errorCode = null, bool success = true)
        : base(success, message, errorCode)
    {
        Data = items.ToList();
    }

    public static ListResponse<T> Empty(string? message = "No data")
        => new ListResponse<T>(Array.Empty<T>(), message);

    public static ListResponse<T> Fail(string message, string? errorCode = null)
        => new ListResponse<T>(Array.Empty<T>(), message, errorCode, success: false);
}


