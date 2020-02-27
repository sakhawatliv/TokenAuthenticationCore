using System;
using System.Collections.Generic;
using System.Text;
using JWTinApi.Model;
using JWTinApi.Repository.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTinApi.Repository.DbContext
{
    public class JWTinApiContext:IdentityDbContext<ApplicationUser>
    {
        public JWTinApiContext(DbContextOptions<JWTinApiContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
