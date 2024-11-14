namespace Nlabs.Result;
public sealed class Result<T>
{
    public T? Data { get; set; }
    public List<string>? ErrorMessages { get; set; }
    public Dictionary<string, List<string>>? ErrorDetails { get; set; }
    public bool IsSuccessful { get; set; } = true;
    public int StatusCode { get; set; } = 200;

    public Result(T data)
    {
        Data = data;
    }

    public Result(int statusCode, List<string> errorMessages)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorMessages = errorMessages;
    }
    public Result(int statusCode, string errorMessage)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorMessages = new() { errorMessage };
    }

    public Result(int statusCode, Dictionary<string, List<string>> errorDetails)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorDetails = errorDetails;
    }

    public static implicit operator Result<T>(T data) => new(data);

    public static implicit operator Result<T>((int statusCode, List<string> errorMessages) error) => new(error.statusCode, error.errorMessages);

    public static implicit operator Result<T>((int statusCode, string errorMessage) error) => new(error.statusCode, error.errorMessage);

    public static implicit operator Result<T>((int statusCode, Dictionary<string, List<string>> errorDetails) error) => new(error.statusCode, error.errorDetails);

    public static Result<T> Success(T data) => new(data);

    public static Result<T> Fail(int statusCode, List<string> errorMessages) => new(statusCode, errorMessages);

    public static Result<T> Fail(int statusCode, string errorMessage) => new(statusCode, errorMessage);

    public static Result<T> Fail(string errorMessage) => new(400, errorMessage);

    public static Result<T> Fail(List<string> errorMessages) => new(400, errorMessages);

    public static Result<T> Fail(int statusCode, Dictionary<string, List<string>> errorDetails) => new(statusCode, errorDetails);
}