namespace API.Business.Repository
{
    public interface IRepository <TEntity> where TEntity : class  
    {
        IQueryable<TEntity> GetAll ();
    }
}
