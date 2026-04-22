namespace FCG.Api.Erros;

public class ApiException
{
    public ApiException(string statusCode, string message, string detail)
    {
        StatusCode = statusCode;
        Message = message;
        Detail = detail;
    }

    public string StatusCode { get; set; }
    public string Message { get; set; }
    public string Detail { get; set; }

}
