namespace WebApi.Models.ResponseModel;

public abstract class BaseResponse
{
    public StatusInfo Status { get; protected set; }

    protected BaseResponse(bool success, string? message = null, string? errorCode = null)
    {
        Status = new StatusInfo
        {
            Success = success,
            Message = message,
            ErrorCode = errorCode
        };
    }

    public class StatusInfo
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
    }
}
