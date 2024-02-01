using PracticalTest.Interfaces;
using PracticalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Repositories
{
    public class SubjectRepository : BaseRepository<Subjects>, ISubjectRepository
    {
        public SubjectRepository(PracticalTestContext context) : base(context)
        {
        }
    }
}