using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sec_video_rental
{
   public class Booked : DatabaseConnection
    {

        //pass the values from the register value to database 
        public void Book_Movie(int C_Fk,int M_Fk,String BookingDate)
        {

            if (getMovieBooked(M_Fk) < getCopies(M_Fk))
            {
                if (getCustomerBooked(C_Fk) < 2)
                {

                    String qry = "insert into Booked_Movie (C_Fk,M_Fk,BookingDate,ReturnDate) values(" + C_Fk + "," + M_Fk + ",'" + BookingDate + "','1')";
                    DMLQuery(qry);
                    MessageBox.Show("Movie is booked by the Customer ");

                }
                else {
                    MessageBox.Show("Sorry! You already have booked 2 movie on rent ");
                }

            }
            else
            {
                MessageBox.Show("All Movie is issued on Rent ");

            }

        }



        public int getCopies(int M_Fk) {
            String qry = "select * from Register_Movie where id="+M_Fk+"";
            DataTable tbl = new DataTable();
            tbl = FetchRecord(qry);
            return tbl.Rows.Count;
        }

    // check how much mmovie is booked yet 
        public int getMovieBooked(int M_Fk)
        {
            String qry = "select * from Booked_Movie where M_Fk=" + M_Fk + " and ReturnDate='1'";
            DataTable tbl = new DataTable();
            tbl = FetchRecord(qry);
            return tbl.Rows.Count;
        }


        // check how much mmovie is booked yet 
        public int getCustomerBooked(int C_Fk)
        {
            String qry = "select * from Booked_Movie where C_Fk=" + C_Fk + " and ReturnDate='1'";
            DataTable tbl = new DataTable();
            tbl = FetchRecord(qry);
            return tbl.Rows.Count;
        }



        //pass the values from the delete value to database 
        public void Del_Movie(int id)
        {
              String qry = "delete from Booked_Movie where id=" + id + "";
                DMLQuery(qry);
                MessageBox.Show("Movie is deleted from Booked Movie Details ");
           
        }


        public int getCost(int M_Fk)
        {
            String qry = "select * from Register_Movie where id=" + M_Fk + "";
            DataTable tbl = new DataTable();
            tbl = FetchRecord(qry);
            return Convert.ToInt32(tbl.Rows[0]["Cost"].ToString());
        }



        //pass the values from the update value to database 
        public void Return_Movie(int id, int C_Fk, int M_Fk, String BookingDate,String ReturnDate)
        {

            DateTime new_date = DateTime.Now;


           
            //convert the old date from string to Date fromat
            DateTime prev_date = Convert.ToDateTime(BookingDate);


            //get the difference in the days fromat
            String Daysdiff = (new_date - prev_date).TotalDays.ToString();


            // calculate the round off value 
            Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));

            int cost=getCost(M_Fk);



            int Charges= Convert.ToInt32(DaysInterval) * cost;



            



            String qry = "update  Booked_Movie set C_Fk=" + C_Fk + ",M_Fk=" + M_Fk + ",BookingDate='"+BookingDate+"',ReturnDate='"+ReturnDate+"' where id=" + id + "";
            DMLQuery(qry);
            MessageBox.Show("Movie is return to the store and Charges is :"+ Charges);

        }


    }
}
