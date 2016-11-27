using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace sqlite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            createAboutDatabase();
        }

        private void createAboutDatabase()
        {
            const string DataBaseFileName = @"D:\Documents_New_PC\Training\c#\sqlite\sqlite\localDB\SQLite\About.sqlite";
            File.Delete(DataBaseFileName);
            SQLiteConnection.CreateFile(DataBaseFileName);

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source="+DataBaseFileName+"; Version=3;");
            m_dbConnection.Open();

            //string sqlResuest = "CREATE TABLE friends(id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY, firstname VARCHAR(20), lastname VARCHAR(20), age INTEGER )";
            string sqlResuest = "CREATE TABLE friends(firstname VARCHAR(20), lastname VARCHAR(20), age INTEGER )";
            SQLiteCommand command = new SQLiteCommand(sqlResuest, m_dbConnection);
            command.ExecuteNonQuery();

            sqlResuest = "INSERT INTO friends (firstname, lastname,age ) values ('KADJI','Saddek', 31)";

            command = new SQLiteCommand(sqlResuest, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            const string filename = @"D:\Documents_New_PC\Training\c#\sqlite\sqlite\localDB\SQLite\About.sqlite";
            const string sql = "select * from friends;";
            var conn = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
            try
            {
                conn.Open();
                DataSet ds = new DataSet();
                var da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds);
                grid.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CreateDB_Click(object sender, EventArgs e)
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            string sql = "create table highscores (name varchar(20), score int)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('Me', 9001)";

            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();
        }
    }
}
