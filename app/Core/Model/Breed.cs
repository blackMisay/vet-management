

namespace app.Core.Model
{
    public class Breed
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
