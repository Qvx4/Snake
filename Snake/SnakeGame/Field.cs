using System;
using Newtonsoft.Json;

namespace Snake
{
    public class Field
    {
        [JsonProperty("Fields")]
        public Cell[,] Fields { get; set; }
        public Field()
        {
            Fields = new Cell[13, 53];
            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    Fields[i, j] = new Cell();
                    Fields[i, j].Type = CellType.Emptioness;
                    //Fields[i, j].Type = CellType.Body;
                }
            }
            Fields[9, 35].Type = CellType.Head;

        }
        public Field(int sizeX,int sizeY)
        {
            Fields = new Cell[sizeX, sizeY];
            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    Fields[i, j] = new Cell();
                    Fields[i, j].Type = CellType.Emptioness;
                }
            }
            Fields[9, 35].Type = CellType.Head;
            AddingApples();
        }
        public Field(Point point)
        {
            Fields = new Cell[13, 53];
            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    Fields[i, j] = new Cell();
                }
            }
            Fields[point.X, point.Y].Type = CellType.Head;
        }
        public void RandomColor()
        {
            Random rnd = new Random();
            int number = rnd.Next(7, 15);
            Console.ForegroundColor = (ConsoleColor)number;
        }
        public void Show(DirectionSnake directionSnake,int score, DateTime gameTime)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                Console.Write(" ");
                for (int i = 0; i < Fields.GetLength(1); i++)
                {
                    Console.Write("▓");
                }
                Console.Write("▓▓");
                Console.WriteLine("");
            }
            catch (Exception e)
            {

            }
            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                Console.Write("▓▓");
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    if (Fields[i, j].Type == CellType.Head)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        switch (directionSnake)
                        {
                            case DirectionSnake.Right:
                                {
                                    Console.Write(">");
                                }
                                break;
                            case DirectionSnake.Left:
                                {
                                    Console.Write("<");
                                }
                                break;
                            case DirectionSnake.Up:
                                {
                                    Console.Write("˄");
                                }
                                break;
                            case DirectionSnake.Down:
                                {
                                    Console.Write("˅");
                                }
                                break;
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (Fields[i, j].Type == CellType.Emptioness)
                    {
                        Console.Write(" ");
                    }
                    else if (Fields[i, j].Type == CellType.Apple)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("•");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (Fields[i, j].Type == CellType.Body)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("©");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (Fields[i, j].Type == CellType.BigAplle)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("●");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (Fields[i, j].Type == CellType.Border)
                    {
                        RandomColor();
                        Console.Write("·");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.Write("▓▓");
                Console.WriteLine();
            }
            for (int i = 0; i < Fields.GetLength(1); i++)
            {
                Console.Write("▓");
            }
            Console.Write("▓▓▓▓");
            Console.WriteLine("");
            Console.Write($"▓▓       Score > ({score})              ({gameTime.Hour}:{gameTime.Minute}:{gameTime.Second}) < Time");
            for (int i = 0; i < Fields.GetLength(1) - 25 - score.ToString().Length - gameTime.ToString().Length - gameTime.Second.ToString().Length - gameTime.Minute.ToString().Length; i++)
            {
                Console.Write(" ");
            }
            Console.Write(
                "▓▓\n" +
                "▓▓");
            for (int i = 0; i < Fields.GetLength(1); i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("▓▓");
            for (int i = 0; i < Fields.GetLength(1); i++)
            {
                Console.Write("▓");
            }
            Console.Write("▓▓▓▓");
            Console.WriteLine("");
            Console.WriteLine(
                "       ▒             ▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n" +
                "      ▒                 ▒▒▒▒▒▒▒▒\n" +
                "     ▒                  ▒▒▒▒▒▒▒▒\n" +
                "    ▒              ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒\n" +
                "   ▒\n" +
                "  ▒      ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
                " ▒      ▓▒▓w▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓\n" +
                "▒o▒▒   ▓a▓▒s▒▓d▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓\n" +
                "▒▒▒▒  ▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓▒▓\n" +
                "▒▒▒  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n");
        }
        public void AddingApples()
        {
            Random rnd = new Random();
            int X, Y;
            if (rnd.Next(0, 10) == 5)
            {
                do
                {
                    X = rnd.Next(0, 13);
                    Y = rnd.Next(0, 53);
                }
                while (Fields[X, Y].Type != CellType.Emptioness);
                Fields[X, Y].Type = CellType.BigAplle;
                return;
            }
            do
            {
                X = rnd.Next(0, 13);
                Y = rnd.Next(0, 53);
            }
            while (Fields[X, Y].Type != CellType.Emptioness);
            Fields[X, Y].Type = CellType.Apple;
        }
        public void WayToPlayBoxing()
        {
            for (int i = 0; i < Fields.GetLength(1);i++)
            {
                Fields[0, i].Type = CellType.Border;
            }
            for (int i = 1; i < Fields.GetLength(0); i++)
            {
                Fields[i, 0].Type = CellType.Border;
            }
            for (int i = 1; i < Fields.GetLength(1); i++)
            {
                Fields[Fields.GetLength(0) - 1, i].Type = CellType.Border;
            }
            for (int i = Fields.GetLength(0) - 1 ; i >= 0; i--)
            {
                Fields[i, Fields.GetLength(1) - 1].Type = CellType.Border;
            }
        }
    }
}
