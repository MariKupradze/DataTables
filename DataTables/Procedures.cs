using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace DataTables
{
    internal class Procedures
    {

        public static void Refresh(DataGridView dataGridView1)
        {
            dataGridView1.Rows.Clear();
            FileStream file = new FileStream("Persons.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(file);
            string current = reader.ReadLine();
            while (current != null)
            {
                string[] array = current.Split('\t');
                try
                {
                    dataGridView1.Rows.Add(array[1].Substring(4), array[2].Substring(6), array[3].Substring(9), array[4].Substring(4));
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                current = reader.ReadLine();
            }
            file.Close();
            reader.Close();

        }


        public static void Add(TextBox Name, TextBox Surname, TextBox Age)
        {
            FileStream file = new FileStream("Persons.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(file);
            StreamWriter writer = new StreamWriter(file);
            Random rnd = new Random();
            file.Seek(0, SeekOrigin.End);

            try
            {
                writer.WriteLine("\nProperties of this Person: \tID: " + Convert.ToString(rnd.Next(999, 10000)) + "\tName: " + Name.Text + "\tSurname: " + Surname.Text + "\tAge: " + Age.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            writer.Close();
            reader.Close();
            file.Close();

        }

        public static void Update(TextBox Id, TextBox Name, TextBox Surname, TextBox Age)
        {
            FileStream file = new FileStream("Persons.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(file);
            StreamWriter writer = new StreamWriter(file);
            bool b = false;
            string current = reader.ReadLine();
            int i = 0;

            while (current != null)
            {
                i++;
                string[] arr = current.Split('\t');
                if (Id.Text == arr[1].Substring(4))
                {
                    b = true;
                    break;
                }
                current = reader.ReadLine();
            }

            file.Seek(0, SeekOrigin.Begin);

            while (i != 0)
            {
                current = reader.ReadLine();
                i--;
            }
            writer.Write("\nProperties of this Person: \tID: " + Id.Text + "\tName: " + Name.Text + "\tSurname: " + Surname.Text + "\tAge: " + Age.Text);


            if (!b)
            {
                MessageBox.Show("ID not found");
                Update update = new Update();
                update.Show();
            }

            writer.Close();
            reader.Close();
            file.Close();

        }




        public static void Remove(TextBox Id)
        {
            FileStream file = new FileStream("Persons.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(file);
            StreamWriter writer = new StreamWriter(file);
            ArrayList f = new ArrayList();
            bool b = false;
            string current = reader.ReadLine();
            string[] arr = current.Split('\t');
            int i = 0;

            while (current != null)
            {
                arr = current.Split('\t');
                if (Id.Text != arr[1].Substring(4))
                {
                    f.Add(current);
                }

                else if (Id.Text == arr[1].Substring(4))
                {
                    b = true;

                }
                current = reader.ReadLine();

            }


            file.SetLength(0);

            for (i = 0; i < f.Count; i++)
            {
                writer.WriteLine(f[i]);
            }


            if (!b)
            {
                MessageBox.Show("ID not found");
                Remove remove = new Remove();
                remove.Show();
            }




            writer.Close();
            reader.Close();
            file.Close();
        }

    }
}
