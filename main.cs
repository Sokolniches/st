using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace курсовая123 //Гудзенко Полина 3Б
{
    public partial class Data_on_the_accounting_of_students_academic_performance  //Данные об учете успеваемости студентов
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = baza3.mdb";
            private OleDbConnection myConnection;
        private object dgIdamas;

        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e) //Подключение базы данных
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "baza3DataSet.baza3". При необходимости она может быть перемещена или удалена.
            this.baza3TableAdapter.Fill(this.baza3DataSet.baza3);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "baza2DataSet.baza2". При необходимости она может быть перемещена или удалена.
            this.baza3TableAdapter.Fill(this.baza3DataSet.baza3);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaDataSet.baza". При необходимости она может быть перемещена или удалена.
            this.bazaTableAdapter.Fill(this.bazaDataSet.baza);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaDataSet.baza". При необходимости она может быть перемещена или удалена.
            this.bazaTableAdapter.Fill(this.bazaDataSet.baza);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //Закрытие программы
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)                 // Октрытие второго окна 
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)                  // Обновление таблицы после добавления данных
        {
            this.baza3TableAdapter.Fill(this.baza3DataSet.baza3);
        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)        // Открытие третьей формы информации о разработчике
        {
            Form3 f3 = new Form3();
            f3.Owner = this;
            f3.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)               //Кнопка закрытия программы
        {
            Close();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();
        }

       // private void button4_Click(object sender, EventArgs e)
       // {
         //   Form4 f4 = new Form4();
           // f4.Owner = this;
           // f4.Show();
        //}

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.baza3TableAdapter.Fill(this.baza3DataSet.baza3);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //object contactsTableAdapter = null;
            //contactsTableAdapter.Update(baza2DataSet);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM baza3 WHERE [Студент] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о студенте удалены");
        }
    }
}
