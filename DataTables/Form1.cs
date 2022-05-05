using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTables
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Surname", "Surname");
            dataGridView1.Columns.Add("Age", "Age");

            Procedures.Refresh(dataGridView1);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add form3 = new Add();
            form3.ShowDialog();
        }
        
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Procedures.Refresh(dataGridView1);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            

            Remove fRemove = new Remove();
            fRemove.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Update form4 = new Update();
            form4.ShowDialog();
        }
    }
}
