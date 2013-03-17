using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Data;

namespace CustomUserControl{
    class DBce{
        private SqlCeConnection conn;

        public DBce(){
            init();
        }

        private void init(){
            string dataBase = "INTROSEDB";
            conn = new SqlCeConnection(@"Data Source=" + dataBase + ".sdf");
        }

        private bool Connect(){
            try{
                conn.Open();
                return true;
            }
            catch (SqlCeException ex){
                MessageBox.Show("Cannot connect to local database.");
                System.Console.WriteLine(ex.ToString());
                return false;
            }
        }
        private bool Disconnect(){
            try{
                conn.Close();
                return true;
            }
            catch (SqlCeException ex){
                MessageBox.Show("Database cannot be closed properly.");
                System.Console.WriteLine(ex.ToString());
                return false;
            }
        }

        // ExecuteNonQuery: Used to execute a command that will not return any data, for example Insert, update or delete.
        public void executeNonQuery(String command){
            if (Connect()){
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
                Disconnect();
            }
        }
        
        public void Insert(String query){
            executeNonQuery(query);
        }
        public void Update(String query){
            executeNonQuery(query);
        }
        public void Delete(String query){
            executeNonQuery(query);
        }


        // Not sure if we should use List <String>, alternatives include making use of 
        // the DataReader itself, the DataSet class or even ArrayList or something
        public List <string> [] Select(String query, int size){
            List< string >[] list = new List< string >[size];
         
            for(int i=0;i<size;++i)
                list[i] = new List< string >();

            if (Connect()){
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                
                SqlCeDataReader dataReader = cmd.ExecuteReader();
        
                while (dataReader.Read()){
                        for(int i=0;i<size;++i)
                            list[i].Add(dataReader[i] + "");
                }
                
                dataReader.Close();
                Disconnect();
                return list;
            }
            else
                return list;
        }


        // ExecuteScalar: Used to execute a command that will return only 1 value, for example Select Count(*).
        public int ExecuteScalar(String query){
            if (Connect()){
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                int num = int.Parse(cmd.ExecuteScalar()+"");
                Disconnect();
                return num;
            }
            else
                return -1;
        }

        public int Count(String query){
            return ExecuteScalar(query);
        }
        public int Max(String query){
            return ExecuteScalar(query);
        }
        public int Min(String query){
            return ExecuteScalar(query);
        }

    }
}

/*
            THESE ARE JUST RANDOM SCRAPS OF CODE
         
            conn = new SqlCeConnection(@"Data Source=|DataDirectory|\" + dataBase + ".sdf");
  
            public void ConnectListAndSaveSQLCompactExample()
            {
                // Create a connection to the file datafile.sdf in the program folder
                string dbfile = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName + "\\datafile.sdf";
                SqlCeConnection conn = new SqlCeConnection("datasource=" + dbfile);

                // Read all rows from the table test_table into a dataset (note, the adapter automatically opens the connection)
                SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from test_table", conn);
                DataSet data = new DataSet();
                adapter.Fill(data);

                // Add a row to the test_table (assume that table consists of a text column)
                data.Tables[0].Rows.Add(new object[] { "New row added by code" });

                // Save data back to the databasefile
                adapter.Update(data);

                // Close 
                conn.Close();
            }   
            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\NameDB.sdf");
            SqlCeCommand command = new SqlCeCommand("SELECT * FROM Names", conn);
            SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter(command);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            Console.WriteLine("Done");
          
        
            
  
  
            string query = "SELECT [Order ID], [Customer] FROM Orders";
            SqlCeConnection conn = new SqlCeConnection(connString);
            SqlCeCommand cmd = new SqlCeCommand(query, conn);

            conn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();

            try
            {
                // Iterate through the results
                //
                while (rdr.Read())
                {
                    int val1 = rdr.GetInt32(0);
                    string val2 = rdr.GetString(1);
    

            finally
            {
                // Always call Close when done reading
                //
                rdr.Close();

                // Always call Close when done reading
                //
                conn.Close();
 
        public List <string> [] Select(String query, int size){
            List< string >[] list = new List< string >[size];
            for(int i=0;i<size;++i)
                list[i] = new List< string >();

            if (OpenConnection()){
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
        
                while (dataReader.Read()){
                        for(int i=0;i<size;++i)
                            list[i].Add(dataReader[i] + "");
                }
                
                dataReader.Close();
                this.Disconnect();
                return list;
            }
            else
                return list;
       }
  
  
            private void FillList()
            {
                _list.BeginUpdate();
                _list.Items.Clear();

                for(int i =0 ; i <=9; i++)
                    _list.Items.Add(i);

                _list.EndUpdate();
            }

            private void _button_Click(object sender, System.EventArgs e)
            {
                _list.BeginUpdate();

                ListBox.ObjectCollection items = _list.Items;
                int count = items.Count;

                for(int i = 0; i < count; i++)
                {
                    int integerListItem = (int)items[i];
                    integerListItem ++;
                    // --- Update The Item
                    items[i] = integerListItem;
                }

                _list.EndUpdate();
            }*/