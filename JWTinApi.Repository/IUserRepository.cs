using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JWTinApi.Model;

namespace JWTinApi.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> PostUser(User user);
    }
}
