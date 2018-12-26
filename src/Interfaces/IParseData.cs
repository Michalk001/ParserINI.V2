using ParserINIFile.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParserINI.src.Interfaces
{
    public interface IParseData
    {
        List<SectionRegistry> CreateListSection(List<string> data);

    }
}
