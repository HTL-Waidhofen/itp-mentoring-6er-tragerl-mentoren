using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

public class Benutzer : DbConnection
{
    public int ID { get; }
    public string Vorname { get; }
    public string Nachname { get; }
    public string Role { get; set; }
    public string Email { get; set; }
    private string Passwort { get; set; }

    public override string ToString()
    {
        return Vorname + " " + Nachname + ", Email: " + Email;
    }

    public Benutzer(int id, string vorname, string nachname, string role, string email, string passwort)
    {
        this.ID = id;
        this.Vorname = vorname;
        this.Nachname = nachname;
        this.Role = role;
        this.Email = email;
        this.Passwort = passwort;
    }

    public static void CreateBenutzer(string vorname, string nachname, string role, string email, string passwort)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Benutzer (Vorname, Nachname, Rolle, Email, Passwort) VALUES (@Vorname, @Nachname, @Role, @Email, @Passwort)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Vorname", vorname);
                cmd.Parameters.AddWithValue("@Nachname", nachname);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Passwort", passwort);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static Benutzer ReadBenutzerByID(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Benutzer WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Benutzer(
                            Convert.ToInt32(reader["ID"]),
                            Convert.ToString(reader["Vorname"]),
                            Convert.ToString(reader["Nachname"]),
                            Convert.ToString(reader["Rolle"]),
                            Convert.ToString(reader["Email"]),
                            Convert.ToString(reader["Passwort"])
                        );
                    }
                }
            }
        }
        return null;
    }

    public void UpdateBenutzerEmail(string neueEmail)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE Benutzer SET Email = @NeueEmail WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@NeueEmail", neueEmail);
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteBenutzer()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Benutzer WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ID", this.ID);
                cmd.ExecuteNonQuery();
            }
        }
    }
    public string ListBoxFormat()
    {
        return ID.ToString() + " | " + Vorname + " " + Nachname;
    }
}

