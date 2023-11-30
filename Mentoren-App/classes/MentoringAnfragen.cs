using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoren_App.classes
{
    internal class MentoringAnfragen
    {
        int AnfragenID { get; set; }
        int SchuelerID { get; set; }
        int MentorID {  get; set; }
        int FachID { get; set; }
        string Status { get; set; }
        string Nachrichten { get; set; }
    }
}
