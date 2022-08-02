using Microsoft.AspNetCore.Mvc;
using weather.domain.shared.Responses;

namespace weather.api.Core
{
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        public BaseController(){}

        public async Task<EventResponse<TResponse>> ExecuteHandler<TRequest,TResponse>(Func<TRequest, Task<EventResponse<TResponse>>> function, TRequest command) 
            where TRequest : class
            where TResponse : class
        {
            return await function(command);
        }

    }
}
