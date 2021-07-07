using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_SD
{
        
        
    public class Schedule
    {
        public List<string> days_of_work = new List<string>();
        int startTime , endTime;
        DateTime ep_date;
        //Weekday wd;
        Dictionary<int, List<string>> View_Scadual = new Dictionary<int, List<string>>();
        public Schedule(int start_w, int end_work, DateTime ep, List<string> s )
        {
            this.startTime = start_w;
            this.endTime = end_work;
            this.ep_date = ep;
            days_of_work = s;
            View_Scadual.Add(start_w, s);
            //print();
        }
      

        //public string dr_Check_appoitment(string hour , DateTime d) 
        //{
        //    int day = d.Date.Day;
        //    App_Day = Convert.ToDateTime( day);
        //    if (!Check_(hour)) 
        //    {
        //        workday.Add(hour);
        //        return "true";
        //    }
        //    else 
        //    {
        //        return "false";
        //    }
 
        //}
        //public bool Check_(string hour ) 
        //{
        //    if (workday.Count != 0)
        //    {
        //        for (int i = 0; i < workday.Count; i++)
        //        {
        //            if (hour != workday[i])
        //            {
        //                continue;
        //            }
        //            return true;
        //        }
        //    }

        //    return false;
        //}
        public override string ToString()
        {

           
            string dictionaryString = "{";
            foreach (KeyValuePair<int, List<string>> keyValues in View_Scadual)
            {
                dictionaryString += keyValues.Key + " : " + keyValues.Value + ", ";
            }
            return dictionaryString.TrimEnd(',', ' ') + "}";
        }
    }
}
