using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entools.Model
{
    public class Tools
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string ImagePath { get; set; }
        public List<ToolOperation> Operations{ get; set; }
    }

}
