using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Relayowl.Api.DTOs.User;
using Relayowl.Core.Entities;

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
    
    public static void UpdateUser(this User user ,UpdateUserDto dto)
    {
        user.Email = dto.Email;
        user.FullName = dto.FullName;
        user.Role = dto.Role;
        user.DepartmentId = dto.DepartmentId;
    }
}