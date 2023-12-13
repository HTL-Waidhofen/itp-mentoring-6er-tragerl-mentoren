using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoren_App.classes
{
    public class Faecher : DbConnection
    {
        int FachID { get; set; }
        string Fachname { get; set; }

        Faecher(int fachID, string fachname)
        {
            this.FachID = fachID;
            this.Fachname = fachname;
        }
    }
}
