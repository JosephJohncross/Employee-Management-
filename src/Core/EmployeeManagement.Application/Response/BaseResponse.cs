namespace EmployeeManagement.Application.Response
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? ValidationErrors { get; set; }

        public BaseResponse()
        {
            Status = true;
        }

        public BaseResponse(string message)
        {
            Status = true;
            Message = message;
        }

        public BaseResponse(string message, bool status)
        {
            Status = status;
            Message = message;
        }
    }
}