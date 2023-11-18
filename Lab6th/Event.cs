using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Lab6th
{
    [Serializable]
    public class Event
    {
        public int EventNumber { get; set; }
        public string Location { get; set; }
    }
}
