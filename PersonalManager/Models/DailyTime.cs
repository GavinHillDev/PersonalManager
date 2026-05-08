using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManager.Models
{
    public class DailyTime
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan Length { get; set; }

        public DateOnly Date {  get; set; }


    }
}
