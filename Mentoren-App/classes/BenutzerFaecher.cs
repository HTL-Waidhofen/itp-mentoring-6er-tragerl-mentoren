using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoren_App.classes
{
    internal class BenutzerFaecher : DbConnection
    {
        int BenutzerID {  get; set; }
        int FachID {  get; set; }
    }
}
