using ParserINIFile.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParserINI.src.Interfaces
{
    public interface ISectionRegistry
    {
        string SectionName { get; set; }
        void Add(Registry reg);
        void Add(List<Registry> reg);
        void Add(string key, string value, string comment);
        void Add(string key, string value);
        void Remove(string key);
        Registry Get(string key);
        List<Registry> Get();

    }
}
