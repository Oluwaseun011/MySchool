using MySchool.Core.Application.Dtos;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Application.Interfaces.Services;
using MySchool.Core.Domain.Entities;
using System.Data;

namespace MySchool.Core.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }
        public BaseResponse<RoleDto> Create(RoleRequest request)
        {
            var exists = _roleRepository.Get(request.Name);
            if (exists != null)
            {
                return new BaseResponse<RoleDto>
                {
                    Message = "Role already exists!!!",
                    Status = false,
                    Data = null,
                };
            }

            var role = new Role()
            {
                Name = request.Name,
                Description = request.Description
            };
            _roleRepository.Create(role);
            _unitOfWork.Save();

            var roleDto = new RoleDto()
            {
                Name = role.Name,
                Id = role.Id,
                
            };
            return new BaseResponse<RoleDto>
            {
                Message = "Role Creation Successfull",
                Status = true,
                Data = roleDto,
            }; ;
        }

        public BaseResponse<RoleDto> Get(string name)
        {
            var role = _roleRepository.Get(name);
            if(role == null)
            {
                return new BaseResponse<RoleDto>
                {
                    Message = "Role does not exist",
                    Status = false,
                    Data = null,
                };
            }
            var roleDto = new RoleDto()
            {
                Id = role.Id,
                Name = role.Name,
                Users = role.UserRoles.Select(a => new UserDto()
                {
                    FullName = $"{a.User.FirstName} {a.User.LastName}",
                    Age = DateTime.Now.Year - a.User.DateOfBirth.Year,
                }).ToList(),
            };

            return new BaseResponse<RoleDto>
            {
                Message = "Role Found Successfully",
                Status = true,
                Data = roleDto,
            };
        }

        public BaseResponse<ICollection<RoleDto>> GetAll()
        {
            return new BaseResponse<ICollection<RoleDto>>
            {
                Message = "Successfull",
                Status = true,
                Data = _roleRepository.GetAll().Select(role => new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Users = role.UserRoles.Select(a => new UserDto()
                    {
                        FullName = $"{a.User.FirstName} {a.User.LastName}",
                        Age = DateTime.Now.Year - a.User.DateOfBirth.Year,
                    }).ToList(),
                }).ToList(),
            };
        }

        public BaseResponse<RoleDto> Update(string id, UpdateRoleRequest request)
        {
            var role = _roleRepository.Get(a => a.Id == id);
            if (role == null) 
            {
                return new BaseResponse<RoleDto>
                {
                    Message = "Update Unsuccessfull",
                    Status = false,
                    Data = null,
                };
            }

            role.Description = request.Description;
            _roleRepository.Update(role);
            _unitOfWork.Save();
            return new BaseResponse<RoleDto>
            {
                Message = "Update Successfull",
                Status = true,
                Data = new RoleDto
                {
                    Id = id,
                    Name = role.Name,
                    Users = role.UserRoles.Select(a => new UserDto
                    {
                        Id = a.User.Id,
                        FullName = a.User.FirstName + " " + a.User.LastName,
                        Age = DateTime.Now.Year - a.User.DateOfBirth.Year,
                    }).ToList(),
                },
            };
        }
    }
}
