namespace MySchool.Core.Application.Dtos
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public string? Message {  get; set; }
        public bool Status {  get; set; }
    }
}
