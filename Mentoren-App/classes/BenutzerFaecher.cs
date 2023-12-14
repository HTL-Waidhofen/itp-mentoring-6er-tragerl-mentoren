using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Mentoren_App.classes
{
    internal class BenutzerFaecher : DbConnection
    {
        public int BenutzerID { get; set; }
        public int FachID { get; set; }

        public BenutzerFaecher(int benutzerID, int fachID)
        {
            this.BenutzerID = benutzerID;
            this.FachID = fachID;
        }

        public static void CreateBenutzerFach(int benutzerID, int fachID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO BenutzerFaecher (BenutzerID, FachID) VALUES (@BenutzerID, @FachID)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BenutzerID", benutzerID);
                    cmd.Parameters.AddWithValue("@FachID", fachID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<BenutzerFaecher> ReadAllBenutzerFaecher()
        {
            List<BenutzerFaecher> result = new List<BenutzerFaecher>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BenutzerFaecher";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int benutzerID = Convert.ToInt32(reader["BenutzerID"]);
                            int fachID = Convert.ToInt32(reader["FachID"]);
                            result.Add(new BenutzerFaecher(benutzerID, fachID));
                        }
                    }
                }
            }
            return result;
        }

        public static void DeleteBenutzerFach(int benutzerID, int fachID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM BenutzerFaecher WHERE BenutzerID = @BenutzerID AND FachID = @FachID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BenutzerID", benutzerID);
                    cmd.Parameters.AddWithValue("@FachID", fachID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
