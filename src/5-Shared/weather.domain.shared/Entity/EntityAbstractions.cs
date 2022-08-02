namespace weather.domain.shared.Entity
{
    public abstract class EntityAbstractions
    {
        private readonly IList<string> InternalMessages;

        public EntityAbstractions(int id)
        {
            Id = id;
            InternalMessages = new List<string>();
        }

        public int Id { get; private set; }
        public IList<string> Messages { get { return InternalMessages; } }
        public bool IsValid { get { return !InternalMessages.Any(); } }
        public abstract void BusinessValidation();
        public void BussinesMessage(string message) => InternalMessages.Add(message);
    }
}
