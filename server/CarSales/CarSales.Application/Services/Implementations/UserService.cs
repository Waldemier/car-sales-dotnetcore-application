using System;
using System.Collections.Generic;
using CarSales.Application.DataTrasferObjects;
using CarSales.Application.Services.Interfaces;
using CarSales.Domain.Interfaces;
using AutoMapper;
using CarSales.Domain.Interfaces.Other;

namespace CarSales.Application.Services.Implementations
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }


        public IEnumerable<UserDto> GetAllUsersForResponse(bool withOffers = false, bool withReviews = false)
        {
            var userEntities = this._userRepository.GetAllUsers(withOffers: withOffers, withReviews:withReviews);
            var userDtos = this._mapper.Map<IEnumerable<UserDto>>(userEntities);

            return userDtos;
        }

        public UserDto GetUserByIdForResponse(Guid Id, bool withOffers = false, bool withReviews = false)
        {
            var userEntity = this._userRepository.GetById(Id, withOffers: withOffers, withReviews:withReviews);
            var userDto = this._mapper.Map<UserDto>(userEntity);

            return userDto;
        }
    }
}