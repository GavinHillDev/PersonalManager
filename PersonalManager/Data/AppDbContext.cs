using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalManager.Models;
using System.IO;
namespace PersonalManager.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<DailyTime> DailyTimes {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"app.db");
            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}
