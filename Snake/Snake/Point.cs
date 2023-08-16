using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace Snake
{
    public class Point
    {
        [JsonProperty("X")]
        public int X { get; set; }
        [JsonProperty("Y")]
        public int Y { get; set; }
        public Point()
        {

        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
