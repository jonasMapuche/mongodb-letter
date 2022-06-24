using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.Models
{
    public class DatabaseSettings
    {
        public string ConnectionName { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        public string JsonFile { get; set; }
    }
}
