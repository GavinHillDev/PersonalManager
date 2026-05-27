using Microsoft.EntityFrameworkCore;
using PersonalManager.Data;
using PersonalManager.Models;
using PersonalManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace PersonalManager.ServiceLayer
{
    public class StudyItemServiceLayer
    {
        public static List<string> GetStudyItems()
        {
            using (var db = new AppDbContext())
            {
                var items = new List<StudyItem>();
                items = db.StudyItems.ToList();
                List<string> itemNames = new List<string>();
                for (int i = 0;  i < items.Count; i++)
                {
                    var item = items[i];
                    itemNames.Add(item.Name);
                }
                 
                return itemNames;
            }
        }
        public static async Task AddStudyItems(string subject)
        {
            
            using (var db = new AppDbContext())
            {
                var item = db.StudyItems.Where(s => s.Name == subject).FirstOrDefault(); //Search DB for Item
                System.Diagnostics.Debug.WriteLine(item);
                if (item == null)
                {
                     System.Diagnostics.Debug.WriteLine("Not in DB");
                        db.StudyItems.Add(new StudyItem
                        {
                            Name = subject
                        });
                        db.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("Added to DB");
                }
                if (item != null)
                {
                    if (item.Name == subject)
                    {
                        System.Diagnostics.Debug.WriteLine("Already in DB");
                    } else
                    {
                        System.Diagnostics.Debug.WriteLine("Now in DB");
                        db.StudyItems.Add(new StudyItem
                        {
                            Name = subject
                        });
                        db.SaveChanges();
                    }
                     
                }

            }
        }
    }
}
//using (var db = new AppDbContext())
//{
//    System.Diagnostics.Debug.WriteLine("In DB");
//    db.DailyTimes.Add(new DailyTime
//    {
//        Name = "Japanese Study",
//        Length = Int32.Parse(this._baseStudyTime),
//        Date = DateOnly.FromDateTime(DateTime.Now)

//    });
//    db.SaveChanges();
//    System.Diagnostics.Debug.WriteLine(db.DailyTimes.Count());
//}