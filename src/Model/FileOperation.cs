using ParserINI.src.Interfaces;
using ParserINIFile.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserINIFile.Model
{
    class FileOperation : IFileOperation
    {
        private StreamReader FileRead { get; set; }
        private StreamWriter FileWrite { get; set; }
        private FileStream FileStream { get; set; }


        public string Path { get; set; }
        public Encoding Encoding { get; set; }

        public void Open()
        {
            FileStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileRead = new StreamReader(FileStream, Encoding.UTF8);
            FileWrite = new StreamWriter(FileStream, Encoding.UTF8);
        }
        public void Open(Encoding encoding)
        {
            FileStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileRead = new StreamReader(FileStream, encoding);
            FileWrite = new StreamWriter(FileStream, encoding);
        }
        public void Save(List<SectionRegistry> sectionRegistries )
        {
            foreach (var item in sectionRegistries)
            {
                FileWrite.WriteLine($"{Config.Get.SectionStartChar}{item.SectionName}{Config.Get.SectionEndChar}");
                FileWrite.Flush();
                foreach (var itemA in item.Get())
                {
                    if(itemA.Comment != null && itemA.Comment != "")
                        FileWrite.WriteLine($"{itemA.Key}{Config.Get.KeyValueChar}{itemA.Value} {Config.Get.CommentChar}{itemA.Comment}");
                    else
                        FileWrite.WriteLine($"{itemA.Key}{Config.Get.KeyValueChar}{itemA.Value}");
                    FileWrite.Flush();

                }
                FileWrite.WriteLine("");
                FileWrite.Flush(); 
            }
        }

        public void Save(SectionRegistry sectionRegistry){
            List<SectionRegistry> sectionRegistries = new List<SectionRegistry>()
            {
               sectionRegistry
            };
            Save(sectionRegistries);
        }
        private List<string> ReadRawData()
        {
            List<string> data = new List<string>();
            while (!FileRead.EndOfStream)
            {
                string tmpData = FileRead.ReadLine();
                if (tmpData != "")
                    data.Add(tmpData);
            }
            return data;

        }


        public ListSectionRegistries Read()
        {

            ParseData parseData = new ParseData();
            ListSectionRegistries listSectionRegistries = new ListSectionRegistries();
            var listSection = parseData.CreateListSection(ReadRawData());
            if (listSection == null)
                return null;
            foreach (var item in listSection)
            {
                listSectionRegistries.Add(item);
            }

            return listSectionRegistries;
        }
    }
}
