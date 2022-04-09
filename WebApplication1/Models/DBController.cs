using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DBController
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBController()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "webpatients";
            uid = "root";
            password = "mysqlpassword";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }


        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public void GetPatients()
        {
            string query = "SELECT * FROM PATIENTS";
            string Name = string.Empty;
            string nationalID = string.Empty;
            string DoB = string.Empty;
            string city = string.Empty;
            int id = 0;
            patient p = new patient();
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Name = dataReader["name"].ToString();
                    nationalID = dataReader["nationalID"].ToString();
                    city = dataReader["city"].ToString();
                    DoB = dataReader["birthdate"].ToString();
                    id = int.Parse(dataReader["id"].ToString()); 
                    p.Name = Name;
                    p.city = city;
                    p.nationalID = nationalID;
                    p.birthday = DateTime.Parse(DoB);
                    p.Id = id;
                    Console.WriteLine(Name + city + id + 'a');
                    GeneralController.patients.Add(p);
                }
                dataReader.Close();
                GeneralController.done();
            }

        }
        public void GetRecords()
        {
            string query = "SELECT * FROM RECORDS";
            int patientID = 0;
            string diagnosis = string.Empty;
            string DoB = string.Empty;
            int id = 0;
            record p = new record();
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    diagnosis = dataReader.GetString("diagnosis");
                    DoB = dataReader.GetString("dateOfDiagnosis");
                    id = dataReader.GetInt32("id");
                    patientID = dataReader.GetInt32("patientID");
                    p.patientID = patientID;
                    p.diagnosis = diagnosis;
                    p.birthday = DateTime.Parse(DoB);
                    p.Id = id;
                    GeneralController.records.Add(p);
                }
                dataReader.Close();
                GeneralController.doneRecords();
            }
        }
    }
}