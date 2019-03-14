using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    public class ManageFaciliteter : IManage<Faciliteter>
    {
        private const String GET_ALL = "SELECT * FROM Faciliteter";
        private const String GET_ONE = "SELECT * FROM Faciliteter WHERE Facilitet_Id = @ID";
        private const String DELETE = "DELETE FROM Faciliteter WHERE Facilitet_Id = @ID";
        private const String INSERT = "INSERT INTO Faciliteter VALUES (@ID, @Name)";
        private const String UPDATE = "UPDATE Faciliteter " +
                                      "SET Facilitet_Id = @ID, Name = @Name " +
                                      "WHERE Facilitet_Id = @ID";


        protected Faciliteter ReadNextElement(SqlDataReader reader)
        {
            Faciliteter faciliteter = new Faciliteter();

            faciliteter.FacilitetId = reader.GetInt32(0);
            faciliteter.Name = reader.GetString(1);
            

            return faciliteter;
        }


        public IEnumerable<Faciliteter> Get()
        {
            List<Faciliteter> liste = new List<Faciliteter>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Faciliteter faciliteter = ReadNextElement(reader);
                liste.Add(faciliteter);
            }
            reader.Close();

            return liste;
        }

        public Faciliteter Get(int id)
        {
            Faciliteter faciliteter = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                faciliteter = ReadNextElement(reader);
            }
            reader.Close();

            return faciliteter;
        }

        public bool Post(Faciliteter f)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", f.FacilitetId);
            cmd.Parameters.AddWithValue("@Name", f.Name);

            int noOfRows = 0;
            try
            {
                noOfRows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }

            return noOfRows == 1;
        }

        public bool Put(int id, Faciliteter f)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@Name", f.Name);
            cmd.Parameters.AddWithValue("@ID", f.FacilitetId);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

    }
}