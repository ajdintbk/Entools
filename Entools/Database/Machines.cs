using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Database
{
    public class Machines
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
    }
}
