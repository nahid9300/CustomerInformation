using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerInformation.BLL;
using CustomerInformation.Model;

namespace CustomerInformation
{
    public partial class CustomerUI : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUI()
        {
            InitializeComponent();
            districtComboBox.DataSource = _customerManager.ComboDisplay();
            showDataGridView.DataSource = _customerManager.Display();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

            customer.code = codeTextBox.Text;
            if (_customerManager.IsNameExists(customer))
            {
                MessageBox.Show("Try a different Code");
                return;
            }

            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code cannot be empty");
                return;
            }

            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be in 4 character");
                return;
            }

            

            customer.name = nameTextBox.Text;
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("name cannot be empty");
                return;
            }

            customer.address = addressTextBox.Text;
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address cannot be empty");
                return;
            }

            customer.contact = contactTextBox.Text;
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact cannot be empty");
                return;
            }

            if (contactTextBox.Text.Length != 11)
            {
                MessageBox.Show("Enter valid number");
                return;
            }

            customer.DistrictId = Convert.ToInt32(districtComboBox.SelectedValue);        
            _customerManager.Insert(customer);
            showDataGridView.DataSource = _customerManager.Display();
            clear();
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.code = codeTextBox.Text;
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Enter the code or contact number  to search");
                return;
            }
            customer.contact = contactTextBox.Text;
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Enter the code or contact number  to search");
                return;
            }
            showDataGridView.DataSource = _customerManager.Search(customer);
            clear();

        }

        public void clear()
        {
            codeTextBox.Text = null;
            nameTextBox.Text = null;
            addressTextBox.Text = null;
            contactTextBox.Text = null;
        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells["serialNumber"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
