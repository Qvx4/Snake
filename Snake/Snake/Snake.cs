using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Snake
{
    public class Snake
    {
        [JsonProperty("Direction")]
        public DirectionSnake Direction { get; set; }
        [JsonProperty("HeadCoordinate")]
        public Point HeadCoordinate { get; set; }
        [JsonProperty("BodyLenth")]
        public int BodyLenth { get; set; }
        [JsonProperty("MoveHistory")]
        public Point[] MoveHistory { get; set; }
        public Snake()
        {
            HeadCoordinate = new Point(9, 35);
            Direction = DirectionSnake.Right;
            MoveHistory = new Point[0];
            MethodSaveMovementCoordinate(HeadCoordinate);
        }
        public Snake(DirectionSnake direction, Point headCoordinate, Point[] moveHistory, int bodyLenth)
        {
            Direction = direction;
            HeadCoordinate = headCoordinate;
            MoveHistory = new Point[0];
            MethodSaveMovementCoordinate(headCoordinate);
            BodyLenth = bodyLenth;
        }
        public void MethodSaveMovementCoordinate(Point point)
        {
            int number  = MoveHistory.Length;
            Point[] addPoints = new Point[number + 1];
            for (int i = 0; i < MoveHistory.Length; i++)
            {
                addPoints[i] = MoveHistory[i];
            }
            addPoints[MoveHistory.Length] = point;
            MoveHistory = addPoints;
        }
    }
}
