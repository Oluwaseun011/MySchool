using MySchool.Core.Application.Dtos;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Application.Interfaces.Services;
using MySchool.Core.Domain.Entities;
using System.Linq.Expressions;

namespace MySchool.Core.Application.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public BaseResponse<UserDto> Get(string id)
        {
            var userExist = _userRepository.Get(id);
            if (userExist == null)
            {
                return new BaseResponse<UserDto>
                {
                    Message = "Not found",
                    Status = false,
                    Data = null
                };
            }

            return new BaseResponse<UserDto>
            {
                Message = "Successful",
                Status = true,
                Data = new UserDto
                {
                    FullName = userExist.FirstName + " " + userExist.LastName,
                    Email = userExist.Email,
                    PhoneNumber = userExist.PhoneNumber,
                    Age = DateTime.Now.Year - userExist.DateOfBirth.Year,
                    Gender = userExist.Gender,
                    ImageUrl = userExist.ImageUrl,
                    Roles = userExist.UserRoles.Select(a => new RoleDto
                    {
                        Name = a.Role.Name
                    }).ToList()
                }
            };
        }

        public BaseResponse<ICollection<UserDto>> GetUsers()
        {
            return new BaseResponse<ICollection<UserDto>>
            {
                Message = "Successfull",
                Status = true,
                Data = _userRepository.GetAll().Select(a => new UserDto
                {
                    Id = a.Id,
                    FullName = a.FirstName + " " + a.LastName,
                    Age = DateTime.Now.Year - a.DateOfBirth.Year,
                }).ToList(),
        };
        }

        public BaseResponse<UserDto> Login(LoginRequest request)
        {
            var user = _userRepository.Get(request.Email);
            if (user == null) return null;
            if (BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return new BaseResponse<UserDto>
                {
                    Status = true,
                    Message = "login succesful",
                    Data = new UserDto
                    {
                        FullName = user.FirstName + " " + user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Age = DateTime.Now.Year - user.DateOfBirth.Year,
                        Gender = user.Gender,
                        ImageUrl = user.ImageUrl,
                        Roles = user.UserRoles.Select(a => new RoleDto
                        {
                            Name = a.Role.Name
                        }).ToList()
                    }
                };
            }
            return null;
        }
    }
}
