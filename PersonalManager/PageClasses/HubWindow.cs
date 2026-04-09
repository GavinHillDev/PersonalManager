using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
 
namespace PersonalManager.PageClasses
{
    public class HubWindow
    {
       
        public static void returnDate(object block)
        {
            
            DateTime dateOnly = DateTime.Now;
            if (block is TextBox)
            {
                TextBox txt = block as TextBox;
                txt.Text = dateOnly.ToString();
            }

        }
        

    }
}
