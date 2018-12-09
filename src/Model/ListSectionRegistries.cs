using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserINIFile.Model
{
    public class ListSectionRegistries
    {
        private Dictionary<String,SectionRegistry> list = new  Dictionary<string,SectionRegistry>();

        public void Add(SectionRegistry sectionRegistry)
        {
            if (!list.ContainsKey(sectionRegistry.sectionName))
                list.Add(sectionRegistry.sectionName, sectionRegistry); 
            else
            {
                var ss = list.Values.Where(x => x.sectionName == sectionRegistry.sectionName).FirstOrDefault();
                ss.Add(sectionRegistry.Get());
                list.Remove(ss.sectionName);
                list.Add(ss.sectionName,ss);
               
            }
        }
        public void Add(List<SectionRegistry> sectionRegistries)
        {
            foreach(var item in sectionRegistries)
            {
                if (!list.ContainsKey(item.sectionName))
                    list.Add(item.sectionName, item);
            }
        }

       

        public void Add(string sectionName, string key, string value, string comment)
        {
            SectionRegistry sectionRegistry = new SectionRegistry();
            sectionRegistry.sectionName = sectionName;
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
