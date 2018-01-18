using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace doctosCrud.Models
{
    public class CalvinDb
    {
        private const string host = "calvin.humber.ca";
        private const string port = "1521";
        private const string sid = "grok";
        private const string user = OracleLogin.username;
        private const string pass = OracleLogin.password;
        private static OracleConnection conn = new OracleConnection(OracleConnString(host, port, sid, user, pass));
        private string _message;

        private string connectionString { get { return OracleConnString(host, port, sid, user, pass); } }

        #region doctors
        public string Message
        {
            get { return _message; }
            set { this._message = value; }
        }

        public List<Doctor> Get()
        {
            List<Doctor> doctors = new List<Doctor>();
            OracleCommand cmd;
            OracleDataReader reader;

            string query;

            
            
            query = "SELECT * FROM doctors ORDER BY id ASC";
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();

            conn.Open();

            cmd = new OracleCommand(query, conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Doctor d = new Doctor(Convert.ToInt32(reader["id"]),
                    reader["doctor_name"].ToString(),
                    reader["specialization"].ToString(),
                    reader["doctor_resume"].ToString()
                    );
                doctors.Add(d);
            }

            cmd.Dispose();
            conn.Close();

            return doctors;
            
        }


        public void Add(Doctor doctor)
        {
            string command = "INSERT INTO " +
                "doctors VALUES(:id, :name, :special, :resume)";
            conn.Open();

            OracleCommand cmd = new OracleCommand(command, conn);
            cmd.Parameters.Add(new OracleParameter("id", doctor.Id));
            cmd.Parameters.Add(new OracleParameter("name", doctor.Name));
            cmd.Parameters.Add(new OracleParameter("special", doctor.Specialization));
            cmd.Parameters.Add(new OracleParameter("resume", doctor.Resume));

            int rows = cmd.ExecuteNonQuery();
            Message = Convert.ToString(rows) + " rows added to database";

            cmd.Dispose();
            conn.Close();
        }

        public void Update(Doctor doctor)
        {
            string command = "UPDATE doctors SET " +
                "doctor_name = :name, " +
                "specialization = :special, " +
                "doctor_resume = :resume " +
                "WHERE id = :id";

            conn.Open();
            OracleCommand cmd = new OracleCommand(command, conn);
            cmd.Parameters.Add(new OracleParameter("name", doctor.Name));
            cmd.Parameters.Add(new OracleParameter("special", doctor.Specialization));
            cmd.Parameters.Add(new OracleParameter("resume", doctor.Resume));
            cmd.Parameters.Add(new OracleParameter("id", doctor.Id));

            int rows = cmd.ExecuteNonQuery();
            Message = Convert.ToString(rows) + " rows updated in database";

            cmd.Dispose();
            conn.Close();
        }

        public void Delete(Doctor doctor)
        {
            string command = "DELETE FROM doctors WHERE id = :id";

            conn.Open();
            OracleCommand cmd = new OracleCommand(command, conn);
            cmd.Parameters.Add(new OracleParameter("id", doctor.Id));

            int rows = cmd.ExecuteNonQuery();
            Message = Convert.ToString(rows) + " rows deleted from database";

            cmd.Dispose();
            conn.Close();
        }

        #endregion

        #region users

        public User getUser(User user)
        {
            User u = null;
            OracleCommand cmd;
            OracleDataReader reader;

            string query;



            query = "SELECT * FROM users1 WHERE u_username = :username AND u_password = :password";
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();

            conn.Open();

            cmd = new OracleCommand(query, conn);
            cmd.Parameters.Add(new OracleParameter("username", user.Username));
            cmd.Parameters.Add(new OracleParameter("password", user.Password));
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                u = new User(Convert.ToInt32(reader["u_id"]),
                    reader["u_username"].ToString(),
                    reader["u_password"].ToString(),
                    reader["u_type"].ToString()
                    );
            }

            cmd.Dispose();
            conn.Close();

            return u;
        }

        #endregion

        public static string OracleConnString(string host, string port, string servicename, string user, string pass)
        {
            return String.Format(
              "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
              "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
              host,
              port,
              servicename,
              user,
              pass);
        }
        
    }

    
}