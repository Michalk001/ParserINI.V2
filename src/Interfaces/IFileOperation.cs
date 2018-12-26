using ParserINIFile.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParserINI.src.Interfaces
{
    public interface IFileOperation
    {
        string Path { get; set; }
        Encoding Encoding { get; set; }
        void Open();
        void Open(Encoding encoding);
        void Save(List<SectionRegistry> sectionRegistries);
        void Save(SectionRegistry sectionRegistry);
        ListSectionRegistries Read();
    }
}
