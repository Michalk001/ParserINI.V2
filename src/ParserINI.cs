using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserINI.src.Interfaces;
using ParserINIFile.Model;

namespace ParserINIFile
{
    public class ParserINI : IParserINI
    {
        private string _path;
        private Encoding _encoding;
        public string Path {
            get {
                return _path;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Bad path");
                _path = value;
                fileOperation.Path = value;
                fileOperation.Open();
            }
        }

        public Encoding Encoding
        {
            get
            {
                return _encoding;
            }
            set
            {
                _encoding = value;
                fileOperation.Encoding = value;
                fileOperation.Open(_encoding);
            }
        }

        private FileOperation fileOperation;
        public ParserINI() {
            fileOperation = new FileOperation();
        }
        public ParserINI(string path)
        {
            
            fileOperation = new FileOperation();
            this.Path = path;
            
            
        }
         
        public void SaveData(List<SectionRegistry> sectionRegistries) {
            if(sectionRegistries == null)
                throw new ArgumentException("Empty");
            fileOperation.Save(sectionRegistries);
        }
        public void SaveData(ListSectionRegistries listSectionRegistries)
        {
            if (listSectionRegistries == null)
                throw new ArgumentException("Empty");
            List<SectionRegistry> sectionRegistries = new List<SectionRegistry>();
            foreach(var item in listSectionRegistries.Get())
            {
                sectionRegistries.Add(item);

            };
            fileOperation.Save(sectionRegistries);
        }
        public void SaveData(SectionRegistry sectionRegistry)
        {
            if (sectionRegistry == null)
                throw new ArgumentException("Empty");
            fileOperation.Save(sectionRegistry);
        }
        public ListSectionRegistries ReadFile()
        {
            return fileOperation.Read();
        }

    }
}   
