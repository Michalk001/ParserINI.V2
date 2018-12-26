using ParserINIFile.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParserINI.src.Interfaces
{
    public interface IListSectionRegistries
    {
        void Add(SectionRegistry sectionRegistry);
        void Add(List<SectionRegistry> sectionRegistries);
        void Add(string sectionName, string key, string value, string comment);
        void Add(string sectionName, string key, string value);
        SectionRegistry Get(string sectionName);
        List<SectionRegistry> Get();
    }

}
