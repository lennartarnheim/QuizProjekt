using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace QuizProjekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            ConnectroDB();
        }
        public void ConnectroDB()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=quiz_db;";
            
            string query = "SELECT * FROM fragen";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
       
                databaseConnection.Open();

                
                reader = commandDatabase.ExecuteReader();

               
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2) };
                        MessageBox.Show(row[1]);
                    }
                   
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

               
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
             
                MessageBox.Show(ex.Message);
            }
        }
    }
}
