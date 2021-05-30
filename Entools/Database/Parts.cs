using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Database
{
    public class Parts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public string ImagePath { get; set; }
        public string FrontImagePath { get; set; }
        public string BottomImagePath { get; set; }
        public List<Versions> Versions { get; set; }

    }
}
