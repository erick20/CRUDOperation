using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Crud.Common.Helpers;
using Crud.DAL.IRepository;
using Crud.DAL.Repository;
using Crud.Models.DBModels;
using Crud.Models.GlobalModels;
using Crud.Models.UserModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Crud.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        IUserRepository _userRepository;
        IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            List<UserResponseModel> _resultList = new List<UserResponseModel>();
            UserResponseModel _resultModel;

            List<Users> _users = await _userRepository.GetUsers();
            foreach (var item in _users)
            {
                _resultModel = new UserResponseModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Phone = item.Phone,
                    CreatedDate = item.CreatedDate,
                    Role = item.Role.Role
                };
                _resultList.Add(_resultModel);
            }

            return Ok(_resultList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<UserResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationMessageModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsers(int id)
        {
            Users _user = await _userRepository.GetUser(id);
            if (_user == null)
            {
                List<ValidationMessageModel> _validationMessages = new List<ValidationMessageModel>();
                _validationMessages.Add(new ValidationMessageModel
                {
                    Code = "Id",
                    Key = "Id",
                    Message = "Id Is Invalid"
                });
                ProblemReporter.ReportBadRequest(JsonConvert.SerializeObject(_validationMessages));
            }

            UserResponseModel _result = new UserResponseModel
            {
                CreatedDate = _user.CreatedDate,
                Email = _user.Email,
                FirstName = _user.FirstName,
                Id = _user.Id,
                LastName = _user.LastName,
                Phone = _user.Phone,
                Role = _user.Role.Role
            };

            return Ok(_result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<UserResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationMessageModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostUsers([FromBody] UserPostModel model)
        {
            Roles _role = await _roleRepository.getRole(model.RoleId);
            if (_role == null)
            {
                List<ValidationMessageModel> _validationMessages = new List<ValidationMessageModel>();
                _validationMessages.Add(new ValidationMessageModel
                {
                    Code = "RoleId",
                    Key = "RoleId",
                    Message = "RoleId Is Invalid"
                });
                ProblemReporter.ReportBadRequest(JsonConvert.SerializeObject(_validationMessages));
            }

            Users _user = await _userRepository.InsertUser(model);

            UserResponseModel _result = new UserResponseModel
            {
                Id = _user.Id,
                CreatedDate = _user.CreatedDate,
                Email = _user.Email,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Phone = _user.Phone,
                Role = _user.Role.Role
            };
            return Ok(_result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<UserResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationMessageModel>), StatusCodes.Status400BadRequest)]// *************************
        public async Task<IActionResult> PutUsers(int id, [FromBody] UserPutModel model)
        {
            if (model.RoleId.HasValue)
            {
                Roles _role = await _roleRepository.getRole(model.RoleId.Value);
                if (_role == null)
                {
                    List<ValidationMessageModel> _validationMessages = new List<ValidationMessageModel>();
                    _validationMessages.Add(new ValidationMessageModel
                    {
                        Code = "RoleId",
                        Key = "RoleId",
                        Message = "RoleId Is Invalid"
                    });
                    ProblemReporter.ReportBadRequest(JsonConvert.SerializeObject(_validationMessages));
                }
            }

            Users _user = await _userRepository.GetUser(id);
            if (_user == null)
            {
                List<ValidationMessageModel> _validationMessages = new List<ValidationMessageModel>();
                _validationMessages.Add(new ValidationMessageModel
                {
                    Code = "Id",
                    Key = "Id",
                    Message = "Id Is Invalid"
                });
                ProblemReporter.ReportBadRequest(JsonConvert.SerializeObject(_validationMessages));
            }

            _user = _mapper.Map(model, _user);

            _user = await _userRepository.UpdateUser(_user);

            UserResponseModel _result = new UserResponseModel
            {
                Id = _user.Id,
                CreatedDate = _user.CreatedDate,
                Email = _user.Email,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Phone = _user.Phone,
                Role = _user.Role.Role
            };

            return Ok(_result);
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<UserResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationMessageModel>), StatusCodes.Status400BadRequest)]// *************************
        public async Task<IActionResult> DeleteUsers(int id)
        {
            Users _user = await _userRepository.GetUser(id);
            if (_user == null)
            {
                ProblemReporter.ReportResourseNotfound();
            }

            await _userRepository.DeleteUser(id);

            return Ok();
        }


        [HttpGet("FilterByRole")]
        [ProducesResponseType(typeof(List<UserResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationMessageModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFilteredUsers(int RoleId)
        {            
            Roles _role = await _roleRepository.getRole(RoleId);
            if (_role == null)
            {
                List<ValidationMessageModel> _validationMessages = new List<ValidationMessageModel>();
                _validationMessages.Add(new ValidationMessageModel
                {
                    Code = "RoleId",
                    Key = "RoleId",
                    Message = "RoleId Is Invalid"
                });
                ProblemReporter.ReportBadRequest(JsonConvert.SerializeObject(_validationMessages));
            }

            List<UserResponseModel> _resultList = new List<UserResponseModel>();
            UserResponseModel _resultModel;
            List<Users> _users = await _userRepository.GetUsersByRole(RoleId);
            foreach (var item in _users)
            {
                _resultModel = new UserResponseModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Phone = item.Phone,
                    CreatedDate = item.CreatedDate,
                    Role = item.Role.Role
                };
                _resultList.Add(_resultModel);
            }

            return Ok(_resultList);
        }

        [HttpGet("FilterByDate")]
        [ProducesResponseType(typeof(List<UserResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationMessageModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFilteredUsers(DateTime StartDate, DateTime EndDate)
        {
            List<UserResponseModel> _resultList = new List<UserResponseModel>();
            UserResponseModel _resultModel;
            List<Users> _users = await _userRepository.GetUsersByDate(StartDate, EndDate);
            foreach (var item in _users)
            {
                _resultModel = new UserResponseModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Phone = item.Phone,
                    CreatedDate = item.CreatedDate,
                    Role = item.Role.Role
                };
                _resultList.Add(_resultModel);
            }

            return Ok(_resultList);
        }


    }
}