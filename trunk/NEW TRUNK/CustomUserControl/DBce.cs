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