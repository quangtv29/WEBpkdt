using System.Net;

namespace API.Business.Helper
{
    public class ApiResponse
    {
        public HttpStatusCode? StatusCode { get;set; }

        public string? Message { get; set; }

        public string? Data { get; set; }   
    }
}
