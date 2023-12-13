using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoren_App.classes
{
    internal class MentoringAnfragen : DbConnection
    {
        int AnfragenID { get; set; }
        int SchuelerID { get; set; }
        int MentorID {  get; set; }
        int FachID { get; set; }
        string Status { get; set; }
        string Nachrichten { get; set; }

        MentoringAnfragen(int anfragenID, int schuelerID, int mentorID, int fachID, string status, string nachrichten) 
        { 
            this.AnfragenID = anfragenID;
            this.SchuelerID = schuelerID;
            this.MentorID = mentorID;
            this.FachID = fachID;
            this.Status = status;
            this.Nachrichten = nachrichten;
        }
    }
}
