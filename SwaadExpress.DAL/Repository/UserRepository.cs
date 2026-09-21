using Microsoft.EntityFrameworkCore;
using SwaadExpress.Application.Contracts.Repository;
using SwaadExpress.DAL.Data;
using SwaadExpress.Domain.Modal.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserRoleDto> GetUserWithRole(Guid userId) {

            var user = await _dbContext.Users.Include(x => x.Role).Where(x => x.Id == userId)
                .Select(x => new UserRoleDto
                {
                    UserId = x.Id,
                    UserName = x.UserName,
                    roleName = x.Role.RoleName
                }
                ).FirstOrDefaultAsync();

            return user;


    }
    }
}
