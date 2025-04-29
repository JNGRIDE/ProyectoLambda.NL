using GenericRepositoryZ;
using ProyectoLambda.Data.Context;
using ProyectoLambda.Data.Repositories.Interface;
using ProyectoLambda.Models;


namespace ProyectoLambda.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }   
}
