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
            // This is the query which will create a new table in our database file with three columns. An auto increment column called "ID", and two NVARCHAR type columns with the names "Key" and "Value"
            string createTableQuery = @"CREATE TABLE IF NOT EXISTS [MyTable] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [Key] NVARCHAR(2048)  NULL,
                          [Value] VARCHAR(2048)  NULL
                          )";

            System.Data.SQLite.SQLiteConnection.CreateFile("databaseFile.db3");        // Create the file which will be hosting our database
            using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=databaseFile.db3"))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(con))
                {
                    con.Open();                             // Open the connection to the database

                    com.CommandText = createTableQuery;     // Set CommandText to our query that will create the table
                    com.ExecuteNonQuery();                  // Execute the query

                    com.CommandText = "INSERT INTO MyTable (Key,Value) Values ('key one','value one')";     // Add the first entry into our database 
                    com.ExecuteNonQuery();      // Execute the query
                    com.CommandText = "INSERT INTO MyTable (Key,Value) Values ('key two','value value')";   // Add another entry into our database 
                    com.ExecuteNonQuery();      // Execute the query

                    com.CommandText = "Select * FROM MyTable";      // Select all rows from our database table

                    using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Key"] + " : " + reader["Value"]);     // Display the value of the key and value column for every row
                        }
                    }
                    con.Close();        // Close the connection to the database
                }
            }
        }

        private void createAboutDatabase()
        {
            const string DataBaseFileName = @"D:\Documents_New_PC\Training\c#\sqlite\sqlite\localDB\SQLite\About.sqlite";
            File.Delete(DataBaseFileName);
            SQLiteConnection.CreateFile(DataBaseFileName);

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source="+DataBaseFileName+"; Version=3;");
            m_dbConnection.Open();

            string tableName = "friends";

            string createTableQuery = string.Format(@"CREATE TABLE IF NOT EXISTS [{0}] (
                                                                      [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                                                      firstname VARCHAR(30),
                                                                      lastname VARCHAR(30),
                                                                      Age INTEGER 
                                                                      )",tableName);

            string requestNameToUse = "createTableQuery";

            //string sqlResuest = "CREATE TABLE friends(id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY, firstname VARCHAR(20), lastname VARCHAR(20), age INTEGER )";
            //string sqlResuest = "CREATE TABLE friends(firstname VARCHAR(20), lastname VARCHAR(20), age INTEGER )";
            SQLiteCommand command = new SQLiteCommand(createTableQuery, m_dbConnection);
            command.ExecuteNonQuery();

            
            string sqlInsertIntoResuest = string.Format(@"INSERT INTO {0} (firstname, lastname,age ) values ('KADJI','Saddek', 31)",tableName);
            command = new SQLiteCommand(sqlInsertIntoResuest, m_dbConnection);
            command.ExecuteNonQuery();
            sqlInsertIntoResuest = string.Format(@"INSERT INTO {0} (firstname, lastname,age ) values ('KADJI','Mohand', 31)",tableName);
            command = new SQLiteCommand(sqlInsertIntoResuest, m_dbConnection);
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

        private void dbDescription_Click(object sender, EventArgs e)
        {
            const string filename = @"D:\Documents_New_PC\Training\c#\sqlite\sqlite\localDB\SQLite\About.sqlite";
            const string sql = "DESCRIBE friends;";
            var conn = new SQLiteConnection("Data Source=" + filename + ";Version=3;");
            try
            {
                conn.Open();
                DataSet ds = new DataSet();
                var da = new SQLiteDataAdapter(sql, conn);
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
