using System.Data.SqlClient;
using weather.domain.shared.Responses;
using weather.shared.logger.Abstraction;

namespace weather.db.sqlserver.Core
{
    public class BaseRepository<T> where T : class
    {
        private readonly ILogAbstraction _logAbstractor;
        private readonly DbSettings _connection;
        public SqlConnection? con = null;

        public List<string> Messages { get; private set; } = new List<string>();

        public BaseRepository(
            ILogAbstraction logAbstractor,
            DbSettings connection
         )
        {
            _logAbstractor = logAbstractor;
            _connection = connection;
            con = new SqlConnection(_connection.Connection);
        }

        public EventResponse<Y> ReturnWithError<Y>() where Y : class => EventResponse<Y>.ResponseWithMessage(Messages);

        public async Task<EventResponse<Y>> ExecuteMethod<Y, Z>(Func<Z, Task<EventResponse<Y>>> function, Z command)
            where Y : class
            where Z : class
        {
            try
            {
                _logAbstractor
                .LogInformation("Process Repository", nameof(T))
                .LogRequest(command);

                try
                {
                    var response = await function(command);

                    return response;
                }
                catch (Exception ex)
                {
                    _logAbstractor.LogInformation(ex.Message, nameOfClass: nameof(T));
                    return EventResponse<Y>.ResponseWithMessage($"Some error ocurred : {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                _logAbstractor
                    .LogInformation("Exception has ocurred", nameof(T))
                    .LogRequest(command)
                    .LogRequest(ex);

                return EventResponse<Y>.ResponseWithMessage(ex.Message);
            }
        }

    }
}
