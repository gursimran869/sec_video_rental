using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sec_video_rental
{
    public partial class Form1 : Form
    {

        Register_Customer obj_Customer = new Register_Customer();

        Booked obj_Booked = new Booked();

        Movie Obj_Movie = new Movie();

        public int sec_RID = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void sec_addCustomer_Click(object sender, EventArgs e)
        {
            //get the form details fromt he customer section to store in the database 
            if (sec_TxtName.Text.ToString().Equals("") && sec_MobileNo.Text.ToString().Equals("") && sec_email.Text.ToString().Equals("") && sec_Address.Text.ToString().Equals(""))
            {
                MessageBox.Show("Fill all the necessary details to complete the form ");
            }
            else {
                obj_Customer.Reg_Customer(sec_TxtName.Text.ToString(), sec_MobileNo.Text.ToString(), sec_email.Text.ToString() , sec_Address.Text.ToString());
            
                sec_TxtName.Text = ""; sec_MobileNo.Text = ""; sec_email.Text=""; sec_Address.Text = "";
                sec_Txttitle.Text = ""; sec_TxtRatting.Text = ""; sec_TxtYear.Text = ""; sec_Txtcost.Text = ""; sec_TxtCopies.Text = ""; sec_TxtPlot.Text = ""; sec_TxtGenre.Text = "";
            }
        }

        private void sec_delCustomer_Click(object sender, EventArgs e)
        {
            // get the id to delete  the customer 
            if (sec_CustomerID.Text.ToString().Equals(""))
            {
                MessageBox.Show("Selection of Customer is not yet Completed ! ");
            }
            else {
                obj_Customer.Del_Customer(Convert.ToInt32(sec_CustomerID.Text.ToString()));

                sec_CustomerID.Text = "";
                sec_TxtName.Text = ""; sec_MobileNo.Text = ""; sec_email.Text = ""; sec_Address.Text = "";
                sec_Txttitle.Text = ""; sec_TxtRatting.Text = ""; sec_TxtYear.Text = ""; sec_Txtcost.Text = ""; sec_TxtCopies.Text = ""; sec_TxtPlot.Text = ""; sec_TxtGenre.Text = "";
            }

        }

        private void sec_updateCustomer_Click(object sender, EventArgs e)
        {
            //get the form details from the customer section to update  in the database 
            if (sec_CustomerID.Text.ToString().Equals("") && sec_TxtName.Text.ToString().Equals("") && sec_MobileNo.Text.ToString().Equals("") && sec_email.Text.ToString().Equals("") && sec_Address.Text.ToString().Equals(""))
            {
                MessageBox.Show("Fill all the necessary details to complete the form ");
            }
            else
            {
                obj_Customer.Upd_Customer(Convert.ToInt32(sec_CustomerID.Text.ToString()),sec_TxtName.Text.ToString(), sec_MobileNo.Text.ToString(), sec_email.Text.ToString(), sec_Address.Text.ToString());
                sec_CustomerID.Text = "";
                sec_TxtName.Text = ""; sec_MobileNo.Text = ""; sec_email.Text = ""; sec_Address.Text = "";
                sec_Txttitle.Text = ""; sec_TxtRatting.Text = ""; sec_TxtYear.Text = ""; sec_Txtcost.Text = ""; sec_TxtCopies.Text = ""; sec_TxtPlot.Text = ""; sec_TxtGenre.Text = "";
            }

        }

        private void sec_rentalIssueVideo_Click(object sender, EventArgs e)
        {
            if (sec_CustomerID.Text.ToString().Equals("") && sec_VideoID.Text.ToString().Equals(""))
            {
                MessageBox.Show("First select Movie and Customer to book a movie on rent ");
            }
            else {

                obj_Booked.Book_Movie(Convert.ToInt32(sec_CustomerID.Text.ToString()), Convert.ToInt32(sec_VideoID.Text.ToString()),sec_IssueVideo.Text);
            
                sec_CustomerID.Text = "";
                sec_VideoID.Text = "";

                sec_TxtName.Text = ""; sec_MobileNo.Text = ""; sec_email.Text = ""; sec_Address.Text = "";

                sec_Txttitle.Text = ""; sec_TxtRatting.Text = ""; sec_TxtYear.Text = ""; sec_Txtcost.Text = ""; sec_TxtCopies.Text = ""; sec_TxtPlot.Text = ""; sec_TxtGenre.Text = "";
            }
        }

        private void sec_rentalReturnVideo_Click(object sender, EventArgs e)
        {
            if (sec_RID == 0)
            {
                MessageBox.Show("First Select the Booked Movie to return the movie  ");
            }
            else
            {



                obj_Booked.Return_Movie(sec_RID,Convert.ToInt32(sec_CustomerID.Text.ToString()), Convert.ToInt32(sec_VideoID.Text.ToString()), sec_IssueVideo.Text,sec_ReturnVideo.Text);
               
                sec_CustomerID.Text = "";
                sec_VideoID.Text = "";

                sec_TxtName.Text = ""; sec_MobileNo.Text = ""; sec_email.Text = ""; sec_Address.Text = "";

                sec_Txttitle.Text = ""; sec_TxtRatting.Text = ""; sec_TxtYear.Text = ""; sec_Txtcost.Text = ""; sec_TxtCopies.Text = ""; sec_TxtPlot.Text = ""; sec_TxtGenre.Text = "";
                sec_RID = 0;
                
            }

        }

            private void sec_rentalVideoDelete_Click(object sender, EventArgs e)
        {
            if (sec_RID == 0)
            {
                MessageBox.Show("First Select the Booked Movie to del ");
            }
            else {
                obj_Booked.Del_Movie(sec_RID);
                

                sec_CustomerID.Text = "";
                sec_VideoID.Text = "";

                sec_TxtName.Text = ""; sec_MobileNo.Text = ""; sec_email.Text = ""; sec_Address.Text = "";

                sec_Txttitle.Text = ""; sec_TxtRatting.Text = ""; sec_TxtYear.Text = ""; sec_Txtcost.Text = ""; sec_TxtCopies.Text = ""; sec_TxtPlot.Text = ""; sec_TxtGenre.Text = "";
                sec_RID = 0;
            }
        }

        private void Sec_AddVideo_Click(object sender, EventArgs e)
        {
            if (sec_Txttitle.Text.ToString().Equals("") && sec_TxtRatting.Text.ToString().Equals("") && sec_TxtYear.Text.ToString().Equals("") && sec_Txtcost.Text.ToString().Equals("") && sec_TxtCopies.Text.ToString().Equals("") && sec_TxtPlot.Text.ToString().Equals("") && sec_TxtGenre.Text.ToString().Equals("")) {
                MessageBox.Show("Must fill all the details to store the Movie ");
            }
            else {

                Obj_Movie.Reg_Movie(sec_Txttitle.Text.ToString(), sec_TxtRatting.Text.ToString(),Convert.ToInt32(sec_TxtYear.Text.ToString()), Convert.ToInt32(sec_Txtcost.Text.ToString()), Convert.ToInt32(sec_TxtCopies.Text.ToString()), sec_TxtPlot.Text.ToString() ,sec_TxtGenre.Text.ToString());
            
                sec_Txttitle.Text=""; sec_TxtRatting.Text = ""; sec_TxtYear.Text=""; sec_Txtcost.Text=""; sec_TxtCopies.Text = ""; sec_TxtPlot.Text=""; sec_TxtGenre.Text = "";

            }

        }

        private void sec_delVideo_Click(object sender, EventArgs e)
        {
            if (sec_VideoID.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select the Movie to  delete ");
            }
            else {
                Obj_Movie.Del_Movie(Convert.ToInt32(sec_VideoID.Text.ToString()));

                sec_Txttitle.Text = ""; sec_TxtRatting.Text = ""; sec_TxtYear.Text = ""; sec_Txtcost.Text = ""; sec_TxtCopies.Text = ""; sec_TxtPlot.Text = ""; sec_TxtGenre.Text = "";
                sec_VideoID.Text = "";
            }

        }

        private void sec_updateVideo_Click(object sender, EventArgs e)
        {
            if (sec_VideoID.Text.ToString().Equals("") && sec_Txttitle.Text.ToString().Equals("") && sec_TxtRatting.Text.ToString().Equals("") && sec_TxtYear.Text.ToString().Equals("") && sec_Txtcost.Text.ToString().Equals("") && sec_TxtCopies.Text.ToString().Equals("") && sec_TxtPlot.Text.ToString().Equals("") && sec_TxtGenre.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select the Movie to  delete ");
            }
            else
            {
                Obj_Movie.Upd_Movie(Convert.ToInt32(sec_VideoID.Text.ToString()), sec_Txttitle.Text.ToString(), sec_TxtRatting.Text.ToString(), Convert.ToInt32(sec_TxtYear.Text.ToString()), Convert.ToInt32(sec_Txtcost.Text.ToString()), Convert.ToInt32(sec_TxtCopies.Text.ToString()), sec_TxtPlot.Text.ToString(), sec_TxtGenre.Text.ToString());

                sec_Txttitle.Text = ""; sec_TxtRatting.Text = ""; sec_TxtYear.Text = ""; sec_Txtcost.Text = ""; sec_TxtCopies.Text = ""; sec_TxtPlot.Text = ""; sec_TxtGenre.Text = "";
                sec_VideoID.Text = "";

            }

        }

        private void sec_TxtYear_TextChanged(object sender, EventArgs e)
        {
            try {
                //get the cost of the movie 
                int cost = Obj_Movie.getCost(Convert.ToInt32(sec_TxtYear.Text.ToString()));
                sec_Txtcost.Text = "" + cost;
            }
            catch (Exception ex) {

            }  
            
        }

        private void sec_Customer_CheckedChanged(object sender, EventArgs e)
        {
            if (sec_Customer.Checked==true) {

                DataTable tbl = new DataTable();
                tbl = obj_Customer.FetchRecord("select * from Register_Customer");
                Record.DataSource = tbl;
            }

        }

        private void sec_Video_CheckedChanged(object sender, EventArgs e)
        {

            if (sec_Video.Checked == true)
            {

                DataTable tbl = new DataTable();
                tbl = Obj_Movie.FetchRecord("select * from Register_Movie");
                Record.DataSource = tbl;
            }

        }

        private void sec_Rent_CheckedChanged(object sender, EventArgs e)
        {

            if (sec_Rent.Checked == true)
            {

                DataTable tbl = new DataTable();
                tbl = obj_Booked.FetchRecord("select * from Booked_Movie");
                Record.DataSource = tbl;
            }

        }

        private void Record_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sec_Rent.Checked==true) {

                sec_RID = Convert.ToInt32(Record.CurrentRow.Cells[0].Value.ToString());
                sec_CustomerID.Text= Record.CurrentRow.Cells[1].Value.ToString();
                sec_VideoID.Text = Record.CurrentRow.Cells[2].Value.ToString();
                sec_IssueVideo.Text = Record.CurrentRow.Cells[3].Value.ToString();
            }

            if (sec_Video.Checked==true) {

                sec_VideoID.Text=Record.CurrentRow.Cells[0].Value.ToString();
                sec_Txttitle.Text= Record.CurrentRow.Cells[1].Value.ToString();
                sec_TxtRatting.Text = Record.CurrentRow.Cells[2].Value.ToString();
                sec_TxtYear.Text= Record.CurrentRow.Cells[3].Value.ToString();
                sec_Txtcost.Text= Record.CurrentRow.Cells[4].Value.ToString();
                sec_TxtCopies.Text= Record.CurrentRow.Cells[5].Value.ToString();
                sec_TxtPlot.Text= Record.CurrentRow.Cells[6].Value.ToString();
                sec_TxtGenre.Text= Record.CurrentRow.Cells[7].Value.ToString();
            }


            if (sec_Customer.Checked==true){
                sec_CustomerID.Text = Record.CurrentRow.Cells[0].Value.ToString();

                sec_TxtName.Text = Record.CurrentRow.Cells[1].Value.ToString();

                sec_MobileNo.Text = Record.CurrentRow.Cells[2].Value.ToString();

                sec_email.Text = Record.CurrentRow.Cells[3].Value.ToString();

                sec_Address.Text = Record.CurrentRow.Cells[4].Value.ToString();
            }

            sec_Customer.Checked = false;
            sec_Video.Checked = false;
            sec_Rent.Checked = false;

        }

        private void sec_best_video_Click(object sender, EventArgs e)
        {
            DataTable tblData = new DataTable();
            tblData =Obj_Movie.FetchRecord("select * from Register_Movie");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = Obj_Movie.FetchRecord("select * from Booked_Movie where M_Fk=" + Convert.ToInt32(tblData.Rows[x]["id"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["Title"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show("Most Booked Movie Title is :" + Title);

        }

        private void sec_best_custo_Click(object sender, EventArgs e)
        {

            DataTable tblData = new DataTable();
            tblData = Obj_Movie.FetchRecord("select * from Register_Customer");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = Obj_Movie.FetchRecord("select * from Booked_Movie where C_Fk=" + Convert.ToInt32(tblData.Rows[x]["id"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["Name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            MessageBox.Show("Most Movies Booked By Cusotmer  :" + Title);


        }
    }
}
