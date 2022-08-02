using MediatR;
using weather.domain.shared.Responses;

namespace weather.domain.shared.Command
{
    public class BaseCommand<TRequest, TResponse> : IRequest<EventResponse<TResponse>>
        where TRequest : class
        where TResponse : class
    {
        public Guid CorrelationId { get; private set; }

        public BaseCommand()
        {
            CorrelationId = Guid.NewGuid();
        }

        public void SetCorrelationId(Guid id) => CorrelationId = id;

        public Guid GetCorrelationId() => Guid.Empty == CorrelationId ? Guid.NewGuid() : CorrelationId;

    }
}
