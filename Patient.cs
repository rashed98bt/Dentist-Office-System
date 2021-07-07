using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_SD
{
    class Patient
    {
     
            string name;
            string ID;
            string Phone;
            string balance;
            double TotalPayed;
            string email;
            //DateTime Date;

            public Patient(string name, string ID, string Phone , string b)
            {
                this.Name = name;
                this.ID1 = ID;
                this.Phone1 = Phone;
                this.Balance = b;
                //this.Date1 = d;
            }

        public string Name { get => name; set => name = value; }
        public string ID1 { get => ID; set => ID = value; }
        public string Phone1 { get => Phone; set => Phone = value; }
        public string Balance { get => balance; set => balance = value; }
        public double TotalPayed1 { get => TotalPayed; set => TotalPayed = value; }
        public string Email { get => email; set => email = value; }
        //public DateTime Date1 { get => Date; set => Date = value; }

        public override string ToString()
            {
            return   Name+ "," + ID1+","  + Phone1 +","+balance;
            }

    }
}
