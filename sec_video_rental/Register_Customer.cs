using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sec_video_rental
{
    //inherit the database class to access the method of the database claess to perform he ddl dml queries on the databse 
   public class Register_Customer : DatabaseConnection
    {
        
        //pass the values from the register value to database 
        public void Reg_Customer(String Name,String Contact,String Email, String Address) {

            String qry= "insert into Register_Customer (Name,Contact,Email,Address) values('"+Name+"','"+Contact+"','"+Email+"','"+Address+"')";
            DMLQuery(qry);
            MessageBox.Show("Customer is Register in the Movie Store");

        }

        

        //pass the values from the delete value to database 
        public void Del_Customer(int id)
        {
            if (Count_Customer(id) == 0)
            {
                String qry = "delete from Register_Customer where id=" + id + "";
                DMLQuery(qry);
                MessageBox.Show("Customer is deleted from the Movie Store");
            }
            else {
                MessageBox.Show(" Return your Booked Video First ");
            }

        }

        //pass the values from the update value to database 
        public void Upd_Customer(int id, String Name, String Contact, String Email, String Address)
        {

            String qry = "update Register_Customer set Name='"+Name+"',Contact='"+Contact+"',Email='"+Email+"',Address='"+Address+"' where id="+id+"";
            DMLQuery(qry);
            MessageBox.Show("Customer record is edit  in the Movie Store");

        }

        //pass the values from the delete value to database 
        public int Count_Customer(int id)
        {
            String qry = "select * from Booked_Movie where C_Fk=" + id + "";
            DataTable tbl = new DataTable();
            tbl = FetchRecord(qry);
            return tbl.Rows.Count;

        }

    }
}
