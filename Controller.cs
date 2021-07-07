using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Final_Project_SD
{
    public partial class Controller : Form
    {
        int reminder_counter = 0;
        List<Patient> Patient_list = new List<Patient>();
        string path = Environment.CurrentDirectory;
        public Controller()
        {
            InitializeComponent();
            //reminder();
            
        }
      
        OpenFileDialog D1 = new OpenFileDialog();
        public void readPatient()
        {
            reminder_counter++;
            D1.Filter = "TEXTFILE|*.txt";
            if (D1.ShowDialog() == DialogResult.OK)
            {
                StreamReader R = new StreamReader(D1.FileName);
                string line = R.ReadToEnd();
                if (D1.FilterIndex == 1)
                {
                    //dataGridView1.DataSource = null;
                    string[] SplitedText = line.Split(new char[] { '\n',  ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < SplitedText.Length; i +=4)
                    {
                        Patient p1 = new Patient(SplitedText[i + 0],
                                                SplitedText[i + 1],
                                               SplitedText[i + 2],
                                               SplitedText[i+3]);

                        Patient_list.Add(p1);
                    }
                }
                printData();
                R.Close();
            }

        }

        private void regester_btn_Click(object sender, EventArgs e)
        {
            if (reminder_counter != 0)
            {
                try
                {
                    int ID = Convert.ToInt32(et_pid.Text.ToString());
                    int Phone = Convert.ToInt32(et_pPhone.Text.ToString());
                    
                    if (!Check(ID))
                    {
                        Patient p = new Patient(et_PatientName.Text, et_pid.Text, et_pPhone.Text,et_balance.Text);
                        Patient_list.Add(p);
                        //textBox1.Text = null;
                        dataGridView2.DataSource = null;
                        et_PatientName.Text = null;
                        et_pid.Text = null;
                        et_pPhone.Text = null;
                        et_balance.Text = null;
                        
                        printData();
                    }
              
                    else
                    {
                        MessageBox.Show("this is not valed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { reminder(); }  
        }

        public bool Check(int p_id)
        {
            if (Patient_list.Count != 0)
            {
                for (int i = 0; i < Patient_list.Count; i++)
                {
                    if( p_id == Convert.ToInt32(Patient_list[i].ID1)) 
                    {
                        return true;
                    }
                }
            }

            return false;
        }     
        private void SaveFile_btn_Click(object sender, EventArgs e)
        {
            if (reminder_counter != 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Txt|*.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter SW = new StreamWriter(save.FileName);
                    for (int i = 0; i < Patient_list.Count; i++)
                    {
                        SW.WriteLine(Patient_list[i].ToString());
                    }

                    SW.Close();
                }
            }
            else 
            {
                reminder();
            }
        }

        public void choser() 
        {
            if(tabControl1.SelectedTab == tabPage2) 
            {

            }
        }




        public void reminder() 
        {
            MessageBox.Show("Open Patient Folder First");
        }

        private void ReedFile_btn_Click(object sender, EventArgs e)
        {
            readPatient();
        }

        public void printData() 
        {
            //dataGridView2.DataSource = null;
             dataGridView2.DataSource = Patient_list;
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printData();
            //Console.WriteLine(Environment.CurrentDirectory+"\patients.txt");

            string filepath = Directory.GetCurrentDirectory();
        }
        List<string> arr = new List<string>();
        public void selcted_day() 
        {
            
            if (checkBox1.Checked)
            {
                arr.Add(checkBox1.Text);
            }
            if (checkBox2.Checked)
            {
                arr.Add(checkBox2.Text);
            }
            if (checkBox3.Checked)
            {
                arr.Add(checkBox3.Text);
            }
            if (checkBox4.Checked)
            {
                arr.Add(checkBox4.Text);
            }
            if (checkBox5.Checked)
            {
                arr.Add(checkBox5.Text);
            }
            if (checkBox6.Checked)
            {
                arr.Add(checkBox6.Text);
            }
            if (checkBox7.Checked)
            {
                arr.Add(checkBox7.Text);
            }

        }
        private void register_dr_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int d_id = Convert.ToInt32(et_doctor_id.Text.ToString());
                int start_hour = dateTimePicker_sday.Value.Hour ;
                int end_hour = dateTimePicker4_eday.Value.Hour ;
                

                if (Check_doctor(d_id) == false)
                {

                    selcted_day();
                    //foreach (string s in arr)
                    //{
                    //    Console.WriteLine(s.ToString() + " ");
                    //}
                    //Console.WriteLine("///////////////////////////////////");
                    
                    Doctor D = new Doctor(et_name_doctor.Text, d_id, start_hour, end_hour, dateTimePicker_doctor_ex.Value,arr);
                    Program.Doctor_list.Add(D);
                    arr.Clear();



                }
                else
                {
                    MessageBox.Show("The Doctor exsist");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void printdoctor() 
        {
            for (int j = 0; j < Program.Doctor_list.Count; j++) 
            {

                Console.WriteLine(Program.Doctor_list[j].ToString());
                Console.WriteLine("////////////////////////////////////");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //printdoctor();
            dataGridView_doctor.DataSource = Program.Doctor_list;
        }

        private void save_btn_appoitment_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32( textBox2.Text.ToString());
            try
            {
                if (Check(id))
                {
                    MessageBox.Show("exist");
                }
                //else
                //    MessageBox.Show("not exsist");
                //if (Check_date()) 
                //{
                //    Sa
                //}







            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool Check_date(string m , string d , string h) 
        {
            /*
            Doctor D = new Doctor();
            if (m == D.getM()) 
            {
                if (d == D.getday())
                {
                    if (h == D.gethour())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    
                }
                else
                {
                    return true;
                }
            }
            else 
            {
                return true;
            }*/
            return true;
        }

    
        private void refresh_Click(object sender, EventArgs e)
        {
            foreach (Doctor i in Program.Doctor_list)
            {
                comboBox4.Items.Add(i.Dr_name); 
            }
        }

        public bool Check_doctor(int p_id)
        {
            if (Program.Doctor_list.Count != 0)
            {
                for (int i = 0; i < Program.Doctor_list.Count; i++)
                {
                    if (p_id == Convert.ToInt32(Program.Doctor_list[i].ID1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void savedoctor_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Txt|*.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter SW = new StreamWriter(save.FileName);
                for (int i = 0; i < Program.Doctor_list.Count; i++)
                {
                    SW.WriteLine(Program.Doctor_list[i].ToString());
                }

                SW.Close();
            }
        }
    }
}
