using Microsoft.EntityFrameworkCore;
using PracticalTest.Interfaces;
using PracticalTest.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Web;

namespace PracticalTest.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly PracticalTestContext _context;
        protected readonly DbSet<T> _entities;
        public BaseRepository(PracticalTestContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public void Add(T entity)
        {
            _entities.AddAsync(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable().ToList();
        }

        public T GetById(string id)
        {
            return _entities.Find(Convert.ToInt32(id));
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}