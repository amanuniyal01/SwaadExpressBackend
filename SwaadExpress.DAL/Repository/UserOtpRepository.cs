using Microsoft.EntityFrameworkCore;
using SwaadExpress.Application.Contracts.Repository;
using SwaadExpress.DAL.Data;
using SwaadExpress.Domain.Modal.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.DAL.Repository
{
    public class UserOtpRepository : IUserOtpRepository
    {
        private readonly AppDbContext _dbContext;
        public UserOtpRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserEntity> GetUserOtpDetails(string email)
        {
            var result = await _dbContext.Users.Include(x => x.Otp).FirstOrDefaultAsync(
                x => x.Email == email
                );

            return result;
        }
    }
}
