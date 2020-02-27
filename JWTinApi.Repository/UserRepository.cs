using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JWTinApi.Model;
using JWTinApi.Repository.DbContext;
using Microsoft.EntityFrameworkCore;

namespace JWTinApi.Repository
{
    public class UserRepository:IUserRepository
    {
        private JWTinApiContext _context;

        public UserRepository(JWTinApiContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> PostUser(User user)
        {
            await _context.Users.AddAsync(user);
            var result =await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return null;
            }

            return user;


        }
    }
}
