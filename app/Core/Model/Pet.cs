using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Core.Model
{
    internal class Pet
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }

        public string Age { get; set; }

        public string Weight { get; set; }
        public ColourPattern ColourPattern { get; set; }
        public Species Specie { get; set; }
        public Gender Gender { get; set; }
        public Breed Breed { get; set; }
        public string Image { get; set; }
    }
}
