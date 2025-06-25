

    namespace app.Core.Model
    {
        public class Breed
        {
        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;  // So ComboBox shows Description
        }
    }
    }
