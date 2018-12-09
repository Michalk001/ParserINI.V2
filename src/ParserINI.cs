using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserINIFile.Model;

namespace ParserINIFile
{
    public class ParserINI
    {
        private string _path;
        private Encoding _encoding;
        public string path {
            private get {
                return _path;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Bad path");
                _path = value;
                fileOperation.path = value;
                fileOperation.Open();
            }
        }

        public Encoding encoding
        {
            private get
            {
                return _encoding;
            }
            set
            {
                _encoding = value;
                fileOperation.encoding = value;
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
            this.path = path;
            
            
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
