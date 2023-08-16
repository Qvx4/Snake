using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Snake
{
    public class User : Human
    {
        [JsonProperty("Login")]
        public string Login { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("Score")]
        public int Score { get; set; }
        [JsonProperty("TimeRecord")]
        public DateTime TimeRecord { get; set; }
        public User()
        {
        }
        public User(string name, string surname, int age, string login, string password) : base(name, surname, age)
        {
            Login = login;
            Password = password;
        }
        public void ShowInformation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                "0------------------------------------0\n" +
                "| : Информационные данные о игроке : |\n" +
                "0------------------------------------0\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Логин игрока : {Login}\n" +
                $"1| Имя игрока : {Name}\n" +
                $"2| Фамилия игрока : {Surname} \n" +
                $"3| Возраст игрока : {Age} \n");
        }
        public void ShowRecord()
        {
            Console.WriteLine(
                $" Рекорды игрока с Логином ({Login})\n" +
                $"| Рекорд по очкам > ({Score})\n" +
                $"| Рекорд по Времени > ({TimeRecord.Hour}:{TimeRecord.Minute}:{TimeRecord.Second})\n");
        }
        public void ShowLogin()
        {
            Console.WriteLine(
                $"| Логин игрока : ({Login})\n" +
                $"| Имя : ({Name})\n" +
                $"| Фамилия : ({Surname})\n");
        }
    }
}
    