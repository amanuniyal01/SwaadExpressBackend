using Microsoft.EntityFrameworkCore;
using SwaadExpress.Application.Contracts.Repository;
using SwaadExpress.DAL.Data;
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

        public  async Task<bool> IsUserAlreadyExist(UserEntity user)
        {
            //Checking if user is already Present
            return await _dbContext.Users.AnyAsync(x => x.Id == user.Id || x.Email == user.Email);

        }
        public async Task RegisterUser(UserEntity user)
        {
            //Simply Just add User to the Table
            var result = await _dbContext.Users.AddAsync(user);
        }
    }
}
