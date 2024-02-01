using Microsoft.Extensions.Options;
using PracticalTest.DTO;
using PracticalTest.Interfaces;
using PracticalTest.Models;
using PracticalTest.Utils;
using PracticalTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PracticalTest.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public UserService(IUnitOfWork unitOfWork, PaginationOptions paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions;
        }

        public UserViewModel GetById(string id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);
            var result = new UserViewModel();
            result.Users = user;
            return result;
        }

        public PagedResult<UserDTO> GetUsers(UserQueryFilter filters)
        {
            var res = new PagedResult<UserDTO>();
            try
            {
                filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
                filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
                var users = _unitOfWork.UserRepository.GetAll();

                if (filters.SearchValue != null)
                {
                    users = users.Where(x => x.Name.ToLower().Contains(filters.SearchValue.ToLower())
                                            || x.Nric.ToLower().Contains(filters.SearchValue.ToLower()));
                }
                var pagedusers = PagedList<Users>.ToPagedList(users, filters.PageNumber, filters.PageSize);
                var userDto = new List<UserDTO>();
                var pagedusersDTO = new PagedResult<UserDTO>();
                foreach (var pageduser in pagedusers)
                {
                    var dto = new UserDTO();
                    DateTime birthday = pageduser.Birthday;
                    int age = DateTime.Today.Year - birthday.Year;
                    if (DateTime.Today.Month < birthday.Month || (DateTime.Today.Month == birthday.Month && DateTime.Today.Day < birthday.Day))
                    {
                        age--;
                    }
                    dto.SerialNumber = pageduser.SerialNumber;
                    dto.Nric = pageduser.Nric;
                    dto.Name = pageduser.Name;
                    dto.Age = age;
                    dto.AvailableDate = pageduser.AvailableDate;
                    if (pageduser.SubjectId != null)
                    {
                        dto.SubjectName = _unitOfWork.SubjectRepository.GetById(pageduser.SubjectId.ToString()).SubjectName;
                    }
                    userDto.Add(dto);
                }
                res.Data = userDto;
                var metadata = new PaginationMetadata
                {
                    TotalCount = pagedusers.TotalCount,
                    PageSize = pagedusers.PageSize,
                    CurrentPage = pagedusers.CurrentPage,
                    TotalPages = pagedusers.TotalPages,
                    HasNext = pagedusers.HasNext,
                    HasPrevious = pagedusers.HasPrevious
                };
                res.Metadata = metadata;
            }
            catch (Exception e)
            {
                TraceLog.WriteToLog(string.Format("Failed at GetUsers Services") + e.Message.ToString());
            }
            
            return res;
        }

        public void InsertUser(Users users)
        {
            _unitOfWork.UserRepository.Add(users);
            _unitOfWork.SaveChanges();
        }
        public void UpdateUser(Users users)
        {
            _unitOfWork.UserRepository.Update(users);
            _unitOfWork.SaveChanges();
        }
    }
}