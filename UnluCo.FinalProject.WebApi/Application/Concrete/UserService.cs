﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.UsersViewModel;
using UnluCo.FinalProject.WebApi.DataAccess.UnitOfWorks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfwork, IMapper mapper)
        {
            _unitOfwork = unitOfwork;
            _mapper = mapper;
        }
        public bool Add(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            _unitOfwork.Users.Add(user);
            var affectedRows = _unitOfwork.Complete();
            return affectedRows > 0 ? true : false;
        }

        public bool Delete(DeleteUserViewModel deleteUserViewModel)
        {
            var user = _unitOfwork.Users.GetById(deleteUserViewModel.Id).Result;
            _unitOfwork.Users.Delete(user);
            var affectedRows = _unitOfwork.Complete();
            return affectedRows > 0 ? true : false;
        }

        public Task<UserViewModel> Get(Expression<Func<User, bool>> filter)
        {
            var user = _unitOfwork.Users.Get(filter).Result;
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return Task.FromResult(userViewModel);
        }

        public Task<List<UserViewModel>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            var users = _unitOfwork.Users.GetAll().Result;

            var userViewList = _mapper.Map<List<User>, List<UserViewModel>>(users);
            return Task.FromResult(userViewList);
        }

        public Task<UserViewModel> GetById(string id)
        {
            var user = _unitOfwork.Users.GetUserWithAll(id).Result;
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return Task.FromResult(userViewModel);
        }
        // Düzenlenecek
        public bool Update(UserViewModel updateUserViewModel)
        {
            var user = _mapper.Map<User>(updateUserViewModel);
            _unitOfwork.Users.Update(user);
            var affectedRows = _unitOfwork.Complete();
            return affectedRows > 0 ? true : false;
        }
    }
}
