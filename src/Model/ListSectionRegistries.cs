using ParserINI.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserINIFile.Model
{
    public class ListSectionRegistries : IListSectionRegistries
    {
        private Dictionary<String,SectionRegistry> list = new  Dictionary<string,SectionRegistry>();

        public void Add(SectionRegistry sectionRegistry)
        {
            if (!list.ContainsKey(sectionRegistry.SectionName))
                list.Add(sectionRegistry.SectionName, sectionRegistry); 
            else
            {
                var ss = list.Values.Where(x => x.SectionName == sectionRegistry.SectionName).FirstOrDefault();
                ss.Add(sectionRegistry.Get());
                list.Remove(ss.SectionName);
                list.Add(ss.SectionName,ss);
               
            }
        }
        public void Add(List<SectionRegistry> sectionRegistries)
        {
            foreach(var item in sectionRegistries)
            {
                if (!list.ContainsKey(item.SectionName))
                    list.Add(item.SectionName, item);
            }
        }

       

        public void Add(string sectionName, string key, string value, string comment)
        {
            SectionRegistry sectionRegistry = new SectionRegistry
            {
                SectionName = sectionName
            };
            sectionRegistry.Add(key, value, comment);
            if (Get(sectionName) == null)
            {
                
                list.Add(sectionName, sectionRegistry);
            }
            else
            {
                this.Add(sectionRegistry);
            }
        }
        public void Add(string sectionName, string key, string value)
        {
            this.Add(sectionName, key, value, null);
        }
        public SectionRegistry Get(string sectionName)
        {
            if (list.ContainsKey(sectionName))
                return list[sectionName];
            return null;
        }
        public List<SectionRegistry> Get()
        {
                return list.Values.ToList();
            
        }
    }
}
