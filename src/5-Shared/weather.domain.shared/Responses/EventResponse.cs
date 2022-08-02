namespace weather.domain.shared.Responses
{
    public class EventResponse<T> where T : class
    {
        public EventResponse(T data = null)
        {
            Messages = new List<string>();
            Data = data;
        }

        public T Data { get; set; }
        public List<string> Messages { get; private set; }
        public void AddMessage(string mensagem) => Messages.Add(mensagem);
        public void AddMessage(IEnumerable<string> mensagem) => Messages.AddRange(mensagem);
        public bool Success { get { return !Messages.Any(); } }

        public static EventResponse<T> ResponseWithMessage(string message)
        {
            var response = new EventResponse<T>();
            response.AddMessage(message);
            return response;
        }
        
        public static EventResponse<T> ResponseWithoutMessage()
        {
            var response = new EventResponse<T>();
            return response;
        }

        public static async Task<EventResponse<T>> ResponseWithoutMessageAsync()
        {
            var response = new EventResponse<T>();
            return await Task.Run(() => response);
        }

        public static EventResponse<T> ResponseWithMessage(IEnumerable<string> message)
        {
            var response = new EventResponse<T>();
            response.AddMessage(message);
            return response;
        }

        public static EventResponse<T> CreateResponse(T data) =>
            new(data);
    }
}
