using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalManager.Models;
namespace PersonalManager.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<DailyTime> DailyTimes {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=app.db");
        }
    }
}
