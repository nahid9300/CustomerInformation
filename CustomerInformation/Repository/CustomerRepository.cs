using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInformation.Model;

namespace CustomerInformation.Repository
{
   public class CustomerRepository
    {
        public bool Insert(Customer customer)
        {
            bool isAdded=false;
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"INSERT INTO Customers(Code, Name,Address,Contact,DistrictId) Values ('" + customer.code + "', '" + customer.name + "', '" + customer.address + "', '" + customer.contact + "'," + customer.DistrictId + ")";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            int isExcuted= sqlCommand.ExecuteNonQuery();
            if (isExcuted > 0)
            {
                isAdded = true;
            }

            sqlConnection.Close();
            return isAdded;
        }

        public List<Customer> Display()
        {

            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; Database=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM CustomerDetailsView";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Show
            //With DataAdapter
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            //DataTable dataTable = new DataTable();
            //sqlDataAdapter.Fill(dataTable);

            //With DataAdapter
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Customer> Customer = new List<Customer>();

            while (sqlDataReader.Read())
            {
                Customer customer=new Customer();
                customer.code = sqlDataReader["Code"].ToString();
                customer.name = sqlDataReader["Name"].ToString();
                customer.address = sqlDataReader["Address"].ToString();
                customer.contact = sqlDataReader["Contact"].ToString();
                customer.DistrictId = Convert.ToInt32(sqlDataReader["DistrictId"].ToString());
                Customer.Add(customer);
            }

            //if (dataTable.Rows.Count > 0)
            //{

            //    //showDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    //MessageBox.Show("No Data Found");
            //}

            //Close
            sqlConnection.Close();
            //return dataTable;
            return Customer;

        }



        public DataTable Search(Customer customer)
        {
            DataTable dataTable = new DataTable();
           
            
                //Connection
                string connectionString = @"Server=DESKTOP-887J8ON; Database=CustomerInformation; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                //string commandString = @"SELECT * FROM Items WHERE Name='" + name + "'";
                string commandString = @"SELECT * FROM Customers WHERE Code='" + customer.code + "' OR Contact='"+customer.contact+"'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);


                //Close
                sqlConnection.Close();

            return dataTable;
        }

        public bool IsNameExists(Customer customer)
        {
            bool exists = false;
            
        
                //Connection
                string connectionString = @"Server=DESKTOP-887J8ON; Database=CustomerInformation; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Customers WHERE Code='" + customer + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                //Close
                sqlConnection.Close();

            return exists;
        }

        public DataTable ComboDisplay()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-887J8ON; DataBase=CustomerInformation; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //SELECT * FROM Items
            string commandString = @"SELECT * FROM DistrictInfo";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //    showDataGrid.DataSource = dataTable;
            //}
            //else
            //{
            //    showDataGrid.DataSource = null;
            //    MessageBox.Show("No Data Found");
            //}


            //Close
            sqlConnection.Close();
            return dataTable;
        }
    }
}
