namespace Homework18.Dtos.Responses
{
	public class BaseResponse<T> : PageDto
        where T : class
	{
		public T Data { get; set; }
		public SupportDto Support { get; set; }
    }
}

