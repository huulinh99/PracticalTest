using System;
using System.Threading.Tasks;

namespace PracticalTest.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
