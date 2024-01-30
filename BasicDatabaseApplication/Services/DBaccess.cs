using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDatabaseApplication.Services
{
    class DBaccess
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BasicDatabaseApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connectionStringMaster = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        bool added = false;

        public int countID()
        {
            string sqlCountStatement = "SELECT COUNT (*) FROM [dbo].[NameTable];";
            using (SqlConnection countConnection = new SqlConnection(connectionString))
            {
                int count = 0;
                SqlCommand countComm = new SqlCommand(sqlCountStatement, countConnection);
                try
                {
                    countConnection.Open();

                    count = (int)countComm.ExecuteScalar();

                }
                catch (Exception e)
                { Console.WriteLine(e); }
                return count;

            }

        }

        public bool addData(string name, string password, string emailaddr)
        {
            string sqlStatement = "Insert into dbo.NameTable (Id, Name, Password, email) VALUES (@id, @name, @password, @email); EXEC sp_executesql @dataname;";

            string dbname = name + "db";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = countID() + 1;
                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 50).Value = name;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = password;
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 50).Value = emailaddr;
                command.Parameters.Add("@dataname", System.Data.SqlDbType.NVarChar).Value = "CREATE DATABASE " + dbname + ";";
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    added = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return added;


            }


        }

        public bool checkUser(string name, string password)
        {
            string userStatement = "SELECT [Id] FROM [dbo].[NameTable] WHERE Name = @username and Password = @password;";
            string deleteCurrentUser = "TRUNCATE TABLE [dbo].[currentUser];";
            string saveCurrentUser = "INSERT INTO [dbo].[currentUser] (Id, Name) VALUES (@Id, @username); ";
            using (SqlConnection userConn = new SqlConnection(connectionString))
            {
                bool validuser = false;
                SqlCommand userCommand = new SqlCommand(userStatement, userConn);
                SqlCommand deleteCommand = new SqlCommand(deleteCurrentUser, userConn);
                SqlCommand saveCommand = new SqlCommand(saveCurrentUser, userConn);
                userCommand.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 50).Value = name;
                userCommand.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = password;

                try
                {
                    userConn.Open();
                    int currentID = Convert.ToInt32(userCommand.ExecuteScalar());
                    if (currentID != 0)
                    {

                        deleteCommand.ExecuteNonQuery();
                        saveCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = currentID;
                        saveCommand.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 50).Value = name;
                        saveCommand.ExecuteNonQuery();
                        validuser = true;

                    }

                }
                catch (Exception e)
                { Console.WriteLine(e); }

                return validuser;

            }

        }

        public string getUserId()
        {
            string sqlStatement = "SELECT ID from dbo.CurrentUser;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                string userID = "novalue";
                if (reader.Read())
                {

                    userID = Convert.ToString(reader.GetInt32(0));
                    reader.Close();


                }
                return userID;

            }

        }

        public bool createDB(string tableName, string colOne, string colTwo, string colThree, string colFour, string colFive, string col1type, string col2type, string col3type, string col4type, string col5type)

        {
            bool created = false;

            string fullTableName = tableName + getUserId();
            string parameter1 = colOne + parameterString(col1type);
            string parameter2 = colTwo + parameterString(col2type);
            string parameter3 = colThree + parameterString(col3type);
            string parameter4 = colFour + parameterString(col4type);
            string parameter5 = colFive + parameterString(col5type);

            string sqlStatement = "CREATE TABLE " + fullTableName + " (" + parameter1 + parameter2 + parameter3 + parameter4 + parameter5 + "PRIMARY KEY(" + colOne + "));";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@tableName", System.Data.SqlDbType.VarChar).Value = "testTable";
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }




            return created;

        }

        public bool addDBData(string tableName, string colOne, string colTwo, string colThree, string colFour, string colFive, string col1Val, string col2Val, string col3Val, string col4Val, string col5Val)
        {
            bool added = false;
            string fullTableName = tableName + getUserId();

            string sqlStatement = "INSERT INTO " + fullTableName + " (" + colOne + ", " + colTwo + ", " + colThree + ", " + colFour + ", " + colFive + ") VALUES ( @col1Val, @col2Val, @col3Val, @col4Val, @col5Val)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@col1Val", System.Data.SqlDbType.Int).Value = Convert.ToInt32(col1Val);
                command.Parameters.Add("@col2Val", System.Data.SqlDbType.VarChar).Value = col2Val;
                command.Parameters.Add("@col3Val", System.Data.SqlDbType.VarChar).Value = col3Val;
                command.Parameters.Add("@col4Val", System.Data.SqlDbType.VarChar).Value = col4Val;
                command.Parameters.Add("@col5Val", System.Data.SqlDbType.VarChar).Value = col5Val;


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                added = true;
                return added;
            }

            return added;
        }

        public bool signUserOut()
        {
            bool deleted = false;

            string sqlStatement = "TRUNCATE TABLE [dbo].[currentUser];"; ;
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e) { Console.WriteLine(e); }


            }


            return deleted;
        }

        public string parameterString(string value)
        {
            string output;
            if (value == "Integer")
            { output = " Int, "; return output; }
            else if (value == "Text")
            { output = " VarChar(255), "; return output; }
            else if (value == "Date/Time")
            { output = " datetime, "; return output; }
            else { output = "null"; return output; }
        }

        public List<string> currentUserDBList()
        {
            String SqlStatement = "SELECT table_name FROM INFORMATION_SCHEMA.TABLES WHERE table_name LIKE '%" + getUserId() + "'";
            String CountStatement = "SELECT COUNT(table_name) FROM INFORMATION_SCHEMA.TABLES WHERE table_name LIKE '%" + getUserId() + "';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SqlStatement, connection);
                SqlCommand countComm = new SqlCommand(CountStatement, connection);
                connection.Open();
                int count = (int)countComm.ExecuteScalar();
                SqlDataReader reader = command.ExecuteReader();
                List<string> currentDBList = new List<string>();

                while (reader.Read())
                {

                    try
                    {
                        for (int i = 0; i < count; i++)
                        {
                            currentDBList.Add(reader.GetString(i).Replace(getUserId(), string.Empty));
                            if (i == count)
                            { return currentDBList; }
                        }

                    }
                    catch (Exception e) { Console.WriteLine(e); }
                }
                connection.Close();



                return currentDBList;
            }
        }

        public string getUserName()
        {
            string output = "";
            string SqlStatement = "SELECT Name FROM dbo.currentUser WHERE Id='" + getUserId() + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        output = reader.GetString(0);
                        connection.Close();
                        return output;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return output;
        }

        public DataTable ViewTableData(string tablename)
        {
            DataTable currentData = new DataTable(tablename);

            string currentTable = tablename + getUserId();
            string sqlStatement = "select * from dbo." + currentTable + ";";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(currentData);
                return currentData;



            }



        }
        public bool deleteAllData()
        {
            bool deleted = false;



            return deleted;

        }

        public bool intializeDataBase()
        {
            bool initialized = false;

            string SqlStatement = File.ReadAllText(@"L:\Project\BasicDatabaseApplication\BasicDatabaseApplication\dbInitializationScript.txt");
           
            using (SqlConnection connection = new SqlConnection(connectionStringMaster))
            {
                SqlCommand command = new SqlCommand(SqlStatement, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                
            }

            return initialized;
        
        }
        public bool editDBEntry(string tablename, string colOne, string colTwo, string colThree, string colFour, string colFive, string col1Val, string col2Val, string col3Val, string col4Val, string col5Val)
        {
            bool edited = false;
            string currentTable = tablename + getUserId();
            string sqlStatement = "UPDATE " + currentTable + " SET " + colOne + " = " + col1Val + ", " + colTwo + " = '" + col2Val + "', " + colThree + " = '" + col3Val + "', " + colFour + " = '" + col4Val + "', " + colFive + " = '" + col5Val + "' WHERE " + colOne + " = " + col1Val + ";";


        using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    added = true;
                    return added;
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                
                }

            }


            return edited;
        
        }

        public bool deleteSingleItem(string tablename, string colOne, string col1val)
        {
            bool deleted = false;

            string currentTable = tablename + getUserId();
            string sqlStatement = "DELETE FROM " + currentTable + " WHERE " + colOne + " = " + col1val ;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sqlStatement, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    deleted = true;
                    return deleted;
                }
            }
            catch (Exception r)
            { Console.WriteLine(r);
                return deleted;
            }
        
        }
    }
}
