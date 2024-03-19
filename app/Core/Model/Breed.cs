using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Core.Model
{
    internal class Breed
    {
        public int Id
        {
            get; set;
        }
        public Species Specie { get; set; }
        public string Description
        {
            get; set;
        }
    }
}
