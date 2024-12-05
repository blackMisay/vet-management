

namespace app.core.model
{
    internal class Services
    {
        public int Id
        {
            get; set;
        }
        public Types ServiceType { get; set; }
        public string ServiceCode { get; set; }
        public string Description
        {
            get; set;
        }
        public string Price 
        { 
            get; set; 
        }
    }
}
