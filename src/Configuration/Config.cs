using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserINIFile.Configuration
{
    public sealed class Config
    {
        private static Config _instance = null;
        private static readonly object _lock = new object();
        public char SectionStartChar { get; set; }
        public char SectionEndChar { get; set; }
        public char CommentChar { get; set; }
        public char KeyValueChar { get; set; }
        public Config()
        {
            SectionStartChar = '[';
            SectionEndChar = ']';
            CommentChar = ';';
            KeyValueChar = '=';
        } 
        public static Config Get
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Config();
                }
                return _instance;
            }
        }
    }
}
