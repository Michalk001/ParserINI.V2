
using ParserINIFile.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserINIFile.Model
{
    public class ParseData
    {

        List<SectionRegistry> listSectionIni = new List<SectionRegistry>();
        SectionRegistry sectionRegistry = null;
        List<Registry> registries = new List<Registry>();


        private void Section(string data)
        {
            
            if (sectionRegistry != null)
            {
                sectionRegistry.Add(registries);
                listSectionIni.Add(sectionRegistry);
                registries = new List<Registry>();
            }
            sectionRegistry = new SectionRegistry
            {
                sectionName = data.TrimStart(Config.Get.SectionStartChar).TrimEnd(Config.Get.SectionEndChar)
            };
        }

        private void Body(string data)
        {
            var tmp = data.Split('=');
            string keyTmp = null;
            string valueTmp = null;
            string commentTmp = null;
            try
            {
                keyTmp = data.Split(Config.Get.KeyValueChar)[0];
                commentTmp = valueTmp = data.Split(Config.Get.KeyValueChar)[1];
                valueTmp = valueTmp.Remove(valueTmp.IndexOf(Config.Get.CommentChar)).Trim(' ');
            }
            catch
            {

            }
            if (commentTmp.IndexOf(Config.Get.CommentChar) != -1)
            {
                commentTmp = commentTmp.Remove(0, commentTmp.IndexOf(Config.Get.CommentChar) + 1);
            }
            try
            {
                registries.Add(new Registry
                {
                    key = keyTmp,
                    value = valueTmp,
                    comment = commentTmp

                });
            }
            catch
            {

            }
        }
        public List<SectionRegistry> CreateListSection(List<string> data)
        {
            if (data.Count == 0)
                return null;
            foreach(var item in data)
            {
                if (item[0] == Config.Get.SectionStartChar)
                {

                    Section(item);
                    continue;
                }
                else
                {
                    Body(item);
                }
            }
            sectionRegistry.Add(registries);
            listSectionIni.Add(sectionRegistry);
            return listSectionIni;
        }
    }
}
