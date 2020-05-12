using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sec_video_rental
{
   public class Movie : DatabaseConnection
    {

        //pass the values from the register value to database 
        public void Reg_Movie(String Title, String Ratting, int Year,int Cost,int Copies, String Plot,String Genre)
        {

            String qry = "insert into Register_Movie (Title,Ratting,Year,Cost,Copies,Plot,Genre) values('" + Title+ "','" + Ratting + "'," + Year + "," + Cost+ ","+Copies+",'"+Plot+"','"+Genre+"')";
            DMLQuery(qry);
            MessageBox.Show("Movie is Register in the Movie Store");

        }


        public int getCost(int Year) {
            //we have use the concept of the Textchanged event to generate the charges of the cost 
                //dislay the cost of the price of the video after adding the year of the video
                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;

                int diffYear = Currentyear - Year;
                int cost = 0;
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;

                }
                return cost;
            
            

        }

        //pass the values from the delete value to database 
        public void Del_Movie(int id)
        {
            if (Count_Movie(id) == 0)
            {
                String qry = "delete from Register_Movie where id=" + id + "";
                DMLQuery(qry);
                MessageBox.Show("Movie is deleted from the Movie Store");
            }
            else
            {
                MessageBox.Show(" Return your Booked Video First ");
            }

        }

        //pass the values from the update value to database 
        public void Upd_Movie(int id, String Title, String Ratting, int Year, int Cost, int Copies, String Plot, String Genre)
        {

            String qry = "update  Register_Movie set Title='"+Title+"',Ratting='"+Ratting+"',Year="+Year+",Cost="+Cost+",Copies="+Copies+",Plot='"+Plot+"',Genre='"+Genre+"' where id="+id+"";
            DMLQuery(qry);
            MessageBox.Show("Movie record is edit  in the Movie Store");

        }

        //pass the values from the delete value to database 
        public int Count_Movie(int id)
        {
            String qry = "select * from Booked_Movie where M_Fk=" + id + "";
            DataTable tbl = new DataTable();
            tbl = FetchRecord(qry);
            return tbl.Rows.Count;

        }

    }
}
