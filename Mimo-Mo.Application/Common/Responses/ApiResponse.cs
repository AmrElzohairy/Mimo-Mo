using System.Text.Json.Serialization;

namespace Mimo_Mo.Application.Common.Responses;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Message { get; set; } = null;
    public T? Data { get; set; } 

    public ApiResponse()
    {
    }

    public ApiResponse(T data, string message)
    {
        Success = true;
        Message = message;
        Data = data;
    }
    
    public ApiResponse(T data)
    {
        Success = true;
        Data = data;
    }
    
   
}