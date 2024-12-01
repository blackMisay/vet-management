

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
