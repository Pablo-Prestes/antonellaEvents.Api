using System.Text.Json.Serialization;

namespace AntonellaEvents.Domain.Responses
{
	public class ApiResponse<T>
	{
		public int StatusCode { get; set; }
		public bool Success { get; set; }
		public string Message { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public object? Data { get; set; }

		public ApiResponse(bool success, string message, int statusCode = 200)
		{
			Success = success;
			Message = message;
			StatusCode = statusCode;
		}

		public ApiResponse(bool success, string message, T data, int statusCode = 200)
		{
			Success = success;
			Message = message;
			Data = data;
			StatusCode = statusCode;
		}

		public ApiResponse(bool success, string message, List<T> data, int statusCode = 200)
		{
			Success = success;
			Message = message;
			Data = data;
			StatusCode = statusCode;
		}
	}
}
