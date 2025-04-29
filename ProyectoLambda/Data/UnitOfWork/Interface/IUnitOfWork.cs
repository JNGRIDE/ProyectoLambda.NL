using ProyectoLambda.Data.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLambda.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
        IUserRepository UserRepository { get; }
    }  
}
