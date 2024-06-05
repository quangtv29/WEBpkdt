using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;

namespace API.Business.Repository
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository
    {
        public PhotoRepository(DataContext db) : base(db)
        {
        }

        public void CreatePhoto (Photo photo)
        {
            Create(photo);
        }
    }
}
