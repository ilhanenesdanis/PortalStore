using System.Text.Json.Serialization;

namespace PortalStore.DTO
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CustomResponseDto<T> Success(int StatusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode, Data = data };
        }
        public static CustomResponseDto<T> Success(int StatusCode)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode };
        }
        public static CustomResponseDto<T> Fail(List<string> Errors, int statusCode)
        {
            return new CustomResponseDto<T> { Errors = Errors, StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
