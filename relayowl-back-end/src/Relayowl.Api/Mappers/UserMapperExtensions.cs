using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Relayowl.Api.DTOs.User;

namespace Relayowl.Api.Mappers;

public static class UserMapperExtensions
{
    public static ReadUserDto ToReadUserDto(this Core.Entities.User user)
    {
        return new ReadUserDto
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            Role = user.Role,
            DepartmentId = user.DepartmentId
        };
    }
    
    public static Core.Entities.User ToCreateUserEntity(this CreateUserDto dto)
    {
        return new Core.Entities.User()
        {
            Email = dto.Email,
            FullName = dto.FullName,
            PasswordHash = dto.PasswordHash,
            Role = dto.Role,
            DepartmentId = dto.DepartmentId
        };
    }
    
    public static Core.Entities.User ToUpdateUser(this UpdateUserDto dto)
    {
        return new Core.Entities.User()
        {
            Email = dto.Email,
            FullName = dto.FullName,
            Role = dto.Role,
            DepartmentId = dto.DepartmentId
        };
    }
}