using ParserINI.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserINIFile.Model
{
    public class SectionRegistry : ISectionRegistry
    {
        public string SectionName { get; set; }
        private Dictionary<string, Registry> registries = new Dictionary<string, Registry>();
        public void Add(Registry reg)
        {
            if(!registries.ContainsKey(reg.Key))
                registries.Add(reg.Key, reg);
        }
        public void Add(List<Registry> reg)
        {
            foreach(var item in reg){
                Add(item);
            }
        }
        public void Add(string key,string value,string comment)
        {
            var reg = new Registry()
            {
                Value = value,
                Key = key,
                Comment = comment
            };
            Add(reg);                  
        }
        public void Add(string key, string value)
        {
            Add(key, value, null);
        }
     
        public void Remove(string key)
        {
            registries.Remove(key);
        }
        public Registry Get(string key)
        {
            if(registries.ContainsKey(key))
                return registries[key];
            return null;
        }
        public List<Registry> Get()
        {
            return registries.Values.ToList();
        }
    }
}
