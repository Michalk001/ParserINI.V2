using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserINIFile.Model
{
    public class Registry
    {
        public string key { get; set; }
        public string value { get; set; }
        public string comment { get; set; } = null;
    }
}
