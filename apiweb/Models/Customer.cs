using System;

namespace apiweb
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int PostalCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; }
        public Boolean Eliminado { get; set; }
    }
}
