namespace Application.Models;

public class ResponseData<T> where T : class
{
  public ResponseData(T data)
  {
    Data = data;
    Success = true;
  }

  public ResponseData(string errorMessage)
  {
    ErrorMessage = errorMessage;
    Success = false;
  }

  public bool Success { get; set; }
  public string ErrorMessage { get; set; } = string.Empty;
  public T? Data { get; set; }
}
