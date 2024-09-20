using JourneyBizDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyBizDatabase.EntityFramework
{
    public class JourneyBizContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public void Seed()
        {
            User user1 = new User
            {
                Name = "User 1",
                Email = "user@test.com"
            };
            User user2 = new User
            {
                Name = "User 2",
                Email = "user2@test.com"
            };
        }

        public JourneyBizContext(DbContextOptions<JourneyBizContext> options) : base(options)
        {
        }
    }
}
