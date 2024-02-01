using PracticalTest.Models;
using PracticalTest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Interfaces
{
    public interface ISubjectService
    {
        List<Subjects> GetSubjects();
        Subjects GetSubject(string id);
    }
}
