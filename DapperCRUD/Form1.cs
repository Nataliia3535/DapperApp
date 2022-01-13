using DapperRepository;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperCRUD
{

    public partial class Form1 : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
         IDbConnection dbConnection;


        public Form1()
        {
            InitializeComponent();
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connection = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            GenericUnitOfWork work = new GenericUnitOfWork(connection);
            IGenericRepository<Product> repositoryProduct = work.Repository<Product>();
            dataGridView1.DataSource= repositoryProduct.GetAll().ToList();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenericUnitOfWork work = new GenericUnitOfWork(connection);
            IGenericRepository<Product> repositoryProduct = work.Repository<Product>();
            repositoryProduct.Add(new Product() { Id = Convert.ToInt32(textBox1.Text), Title = textBox2.Text, Price = Convert.ToDouble(textBox3.Text) });
            dataGridView1.DataSource = repositoryProduct.GetAll().ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                GenericUnitOfWork work = new GenericUnitOfWork(connection);
                IGenericRepository<Product> repositoryProduct = work.Repository<Product>();
                Product product = repositoryProduct.FindById(id);
                repositoryProduct.Remove(id);
                dataGridView1.DataSource = repositoryProduct.GetAll().ToList();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            if (converted == false)
                return;
            GenericUnitOfWork work = new GenericUnitOfWork(connection);
            IGenericRepository<Product> repositoryProduct = work.Repository<Product>();
            Product product = repositoryProduct.FindById(id);
            Form2 form2 = new Form2();
            form2.textBox1.Text = product.Id.ToString();
            form2.textBox2.Text = product.Title.ToString();
            form2.textBox3.Text = product.Price.ToString();
            DialogResult dialog = form2.ShowDialog(this);

            product.Id = Convert.ToInt32(form2.textBox1.Text);
            product.Title = form2.textBox2.Text;
            product.Price = Convert.ToDouble(form2.textBox3.Text);
            repositoryProduct.Update(product);
            dataGridView1.DataSource = repositoryProduct.GetAll().ToList();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
