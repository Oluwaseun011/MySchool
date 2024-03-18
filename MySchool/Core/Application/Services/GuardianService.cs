using MySchool.Core.Application.Dtos;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Application.Interfaces.Services;
using MySchool.Core.Domain.Entities;

namespace MySchool.Core.Application.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGuardianRepository _guardianRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IRoleRepository _roleRepository;

        public GuardianService(IUnitOfWork unitOfWork, IGuardianRepository guardianRepository, IUserRepository userRepository,IRoleRepository roleRepository, IFileRepository fileRepository)
        {
            _unitOfWork = unitOfWork;
            _guardianRepository = guardianRepository;
            _userRepository = userRepository;
            _fileRepository = fileRepository;
            _roleRepository = roleRepository;
        }

        public BaseResponse<GuardianDto> Create(GuardianRequest request)
        {
            var exists = _userRepository.Exist(request.Email);
            if(exists)
            {
                return new BaseResponse<GuardianDto>
                {
                    Message = "Email already exists!!!",
                    Status = false,
                    Data = null
                };
            }

            if(request.Password != request.ConfirmPassword)
            {
                return new BaseResponse<GuardianDto>
                {
                    Message = "Password does not match",
                    Status = false,
                    Data = null
                };
            }

            var user = new User
            {
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                ImageUrl = _fileRepository.Upload(request.ImageUrl)

            };

            var role = _roleRepository.Get("guardian");

            var userRole = new UserRole()
            {
                UserId = user.Id,
                User = user,
                RoleId = role.Id,
                Role = role,
            };

            user.UserRoles.Add(userRole);

            _userRepository.Create(user);

            var guardian = new Guardian()
            {
                UserId = user.Id,
                User = user,

            };

            _guardianRepository.Create(guardian);
            _unitOfWork.Save();

            return new BaseResponse<GuardianDto>
            {
                Message = "Registration Successfull!!!",
                Status = true,
                Data = new GuardianDto
                {
                    Id = guardian.Id,
                    UserId = user.Id,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FullName = $"{user.FirstName} {user.LastName}",

                },
        };


        }

        public BaseResponse<GuardianDto> Get(string id)
        {
            var guardian = _guardianRepository.Get(a => a.Id == id);
            return new BaseResponse<GuardianDto>
            {
                Message = "Guardian successfully found!!!",
                Status = true,
                Data = new GuardianDto
                {
                    Id = guardian.Id,
                    UserId = guardian.UserId,
                    Email = guardian.User.Email,
                    PhoneNumber = guardian.User.PhoneNumber,
                    FullName = $"{guardian.User.FirstName} {guardian.User.LastName}",

                },
            };
        }

        public BaseResponse<ICollection<GuardianDto>> GetAll()
        {
            var guardians = _guardianRepository.GetAll();

            var guardiansToDTO = guardians.Select(guardian => new GuardianDto
            {
                Id = guardian.Id,
                UserId = guardian.UserId,
                Email = guardian.User.Email,
                PhoneNumber = guardian.User.PhoneNumber,
                FullName = $"{guardian.User.FirstName} {guardian.User.LastName}",
                Students = guardian.Students.Select(a => new StudentDto
                {
                    UserId = a.UserId,
                    FullName = $"{a.User.FirstName} {a.User.LastName}",
                    AdmissionNumber = a.AdmissionNumber,
                }).ToList(),
            }).ToList();

            return new BaseResponse<ICollection<GuardianDto>>
            {
                Message = "Successfully Found",
                Status = true,
                Data = guardiansToDTO,
            };
            


        }

        public BaseResponse<GuardianDto> Update(string id, UpdateGuardianRequest request)
        {
            var guardian = _guardianRepository.Get(a => a.Id == id);
            if(guardian == null) 
            {
                return new BaseResponse<GuardianDto>
                {
                    Message = "Update Unsuccessfull",
                    Status = false,
                    Data = null,
                };
            }
            guardian.User.FirstName = request.FirstName;
            guardian.User.LastName = request.LastName;
            guardian.User.DateOfBirth = request.DateOfBirth;
            guardian.User.Gender = request.Gender;
            guardian.User.PhoneNumber = request.PhoneNumber;
            guardian.User.ImageUrl = _fileRepository.Upload(request.ImageUrl);
            _guardianRepository.Update(guardian);
            _unitOfWork.Save();
            return new BaseResponse<GuardianDto>
            {
                Message = "Update Successfull",
                Status = true,
                Data = new GuardianDto
                {
                    Id = guardian.Id,
                    UserId = guardian.UserId,
                    Email = guardian.User.Email,
                    PhoneNumber = guardian.User.PhoneNumber,
                    FullName = $"{guardian.User.FirstName} {guardian.User.LastName}",
                },
            };
            
        }
    }
}
