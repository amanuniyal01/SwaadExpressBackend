using Microsoft.EntityFrameworkCore;
using SwaadExpress.Application.Contracts.Repository;
using SwaadExpress.DAL.Data;
using SwaadExpress.Domain.Modal.Dto;
using SwaadExpress.Domain.Modal.Entity;
namespace SwaadExpress.Repositories
{
    public class AuthenticationRepository:IAuthenticationRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthenticationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public  async Task<bool> IsUserAlreadyExistRepository(UserEntity user)
        {
            //Checking if user is already Present
            return await _dbContext.Users.AnyAsync(x=>x.Email == user.Email);

        }
        public async Task<UserEntity> RegisterUserRepository(UserEntity user)
        {
            // Add user to Users table
           await _dbContext.Users.AddAsync(user);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return user;
            
        }
    }
}
