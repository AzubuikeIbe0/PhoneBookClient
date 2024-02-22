using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PhoneBookClient
{
    [DataContract]
    public class PhoneBookEntry
    {
        [DataMember(Name = "number")]                   // camelCasing
        public string Number { get; set; }              // unique

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        public override string ToString()
        {
            return Name + " " + Address + " " + Number;
        }
    }
}

