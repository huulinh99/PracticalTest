using PracticalTest.Interfaces;
using PracticalTest.Models;
using PracticalTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PracticalTest.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PracticalTestContext _context;
        private readonly IUserRepository _userRepository;
        private readonly ISubjectRepository _subjectRepository;
        public UnitOfWork(PracticalTestContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public ISubjectRepository SubjectRepository => _subjectRepository ?? new SubjectRepository(_context);
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}