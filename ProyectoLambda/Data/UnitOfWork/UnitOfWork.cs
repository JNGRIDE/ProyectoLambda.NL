using ProyectoLambda.Data.Context;
using ProyectoLambda.Data.Repositories;
using ProyectoLambda.Data.Repositories.Interface;
using ProyectoLambda.Data.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLambda.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            UserRepository = new UserRepository(_db);
        }

        // Repositories
        public IUserRepository UserRepository { get; private set; }

        // Unit of Work methods
        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();  
        }
    }
}
