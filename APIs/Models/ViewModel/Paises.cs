using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIs.Models.ViewModel
{
    public class Paises
    {
        public class Country
        {
            public Name Name { get; set; }
        }

        public class Name
        {
            public string Common { get; set; }
            public string Official { get; set; }
            public Dictionary<string, NativeName> nativeName { get; set; }
        }

        public class NativeName
        {
            public string Official { get; set; }
            public string Common { get; set; }
        }

    }
}