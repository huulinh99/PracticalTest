using PracticalTest.Interfaces;
using PracticalTest.Models;
using PracticalTest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public SubjectService(IUnitOfWork unitOfWork, PaginationOptions paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions;
        }
        public Subjects GetSubject(string id)
        {
            return _unitOfWork.SubjectRepository.GetById(id);
        }

        public List<Subjects> GetSubjects()
        {
            return _unitOfWork.SubjectRepository.GetAll().ToList();
        }
    }
}