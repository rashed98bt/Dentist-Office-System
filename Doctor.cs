using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_SD
{
 
    class Doctor
    {
        string dr_name;
        int ID, start_day, end_day;
        Schedule s;
        public Doctor(string dr_name, int id,int sd, int ed, DateTime ex ,List<string> s)
        {
            this.Dr_name = dr_name;
            this.ID = id;
            this.start_day = sd;
            this.end_day = ed;
            //for (int i = 0; i < s.Count; i++)
            //{
            //    Console.WriteLine(s[i].ToString());
            //}
            this.s = new Schedule(sd, ed,ex,s);

        }

        public string Dr_name { get => dr_name; set => dr_name = value; }
        public int ID1 { get => ID; set => ID = value; }
        //public int ID2 { get => ID3; set => ID3 = value; }
        public int Start_day { get => start_day; set => start_day = value; }
        public int End_day { get => end_day; set => end_day = value; }
        

        public override string ToString()
        {
            return "dr name " + Dr_name + " DR id = " + ID1 + "start hour "+Start_day +" end day"+End_day + " s obj = "+ s.ToString();
        }

     
    }
}
