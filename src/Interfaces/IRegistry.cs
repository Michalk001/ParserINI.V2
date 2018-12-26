using System;
using System.Collections.Generic;
using System.Text;

namespace ParserINI.src.Interfaces
{
    public interface IRegistry
    {
        string Key { get; set; }
        string Value { get; set; }
        string Comment { get; set; }
    }
}
