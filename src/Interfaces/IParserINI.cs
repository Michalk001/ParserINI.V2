using ParserINIFile.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParserINI.src.Interfaces
{
    public interface IParserINI
    {
        string Path { get; set; }
        Encoding Encoding { get; set; }
        void SaveData(List<SectionRegistry> sectionRegistries);
        void SaveData(ListSectionRegistries listSectionRegistries);
        void SaveData(SectionRegistry sectionRegistry);
        ListSectionRegistries ReadFile();

    }
}
