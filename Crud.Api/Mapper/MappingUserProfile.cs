using AutoMapper;
using Crud.Models.DBModels;
using Crud.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Mapper
{
    public class MappingUserProfile : Profile
    {
        public MappingUserProfile()
        {
            var _userMap = CreateMap<UserPutModel, Users>();

            _userMap.ForMember(x => x.Email, opt => opt.Ignore())
                    .AfterMap((x, y) =>
                    {
                        if (!string.IsNullOrEmpty(x.Email))
                        {
                            y.Email = x.Email;
                        }
                    });
            _userMap.ForMember(x => x.CreatedDate, opt => opt.Ignore());
            _userMap.ForMember(x => x.FirstName, opt => opt.Ignore())
                    .AfterMap((x, y) =>
                    {
                        if (!string.IsNullOrEmpty(x.FirstName))
                        {
                            y.FirstName = x.FirstName;
                        }
                    });
            _userMap.ForMember(x => x.LastName, opt => opt.Ignore())
                    .AfterMap((x, y) =>
                    {
                        if (!string.IsNullOrEmpty(x.LastName))
                        {
                            y.LastName = x.LastName;
                        }
                    });
            _userMap.ForMember(x => x.Phone, opt => opt.Ignore())
                    .AfterMap((x, y) =>
                    {
                        if (!string.IsNullOrEmpty(x.Phone))
                        {
                            y.Phone = x.Phone;
                        }
                    });

            _userMap.ForMember(x => x.Role, opt => opt.Ignore())
                    .AfterMap((x, y) =>
                    {
                        if (x.RoleId.HasValue)
                        {
                            y.Role = new Roles
                            {
                                Id = x.RoleId.Value
                            };
                        }
                    });
        }
        
    }
}
