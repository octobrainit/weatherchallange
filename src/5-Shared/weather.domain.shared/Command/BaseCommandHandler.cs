using FluentValidation;
using MediatR;
using Serilog;
using System.Diagnostics;
using weather.domain.shared.Responses;
using weather.shared.logger.Abstraction;

namespace weather.domain.shared.Command
{
    public abstract class BaseCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private Stopwatch stopWatch;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public readonly List<string> Messages;
        private readonly ILogAbstraction _logger;

        public bool IsValid { get { return !Messages.Any(); } }
        public Guid CorrelationId { get; private set; }

        public BaseCommandHandler(
            IEnumerable<IValidator<TRequest>> validators,
            ILogAbstraction logger
        )
        {
            _validators = validators;
            Messages = new List<string>();
            _logger = logger;
        }
        public abstract Task<TResponse> HandleAsync(TRequest request);

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            StartProcess(request);

            Validate(request);

            var response = await HandleAsync(request);

            EndProcess();

            return response;
        }

        private void Validate(TRequest request)
        {
            var failures = _validators
              .Select(v => v.Validate(request))
              .SelectMany(x => x.Errors)
              .Where(f => f != null)
              .ToList();
            
            if (failures.Any())
                Messages.AddRange(failures.Select(item => "Property -> " + item.PropertyName + " : " + item.ErrorMessage).ToList());
            if(Messages.Any())
                _logger.LogInformation("Validating Command messages returned: \n" + String.Join(",",Messages));
        }

        public EventResponse<Y> ResponseError<Y>() where Y : class => EventResponse<Y>.ResponseWithMessage(Messages);

        private void StartProcess(TRequest request)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            _logger.LogInformation("\n================================================= \n");
            _logger.LogInformation("Process was started");
            _logger.LogRequest(request);
        }

        private void EndProcess()
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            _logger.LogInformation(($"Time to end process: {ts.Hours}:{ts.Minutes}:{ts.Seconds}:{ts.Milliseconds / 10}"));
            _logger.LogInformation("\n================================================= \n");
            _logger.LogOnConsole();
        }
        
    }
}
