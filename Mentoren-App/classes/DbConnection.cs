using System;
using System.Data.SqlClient;

public abstract class DbConnection
{
    public string ConnectionString = "Dein_Datenbank_Connection_String";

    // CREATE: Allgemeine Methode zum Hinzufügen von Daten
    public void CreateData(string query, SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }

    // READ: Allgemeine Methode zum Lesen von Daten
    public SqlDataReader ReadData(string query, SqlParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(ConnectionString);
        connection.Open();
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }

    // UPDATE: Allgemeine Methode zum Aktualisieren von Daten
    public void UpdateData(string query, SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }

    // DELETE: Allgemeine Methode zum Löschen von Daten
    public void DeleteData(string query, SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd.ExecuteNonQuery();
            }
        }
    }
}
