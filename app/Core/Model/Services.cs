

namespace app.core.model
{
    public class Services
    {
        public int Id { get; set; }
        public Types ServiceType { get; set; }
        public string ServiceCode { get; set; }
        public string Description
        {
            get; set;
        }
        public double Price 
        { 
            get; set; 
        }
    }
}
