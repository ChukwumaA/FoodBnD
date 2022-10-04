using System.Net;

namespace FoodBnD.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get;  }
}



