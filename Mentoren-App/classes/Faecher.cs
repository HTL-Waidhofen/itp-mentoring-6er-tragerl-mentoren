using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mentoren_App.classes
{
    public class Faecher : DbConnection
    {
        public int FachID { get; set; }
        public string Fachname { get; set; }

        public Faecher(int fachID, string fachname)
        {
            this.FachID = fachID;
            this.Fachname = fachname;
        }

        // CREATE: Neues Fach hinzufügen
        public static void CreateFach(string fachname)
        {
            string query = "INSERT INTO Faecher (Fachname) VALUES (@Fachname)";
            SqlParameter[] parameters = { new SqlParameter("@Fachname", fachname) };
            new Faecher(0, "").CreateData(query, parameters);
        }

        // READ: Alle Fächer abrufen
        public static List<Faecher> ReadAllFaecher()
        {
            List<Faecher> result = new List<Faecher>();
            string query = "SELECT * FROM Faecher";
            using (SqlDataReader reader = new Faecher(0, "").ReadData(query, null))
            {
                while (reader.Read())
                {
                    int fachID = Convert.ToInt32(reader["FachID"]);
                    string fachname = Convert.ToString(reader["Fachname"]);
                    result.Add(new Faecher(fachID, fachname));
                }
            }
            return result;
        }

        // UPDATE: Fachnamen aktualisieren
        public void UpdateFach(string neuerFachname)
        {
            string query = "UPDATE Faecher SET Fachname = @NeuerFachname WHERE FachID = @FachID";
            SqlParameter[] parameters = { new SqlParameter("@NeuerFachname", neuerFachname), new SqlParameter("@FachID", this.FachID) };
            new Faecher(0, "").UpdateData(query, parameters);
        }

        // DELETE: Fach löschen
        public void DeleteFach()
        {
            string query = "DELETE FROM Faecher WHERE FachID = @FachID";
            SqlParameter[] parameters = { new SqlParameter("@FachID", this.FachID) };
            new Faecher(0, "").DeleteData(query, parameters);
        }
    }
}
