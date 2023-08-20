namespace API.Entities.Interface
{
    public interface IEntity
    {
        public interface IEntity<T>
        {
            T Id { get; set; }
        }
        public interface IEntity : IEntity<Guid>
        {
        }
    }
}
