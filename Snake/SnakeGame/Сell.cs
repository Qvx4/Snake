using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Snake
{
    public class Cell
    {
        [JsonProperty("Type")]
        public CellType Type { get; set; }
        public Cell()
        {

        }
        public Cell(CellType type)
        {
            Type = type;
        }
    }
}
