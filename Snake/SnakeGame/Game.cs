using Newtonsoft.Json;
using System;
//using System.Threading;
using System.Timers;

namespace Snake
{
    public class Game
    {
        [JsonProperty("Field")]
        public Field Field { get; set; }
        [JsonProperty("Atimer")]
        public Timer Atimer { get; set; }
        [JsonProperty("Snake")]
        public Snake Snake { get; set; }
        [JsonProperty("Users")]
        public User[] Users { get; set; }
        [JsonProperty("Apple")]
        public int Apple { get; set; }
        [JsonProperty("BigApple")]
        public int BigApple { get; set; }
        [JsonProperty("GameTime")]
        public DateTime GameTime { get; set; }
        [JsonProperty("Score")]
        public int Score { get; set; }
        public bool Check { get; set; }
        public Game()
        {
            Users = new User[0];
            GameTime = new DateTime(2022, 1, 1, 0, 0, 0);
        }
        public Game(Field field, Snake snake)
        {
            Field = field;
            Snake = snake;
            Users = new User[0];
            GameTime = new DateTime(2022, 1, 1, 0, 0, 0);
        }

        //Method
        public bool MethodStartGame(int number, SizeSettingFieldMenu sizeSettingFieldMenu, ModeSelectionMenu modeSelectionMenu, string login)
        {
            Score = 0;
            GameTime = new DateTime(2022, 1, 1, 0, 0, 0);
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Login == login)
                {
                    Apple = 0;
                    BigApple = 0;
                }
            }
            switch (sizeSettingFieldMenu)
            {
                case SizeSettingFieldMenu.Default:
                    this.Field = new Field();
                    break;
                case SizeSettingFieldMenu.Average:
                    this.Field = new Field(17, 53);
                    break;
                case SizeSettingFieldMenu.Big:
                    this.Field = new Field(18, 62);
                    break;
            }
            ChangeModeGame(modeSelectionMenu);
            Atimer = new System.Timers.Timer();
            switch (number)
            {
                case (int)GameSpeed.NormalSpeed:
                    Atimer.Interval = 350;
                    break;
                case (int)GameSpeed.AverageSpeed:
                    Atimer.Interval = 200;
                    break;
                case (int)GameSpeed.HighSpeed:
                    Atimer.Interval = 250;
                    break;
            }
            Atimer.Elapsed += SnakeMovements;
            Atimer.Elapsed += Show;
            Atimer.AutoReset = true;
            Atimer.Enabled = true;
            Point point = new Point(Snake.HeadCoordinate.X = 9, Snake.HeadCoordinate.Y = 35);
            Field field = new Field(point);
            Snake.MoveHistory = new Point[] { new Point(9, 35) };
            Field.AddingApples();
            while (true)
            {
                if (Check)
                {
                    Check = false;
                    //Atimer.AutoReset = false;
                    //Atimer.Stop();
                    //Atimer.Elapsed -= SnakeMovements;
                    //Atimer.Elapsed -= Show;
                    switch (sizeSettingFieldMenu)
                    {
                        case SizeSettingFieldMenu.Default:
                            this.Field = new Field();
                            break;
                        case SizeSettingFieldMenu.Average:
                            this.Field = new Field(17, 53);
                            break;
                        case SizeSettingFieldMenu.Big:
                            this.Field = new Field(18, 62);
                            break;
                    }
                    ChangeModeGame(modeSelectionMenu);
                    Snake.BodyLenth = 0;
                    Console.Clear();
                    ShowLossGame();
                    Console.Write("Нажмите любую кнопку ... ");
                    Console.ReadLine();
                    return false;
                }
                if (MethodCheckingWin(modeSelectionMenu))
                {
                    Atimer.AutoReset = false;
                    Atimer.Stop();
                    Atimer.Elapsed -= SnakeMovements;
                    Atimer.Elapsed -= Show;
                    Console.Clear();
                    switch (sizeSettingFieldMenu)
                    {
                        case SizeSettingFieldMenu.Default:
                            this.Field = new Field();
                            break;
                        case SizeSettingFieldMenu.Average:
                            this.Field = new Field(17, 53);
                            break;
                        case SizeSettingFieldMenu.Big:
                            this.Field = new Field(18, 62);
                            break;
                    }
                    ChangeModeGame(modeSelectionMenu);
                    ShowWinGame();
                    Console.Write("Нажмите любую кнопку ... ");
                    Console.ReadLine();
                    return true;
                }
                ConsoleKeyInfo key = Console.ReadKey();
                ButtonClickTracingMethod(key);

            }
        }
        public bool ButtonClickTracingMethod(ConsoleKeyInfo consoleKeyInfo)
        {
            Console.Clear();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (Snake.Direction != DirectionSnake.Down)
                        {
                            UpArrow();

                        }
                        //Show();
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        if (Snake.Direction != DirectionSnake.Up)
                        {
                            DownArrow();
                        }
                        //MethotGo();
                        //Show();
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        if (Snake.Direction != DirectionSnake.Right)
                        {

                            LeftArrow();
                        }
                        //MethotGo();
                        //Show();
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        if (Snake.Direction != DirectionSnake.Left)
                        {

                            RightArrow();
                        }
                        //MethotGo();
                        //Show();
                    }
                    break;

            }
            return true;
        }
        public bool MethodCheckLogin(string login)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Login == login)
                {
                    return true;
                }
            }
            return false;
        }
        public bool MethodCheckPassword(string password)
        {

            char[] checkPassword = password.ToCharArray();
            for (int i = 0; i < checkPassword.Length; i++)
            {
                if (checkPassword[i] == ' ')
                {
                    return true;
                }
            }
            if (checkPassword.Length < 8 || checkPassword.Length > 32)
            {
                return true;
            }
            return false;
        }
        public bool MethodCheckLoginAndPassword(string login, string password)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Login == login && Users[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public void MethodEatAnApple()
        {
            Field.AddingApples();
            Apple += 2;
        }
        public void MethodEatBigApple()
        {
            //Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Body;
            //Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Body;
            Field.AddingApples();
            BigApple += 4;
        }
        public bool MethodCheckingTheHeadHitTheBody(DirectionSnake directionSnake)
        {
            switch (directionSnake)
            {
                case DirectionSnake.Right:
                    {
                        if (Snake.HeadCoordinate.Y < Field.Fields.GetLength(1) - 1)
                        {
                            if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y + 1].Type == CellType.Body ||
                                Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y + 1].Type == CellType.Border)
                            {
                                return true;
                            }
                        }
                    }
                    break;
                case DirectionSnake.Left:
                    {
                        if (Snake.HeadCoordinate.Y > 0)
                        {
                            if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y - 1].Type == CellType.Body ||
                                Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y - 1].Type == CellType.Border)
                            {
                                return true;
                            }
                        }
                    }
                    break;
                case DirectionSnake.Up:
                    {
                        if (Snake.HeadCoordinate.X > 0)
                        {
                            if (Field.Fields[Snake.HeadCoordinate.X - 1, Snake.HeadCoordinate.Y].Type == CellType.Body ||
                                Field.Fields[Snake.HeadCoordinate.X - 1, Snake.HeadCoordinate.Y].Type == CellType.Border)
                            {
                                return true;
                            }
                        }
                    }
                    break;
                case DirectionSnake.Down:
                    {
                        if (Snake.HeadCoordinate.X < Field.Fields.GetLength(0) - 1)
                        {
                            if (Field.Fields[Snake.HeadCoordinate.X + 1, Snake.HeadCoordinate.Y].Type == CellType.Body ||
                                Field.Fields[Snake.HeadCoordinate.X + 1, Snake.HeadCoordinate.Y].Type == CellType.Border)
                            {
                                return true;
                            }
                        }
                    }
                    break;
            }
            return false;
        }
        public bool MethodCheckingWin(ModeSelectionMenu modeSelectionMenu)
        {
            bool check = false;
            int number = 0;
            switch (modeSelectionMenu)
            {
                case ModeSelectionMenu.NormalMode:
                    {
                        for (int i = 0; i < Field.Fields.GetLength(0); i++)
                        {
                            for (int j = 0; j < Field.Fields.GetLength(1); j++)
                            {
                                number++;
                            }
                        }
                        if (Snake.BodyLenth == number - 2)
                        {
                            check = true;
                        }
                    }
                    break;
                case ModeSelectionMenu.BoxingMode:
                    {
                        for (int i = 0; i < Field.Fields.GetLength(0); i++)
                        {
                            for (int j = 0; j < Field.Fields.GetLength(1); j++)
                            {
                                if (Field.Fields[i, j].Type != CellType.Border)
                                {
                                    number++;
                                }
                            }
                        }
                        if (Snake.BodyLenth == number - 2)
                        {
                            check = true;
                        }
                    }
                    break;
            }
            return check;
        }
        public void StopTimer()
        {
            Check = true;
            Atimer.AutoReset = false;
            Atimer.Stop();
            Atimer.Elapsed -= SnakeMovements;
            Atimer.Elapsed -= Show;
            Console.Clear();
            ShowLossGame();
        }
        public bool MethotCheckScoreforHuman(string login)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Login == login)
                {
                    if (Users[i].Score == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool MethotNumberOfPlayers()
        {
            if (Users.Length == 0)
            {
                return true;
            }
            return false;
        }
        //Method
        //Add 
        public bool AddUser(User user)
        {
            User[] addUser = new User[Users.Length + 1];
            for (int i = 0; i < Users.Length; i++)
            {
                addUser[i] = Users[i];
            }
            addUser[Users.Length] = user;
            Users = addUser;
            return true;
        }
        //Add 
        //Show 
        public void Show(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.Clear();
            Score = (Apple * 2) + (BigApple * 4);
            Field.Show(Snake.Direction, Score, GameTime);
        }
        public void ShowGameRules()
        {
            Console.WriteLine(
            " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓ Игрок управляет длинным, тонким существом,          ▓▓\n" +
            "▓▓ напоминающим змею, которое ползает по плоскости     ▓▓\n" +
            "▓▓ (как правило, ограниченной стенками),               ▓▓\n" +
            "▓▓ собирая еду (или другие предметы),                  ▓▓\n" +
            "▓▓ избегая столкновения с собственным хвостом          ▓▓\n" +
            "▓▓ и краями игрового поля. Каждый раз,                 ▓▓\n" +
            "▓▓ когда змея съедает кусок пищи,                      ▓▓\n" +
            "▓▓ она становится длиннее,                             ▓▓\n" +
            "▓▓  что постепенно усложняет игру                      ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
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
        public void ShowPlayerInformation(string login)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Login == login)
                {
                    Users[i].ShowInformation();
                }
            }
        }
        public void ShowLossGame()
        {
            Console.WriteLine(
            " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
            "▓▓                                                       ▓▓\n" +
            "▓▓                                                       ▓▓\n" +
            "▓▓                                                       ▓▓\n" +
            "▓▓                                                       ▓▓\n" +
            "▓▓                                                       ▓▓");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(
                "▓▓                   0──────────────0                    ▓▓\n" +
                "▓▓                   │              │                    ▓▓\n" +
                "▓▓                   │   L O S S    │                    ▓▓\n" +
                "▓▓                   │              │                    ▓▓\n" +
                "▓▓                   0──────────────0                    ▓▓");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(
            "▓▓                                                       ▓▓\n" +
            "▓▓                                                       ▓▓\n" +
            "▓▓                                                       ▓▓\n" +
            "▓▓                                                       ▓▓\n" +
            " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
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
        public void ShowWinGame()
        {
            Console.WriteLine(
            " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
            "▓▓                                                        ▓▓\n" +
            "▓▓                                                        ▓▓\n" +
            "▓▓                                                        ▓▓\n" +
            "▓▓                                                        ▓▓\n" +
            "▓▓                                                        ▓▓");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(
                "▓▓                   0──────────────0                     ▓▓\n" +
                "▓▓                   │              │                     ▓▓\n" +
                "▓▓                   │   W  I  N    │                     ▓▓\n" +
                "▓▓                   │              │                     ▓▓\n" +
                "▓▓                   0──────────────0                     ▓▓");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(
            "▓▓                                                        ▓▓\n" +
            "▓▓                                                        ▓▓\n" +
            "▓▓                                                        ▓▓\n" +
            "▓▓                                                        ▓▓\n" +
            " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
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
        public void ShowPlayer()
        {
            for (int i = 0; i < Users.Length; i++)
            {
                Users[i].ShowLogin();
            }
        }
        public void ShowBreakingYourRecird(string login)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Login == login)
                {

                    if (Users[i].Score < Score)
                    {
                        UpdateRecords(login);
                        Users[i].TimeRecord = GameTime;
                    }
                    Users[i].ShowRecord();

                }
            }
        }
        public void ShowWithdrawalOfOverallRecords(string login)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Login == login)
                {

                    Users[i].ShowRecord();

                }
            }
        }
        public void ShowTopThreeRecords()//
        {
            User[] user1 = Users;
            User user2 = new User();
            for (int i = 0; i < user1.Length; i++)
            {
                for (int j = i + 1; j < user1.Length; j++)
                {
                    if (user1[i].Score != 0)
                    {
                        if (user1[i].Score == user1[j].Score)
                        {
                            if (user1[i].TimeRecord > user1[j].TimeRecord)
                            {
                                user2 = user1[i];
                                user1[i] = user1[j];
                                user1[j] = user2;
                            }
                        }
                        if (user1[i].Score < user1[j].Score)
                        {
                            user2 = user1[i];
                            user1[i] = user1[j];
                            user1[j] = user2;
                        }
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                user1[i].ShowRecord();
            }
        }
        //Show
        //Movement
        public bool RightArrow()
        {
            Snake.Direction = DirectionSnake.Right;
            if (Snake.BodyLenth > 0) Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Body;
            if (MethodCheckingTheHeadHitTheBody(Snake.Direction))
            {
                StopTimer();
            }
            if (Snake.HeadCoordinate.Y + 1 > Field.Fields.GetLength(1) - 1)//fix
            {
                if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y = 0].Type == CellType.Body)
                {
                    StopTimer();
                }
                Snake.HeadCoordinate.Y = 0;
            }
            else Snake.HeadCoordinate.Y += 1;


            if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.Apple ||
                Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.BigAplle)
            {
                if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.Apple)
                {
                    int number1 = Snake.MoveHistory.Length - Snake.BodyLenth - 1;
                    Field.Fields[Snake.MoveHistory[number1].X, Snake.MoveHistory[number1].Y].Type = CellType.Emptioness;
                    Snake.BodyLenth += 1;
                    MethodEatAnApple();
                }
                else
                {
                    Snake.BodyLenth += 2;
                    MethodEatBigApple();
                }
            }
            int number = Snake.MoveHistory.Length - Snake.BodyLenth - 1;
            Field.Fields[Snake.MoveHistory[number].X, Snake.MoveHistory[number].Y].Type = CellType.Emptioness;
            Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Head;
            Snake.MethodSaveMovementCoordinate(new Point(Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y));
            return true;
        }
        public bool LeftArrow()
        {
            Snake.Direction = DirectionSnake.Left;
            if (Snake.BodyLenth > 0) Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Body;
            if (MethodCheckingTheHeadHitTheBody(Snake.Direction))
            {
                StopTimer();
            }
            if (Snake.HeadCoordinate.Y - 1 < 0)//fix
            {
                if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y = Field.Fields.GetLength(1) - 1].Type == CellType.Body)
                {
                    StopTimer();
                }
                Snake.HeadCoordinate.Y = Field.Fields.GetLength(1) - 1;
            }
            else Snake.HeadCoordinate.Y -= 1;


            if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.Apple ||
                Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.BigAplle)
            {
                if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.Apple)
                {
                    int number1 = Snake.MoveHistory.Length - Snake.BodyLenth - 1;
                    Field.Fields[Snake.MoveHistory[number1].X, Snake.MoveHistory[number1].Y].Type = CellType.Emptioness;
                    Snake.BodyLenth += 1;
                    MethodEatAnApple();

                }
                else
                {
                    Snake.BodyLenth += 2;
                    MethodEatBigApple();
                }
            }
            int number = Snake.MoveHistory.Length - Snake.BodyLenth - 1;
            Field.Fields[Snake.MoveHistory[number].X, Snake.MoveHistory[number].Y].Type = CellType.Emptioness;
            Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Head;
            Snake.MethodSaveMovementCoordinate(new Point(Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y));
            return true;

        }
        public bool DownArrow()
        {
            //Atimer.Stop();
            Snake.Direction = DirectionSnake.Down;
            if (Snake.BodyLenth > 0) Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Body;
            if (MethodCheckingTheHeadHitTheBody(Snake.Direction))
            {
                StopTimer();
            }
            if (Snake.HeadCoordinate.X + 1 > Field.Fields.GetLength(0) - 1)//fix
            {
                if (Field.Fields[Snake.HeadCoordinate.X = 0, Snake.HeadCoordinate.Y].Type == CellType.Body)
                {
                    StopTimer();
                }
                Snake.HeadCoordinate.X = 0;
            }
            else Snake.HeadCoordinate.X += 1;


            if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.Apple ||
                Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.BigAplle)
            {
                if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.Apple)
                {
                    int number1 = Snake.MoveHistory.Length - Snake.BodyLenth - 1;
                    Field.Fields[Snake.MoveHistory[number1].X, Snake.MoveHistory[number1].Y].Type = CellType.Emptioness;
                    Snake.BodyLenth += 1;
                    MethodEatAnApple();

                }
                else
                {
                    Snake.BodyLenth += 2;
                    MethodEatBigApple();
                }
            }
            int number = Snake.MoveHistory.Length - Snake.BodyLenth - 1;
            Field.Fields[Snake.MoveHistory[number].X, Snake.MoveHistory[number].Y].Type = CellType.Emptioness;
            Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Head;
            Snake.MethodSaveMovementCoordinate(new Point(Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y));
            return true;
        }
        public bool UpArrow()
        {
            Snake.Direction = DirectionSnake.Up;
            if (Snake.BodyLenth > 0) Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Body;
            if (MethodCheckingTheHeadHitTheBody(Snake.Direction))
            {
                StopTimer();
            }
            if (Snake.HeadCoordinate.X - 1 < 0)//fix
            {
                if (Field.Fields[Snake.HeadCoordinate.X = Field.Fields.GetLength(0) - 1, Snake.HeadCoordinate.Y].Type == CellType.Body)
                {
                    StopTimer();
                }
                Snake.HeadCoordinate.X = Field.Fields.GetLength(0) - 1;
            }
            else Snake.HeadCoordinate.X -= 1;


            if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.Apple ||
                Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.BigAplle)
            {
                if (Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type == CellType.Apple)
                {
                    int number1 = Snake.MoveHistory.Length - Snake.BodyLenth - 1;
                    Field.Fields[Snake.MoveHistory[number1].X, Snake.MoveHistory[number1].Y].Type = CellType.Emptioness;
                    Snake.BodyLenth += 1;
                    MethodEatAnApple();

                }
                else
                {
                    Snake.BodyLenth += 2;
                    MethodEatBigApple();
                }
            }
            int number = Snake.MoveHistory.Length - Snake.BodyLenth - 1;
            Field.Fields[Snake.MoveHistory[number].X, Snake.MoveHistory[number].Y].Type = CellType.Emptioness;
            Field.Fields[Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y].Type = CellType.Head;
            Snake.MethodSaveMovementCoordinate(new Point(Snake.HeadCoordinate.X, Snake.HeadCoordinate.Y));

            return true;
        }
        public void SnakeMovements(Object source, System.Timers.ElapsedEventArgs e)
        {
            GameTime = GameTime.AddMilliseconds(Atimer.Interval);
            if (Snake.Direction == DirectionSnake.Right)
            {
                RightArrow();
            }
            if (Snake.Direction == DirectionSnake.Left)
            {
                LeftArrow();
            }
            if (Snake.Direction == DirectionSnake.Down)
            {
                DownArrow();
            }
            if (Snake.Direction == DirectionSnake.Up)
            {
                UpArrow();
            }
        }
        //Movement
        //Change
        public bool ChangePassword(string login, string newPassword)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Login == login)
                {
                    Users[i].Password = newPassword;
                    return true;
                }
            }
            return false;
        }
        public void ChangeModeGame(ModeSelectionMenu modeSelectionMenu)
        {
            switch (modeSelectionMenu)
            {
                case ModeSelectionMenu.NormalMode:
                    break;
                case ModeSelectionMenu.BoxingMode:
                    {
                        Field.WayToPlayBoxing();
                    }
                    break;
            }
        }
        //Change
        //Update
        public void UpdateRecords(string login)
        {
            for (int i = 0; i < Users.Length; i++)
            {
                if (Users[i].Login == login)
                {
                    Users[i].Score = (Apple * 2) + (BigApple * 4);
                }
            }
        }
        //Update

    }
}
