namespace WebApi.Models.ResponseModel;
public class DataResponse<T> : BaseResponse
{
    public T? Data { get; }

    public DataResponse(T data, string? message = null, string? errorCode = null, bool success = true)
        : base(success, message, errorCode)
    {
        Data = data;
    }

    public static DataResponse<T> Fail(string message, string? errorCode = null)
        => new DataResponse<T>(default!, message, errorCode, success: false);
}

