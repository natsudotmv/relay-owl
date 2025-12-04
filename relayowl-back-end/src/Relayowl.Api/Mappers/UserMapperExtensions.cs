using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Relayowl.Api.DTOs.User;
using Relayowl.Core.Entities;

namespace Relayowl.Api.Mappers;

public static class UserMapperExtensions
{
    public static ReadUserDto ToReadUserDto(this Core.Entities.DomainUser domainUser)
    {
        return new ReadUserDto
        {
            Id = domainUser.Id,
            Email = domainUser.Email,
            FullName = domainUser.FullName,
            Role = domainUser.Role,
            DepartmentId = domainUser.DepartmentId
        };
    }
    
    public static Core.Entities.DomainUser ToCreateUserEntity(this CreateUserDto dto)
    {
        return new Core.Entities.DomainUser()
        {
            Email = dto.Email,
            FullName = dto.FullName,
            PasswordHash = dto.PasswordHash,
            Role = dto.Role,
            DepartmentId = dto.DepartmentId
        };
    }
    
    public static void UpdateUser(this DomainUser domainUser ,UpdateUserDto dto)
    {
        domainUser.Email = dto.Email;
        domainUser.FullName = dto.FullName;
        domainUser.Role = dto.Role;
        domainUser.DepartmentId = dto.DepartmentId;
    }
}