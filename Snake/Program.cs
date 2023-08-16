using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Snake
{
    internal class Program
    {
        public static void ShowDesktop()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(
                  " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
                  "▓▓ o─────────o                                         ▓▓\n" +
                  "▓▓ │▄▄▀█▄    │                                         ▓▓\n" +
                  "▓▓ │▀▀▀██    │                                         ▓▓\n" +
                  "▓▓ │ ▄██▀    │                                         ▓▓\n" +
                  "▓▓ │▀██▄█▀██▄│         ˄                               ▓▓\n" +
                  "▓▓ o─────────o        ˄ ˄         ˄                    ▓▓\n" +
                  "▓▓   1 Snake         ˄   ˄       ˄ ˄                   ▓▓\n" +
                  "▓▓                  ˄     ˄     ˄   ˄˄       ˄˄        ▓▓\n" +
                  "▓▓                 ˄       ˄   ˄      ˄     ˄  ˄       ▓▓\n" +
                  "▓▓                ˄         ˄ ˄        ˄   ˄    ˄      ▓▓\n" +
                  "▓▓               ˄           ˄          ˄ ˄      ˄˄    ▓▓\n" +
                  "▓▓─────o──────────────o────────────────────────────────▓▓\n" +
                  "▓▓ ||| │ ?            │ | 2 - Выйти с компьютера       ▓▓\n" +
                  "▓▓  |||│              │                                ▓▓\n" +
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
        public static void ShowTeaturesIniseTheGame()
        {

            Console.WriteLine(
          " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("▓▓               |1 - Суть игры                        ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("▓▓               |2 - Информация о игроке              ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("▓▓               |3 - Настройки                        ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("▓▓               |4 - Начать игру                      ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("▓▓               |5 - Рекорды                          ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("▓▓               |6 - Выйти                            ▓▓");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
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
        public static void ShowPossibleSettings()
        {
            Console.WriteLine(
            " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("▓▓          |1 - Настройка поля(размер поля)           ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("▓▓          |2 - Настройка аккаунта(смена пароля)      ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("▓▓          |3 - Настроить ЛВЛ игры(скорость)          ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("▓▓          |4 - Выбрать вариант игры                  ▓▓");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
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
        public static void ShowCapSmiley()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(
                "                                                     ¶¶¶¶¶¶¶\n" +
                "                                                 ¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶\n" +
                "                                               ¶¶¶   ¶¶¶¶¶¶¶   ¶¶¶\n" +
                "                                              ¶¶    ¶¶  ¶  ¶¶    ¶¶\n" +
                "                                             ¶¶    ¶¶   ¶   ¶¶    ¶¶\n" +
                "                                            ¶¶    ¶¶    ¶    ¶¶    ¶¶\n" +
                "                                  ¶¶¶¶¶¶¶¶¶¶¶    ¶¶     ¶     ¶     ¶¶\n" +
                "                                 ¶¶        ¶     ¶¶     ¶     ¶¶     ¶\n" +
                "                                 ¶¶¶¶¶     ¶     ¶      ¶      ¶     ¶\n" +
                "                                     ¶¶¶¶¶¶¶¶¶¶ ¶¶      ¶      ¶¶  ¶¶¶\n" +
                "                                           ¶¶¶¶¶¶¶¶¶    ¶     ¶¶¶¶¶ ¶\n" +
                "                                            ¶     ¶¶¶¶¶¶¶¶¶¶¶¶¶     ¶");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
                "                                            ¶    ¶¶¶¶       ¶¶¶¶    ¶\n" +
                "                                            ¶   ¶¶  ¶¶     ¶¶  ¶¶   ¶\n" +
                "                                            ¶   ¶ ¶¶ ¶     ¶ ¶¶ ¶   ¶\n" +
                "                                            ¶   ¶ ¶¶¶¶     ¶¶¶¶ ¶   ¶\n" +
                "                                            ¶   ¶¶¶¶¶¶     ¶¶¶¶¶¶   ¶\n" +
                "                                            ¶          ¶¶           ¶\n" +
                "                                            ¶   ¶      ¶¶¶      ¶   ¶\n" +
                "                                            ¶¶  ¶¶             ¶¶  ¶¶\n" +
                "                                             ¶    ¶¶¶       ¶¶¶¶   ¶\n" +
                "                                             ¶¶     ¶¶¶¶¶¶¶¶¶     ¶\n" +
                "                                               ¶¶¶               ¶¶\n" +
                "                                                ¶¶¶           ¶¶¶\n" +
                "                                                   ¶¶¶¶¶¶¶¶¶¶¶\n");
        }
        public static void ShowGameOption()
        {
            Console.WriteLine(
           " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("▓▓          |1 - Оставить обычный режим                ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("▓▓          |2 - Поставить режим бокс                  ▓▓");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
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
        public static void ShowEmojiMainMenu()
        {
            Console.WriteLine(
                "             .--------------------.\n" +
                "_____________|  \\  |  _ \\ __|  __|| ..-----.   __________________ \n" +
                "_____________| |\\/ | (   |_| \\__ \\.'        `. __________________|\n" +
                "             |_|  _|\\___/___|____/    __.,,._/                   |\n" +
                "             '----------------- |   .'.-. .-.      _             |\n" +
                " ________        _____________   '.  ( \\o; \\o; _ .'` `-. ___     |\n" +
                "  -------.|     |.-----------.|    `._   ._. /--'._,_.,' --.|    \n" +
                " /\\ /\\ /\\||     ||     _..-'|||      ,'`-...' \\ /\\|||||` /\\||     \n" +
                " \\/ \\/ \\/||     ||    |     |||   ,-' \\/  \\/. / \\/||' |/ \\/||    \n" +
                " /\\ /\\ /\\||     ||    | .-. |||  /  .    |   '. . '---'\\ /\\||      \n" +
                " \\/ \\/ \\/||     ||    | | | |||  |  '     \\  . '   /  \\/ \\/||   \n" +
                " /\\ /\\ /\\||     ||====| '-' |||  |  ;     |   \\._.'/\\ /\\ /\\||    |\n" +
                " \\/_\\/_\\/||     || .==|     |||  |  |     ;   |_\\/_\\/_\\/_\\/||    |\n" +
                " ---------'     ||  |||     |||  |  /``-.__..'--------------'    |\n" +
                "                ||  |||     |||   './,|     \\                    |\n" +
                "                ||    |     |||    |-`      |                    |\n" +
                "                ||    '--.._|||    \\    |   |                    |\n" +
                " ---------------''-----------''---- |   |   |--------------------'\n" +
                "                                    |   |   |\n" +
                "                                    |   |   |\n" +
                " :::::::::::::::::::::::::::::::::: |   |   |::::::::::::::::::::::\n" +
                "                                    ;   |--''.\n" +
                "                                   /'--''-..__)\n" +
                "                                   `..--.__)\n");
        }
        public static void ShowSizeOoption()
        {
            Console.WriteLine(
           " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓\n" +
           "▓▓                                                     ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("▓▓          |1 - Изначальный размер поля               ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("▓▓          |2 - Средний размер поля                   ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("▓▓          |3 - Большой размер поля                   ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
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
        public static void ShowRecord()
        {
            Console.WriteLine(
          " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("▓▓          |1 - Показать свой рекорд                  ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("▓▓          |2 - Показать рекорды игрока               ▓▓");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("▓▓          |3 - Топ 3 рекорда в игру                  ▓▓");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
            "▓▓                                                     ▓▓\n" +
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
        public static int ShowGameSpeed(int speedOption)
        {
            bool isWords = true;
            int number = speedOption;
            while (isWords)
            {
                Console.WriteLine(
          " ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓");
                for (int i = 0; i < number; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("▓▓▓▓");
                }
                Console.Write("");
                for (int i = 0; i < 55 - (number * 4); i++)
                {
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(
          "▓▓\n" +
          "▓▓                                                     ▓▓\n" +
          "▓▓                                                     ▓▓\n" +
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
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (number > 1 || number > 3)
                            {
                                number--;
                            }
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        {
                            if (number >= 0 && number < 3)
                            {
                                number++;
                            }
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.Enter:
                        isWords = false;
                        break;
                }
            }
            return number;
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string login = "", password = "", json = "";
            bool check = true;
            SizeSettingFieldMenu fieldSettingsMenu = (SizeSettingFieldMenu)1;
            ModeSelectionMenu modeSelectionMenu = (ModeSelectionMenu)1;
            int speedOption = 1;
            Game game = new Game(new Field(), new Snake());
            //game.Show();
            //int number = 0;
            if (File.Exists("Snake.json"))
            {
                using (Stream stream = new FileStream("Snake.json", FileMode.Open))
                {
                    using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            json += streamReader.ReadLine();
                        }
                    }
                }
                if (json != "")
                {
                    JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                    serializerSettings.TypeNameHandling = TypeNameHandling.All;
                    game = JsonConvert.DeserializeObject<Game>(json,serializerSettings);
                }
            }
            while (true)
            {

                    Console.Clear();
                ShowEmojiMainMenu();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(" |1 - Войти в Аккаунт ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" |2 - Зарегестрировать Аккаунт ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" |Ввод > ");
                Console.ForegroundColor = ConsoleColor.Gray;
                MenuStepOne menuStepOne;
                while (Enum.TryParse(Console.ReadLine(), out menuStepOne) == false || (int)menuStepOne < 1 || (int)menuStepOne > 2)
                {
                    Console.Write("Введите правильный вариант ввод > ");
                }
                switch (menuStepOne)
                {
                    case MenuStepOne.Join:
                        {
                            Console.Clear();
                            ShowCapSmiley();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("                                                     Логин > ");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            login = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("                                                     Пароль > ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            password = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Clear();
                            while (game.MethodCheckLoginAndPassword(login, password))
                            {
                                JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                                serializerSettings.TypeNameHandling = TypeNameHandling.All;
                                json = JsonConvert.SerializeObject(game, serializerSettings);

                                using (Stream stream = new FileStream("Snake.json", FileMode.Create))
                                {
                                    using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8))
                                    {
                                        streamWriter.Write(json);
                                    }
                                }
                                if (check == false)
                                {
                                    check = true;
                                    break;
                                }
                                bool isWork = true;
                                ShowDesktop();
                                GameSelectionMenu gameSelectionMenu;
                                while (Enum.TryParse(Console.ReadLine(), out gameSelectionMenu) == false || (int)gameSelectionMenu < 1 || (int)gameSelectionMenu > 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("Введите правильный вариант > ");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                while (isWork)
                                {
                                    switch (gameSelectionMenu)
                                    {
                                        case GameSelectionMenu.Snake:
                                            {
                                                serializerSettings = new JsonSerializerSettings();
                                                serializerSettings.TypeNameHandling = TypeNameHandling.All;
                                                json = JsonConvert.SerializeObject(game, serializerSettings);

                                                using (Stream stream = new FileStream("Snake.json", FileMode.Create))
                                                {
                                                    using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8))
                                                    {
                                                        streamWriter.Write(json);
                                                    }
                                                }


                                                Console.Clear();
                                                ShowTeaturesIniseTheGame();
                                                GameMenu gameMenu;
                                                Enum.TryParse(Console.ReadLine(), out gameMenu);//fix
                                                switch (gameMenu)
                                                {
                                                    case GameMenu.MeaningOfTheGame:
                                                        {
                                                            Console.Clear();
                                                            game.ShowGameRules();
                                                            Console.Write("Нажмите любую кнопку чтоб выйти > ");
                                                            Console.ReadLine();
                                                        }
                                                        break;
                                                    case GameMenu.PlayerInformation:
                                                        {
                                                            Console.Clear();
                                                            game.ShowPlayerInformation(login);
                                                            Console.Write("Нажмите любую кнопку чтоб выйти > ");
                                                            Console.ReadLine();

                                                        }
                                                        break;
                                                    case GameMenu.Settings:
                                                        {
                                                            Console.Clear();
                                                            ShowPossibleSettings();
                                                            SettingsMenu settingsMenu;
                                                            Enum.TryParse(Console.ReadLine(), out settingsMenu);
                                                            switch (settingsMenu)
                                                            {
                                                                case SettingsMenu.FieldSettings:
                                                                    {
                                                                        Console.Clear();
                                                                        ShowSizeOoption();
                                                                        Enum.TryParse(Console.ReadLine(), out fieldSettingsMenu);
                                                                    }
                                                                    break;
                                                                case SettingsMenu.AccountSetup:
                                                                    {
                                                                        Console.WriteLine("Введите Новый пароль > ");
                                                                        password = Console.ReadLine();
                                                                        while (game.MethodCheckPassword(password))
                                                                        {
                                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                                            Console.WriteLine("Пароль был введен с ошибкой ");
                                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                                            Console.WriteLine("Введите пароль > ");
                                                                            password = Console.ReadLine();
                                                                        }
                                                                        game.ChangePassword(login, password);
                                                                    }
                                                                    break;
                                                                case SettingsMenu.GameDifficulty:
                                                                    {
                                                                        Console.Clear();
                                                                        speedOption = ShowGameSpeed(speedOption);
                                                                        Console.WriteLine("Нажмите энтер что бы принять....");
                                                                        Console.ReadLine();
                                                                    }
                                                                    break;
                                                                case SettingsMenu.GameOptionSelection:
                                                                    {
                                                                        Console.Clear();
                                                                        ShowGameOption();
                                                                        Enum.TryParse(Console.ReadLine(), out modeSelectionMenu);
                                                                    }
                                                                    break;
                                                            }
                                                        }
                                                        break;
                                                    case GameMenu.StartGame:
                                                        {
                                                            Console.Clear();
                                                            if (game.MethodStartGame(speedOption, fieldSettingsMenu, modeSelectionMenu, login) == false)
                                                            {
                                                                //game.ShowLossGame();
                                                                //Console.ReadLine();
                                                                break;
                                                            }
                                                            Console.Clear();
                                                        }
                                                        break;
                                                    case GameMenu.Records:
                                                        {
                                                            Console.Clear();
                                                            ShowRecord();
                                                            MenuRecord menuRecord;
                                                            Enum.TryParse(Console.ReadLine(), out menuRecord);
                                                            switch (menuRecord)
                                                            {
                                                                case MenuRecord.YourRecord:
                                                                    {
                                                                        Console.Clear();
                                                                        if (game.MethotCheckScoreforHuman(login))
                                                                        {
                                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                                            Console.WriteLine(
                                                                                "0------------------------------------------0\n" +
                                                                                "|                                          |\n" +
                                                                                "|  У вас нету рекордов на данный момент ;( |\n" +
                                                                                "|                                          |\n" +
                                                                                "0------------------------------------------0\n");
                                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                                        }
                                                                        game.ShowBreakingYourRecird(login);
                                                                        Console.ReadLine();
                                                                    }
                                                                    break;
                                                                case MenuRecord.OverallRecord:
                                                                    {
                                                                        Console.Clear();
                                                                        if (game.MethotNumberOfPlayers())
                                                                        {
                                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                                            Console.WriteLine(
                                                                                "0------------------------0\n" +
                                                                                "|  Рекордов игроков нету |\n" +
                                                                                "0------------------------0\n");
                                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                                        }
                                                                        game.ShowPlayer();
                                                                        Console.Write("Введите логин игрока которого хотите посмотреть  > ");
                                                                        string loginCheck = Console.ReadLine();
                                                                        while (game.MethodCheckLogin(loginCheck)!= true)
                                                                        {
                                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                                            Console.Write("Введён не верный логин игрока >");
                                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                                            loginCheck = Console.ReadLine();
                                                                        }
                                                                        Console.Clear();
                                                                        game.ShowWithdrawalOfOverallRecords(loginCheck);
                                                                        Console.ReadLine();
                                                                    }
                                                                    break;
                                                                case MenuRecord.Top3:
                                                                    {
                                                                        Console.Clear();
                                                                        if (game.MethotNumberOfPlayers())
                                                                        {
                                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                                            Console.WriteLine(
                                                                                "0------------------------0\n" +
                                                                                "|  Рекордов игроков нету |\n" +
                                                                                "0------------------------0\n");
                                                                            Console.ForegroundColor = ConsoleColor.Gray;
                                                                        }
                                                                        game.ShowTopThreeRecords();
                                                                        Console.ReadLine();
                                                                    }
                                                                    break;
                                                            }
                                                        }
                                                        break;
                                                    case GameMenu.Exit:
                                                        {
                                                            isWork = false;
                                                            login = "";
                                                            password = "";
                                                        }
                                                        break;
                                                }
                                            }
                                            break;
                                        case GameSelectionMenu.LogOutOfTheComputer:
                                            check = false;
                                            isWork = false;
                                            break;
                                    }
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            if (game.MethodCheckLoginAndPassword(login, password) == false)
                            {
                                Console.WriteLine(
                                    "0------------------------------0\n" +
                                    "|                              |\n" +
                                    "|  Неверные Логин или Пароль   |\n" +
                                    "|                              |\n" +
                                    "0------------------------------0\n");
                            }
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Нажмите любую кнопку... ");  
                            Console.ReadLine();
                        }
                        break;
                    case MenuStepOne.Registration:
                        {
                            Console.Clear();
                            Console.WriteLine(
                                "0───────────────────────────────────────────0\n" +
                                "│                                           │\n" +
                                "│ : Заполните форму регистрации аккаунта  : │\n" +
                                "│                                           │\n" +
                                "0───────────────────────────────────────────0\n");
                            Console.Write("Введите : Имя > ");
                            string name = Console.ReadLine();
                            Console.Write("Введите : Фамилию > ");
                            string surname = Console.ReadLine();
                            Console.Write("Введите : Возраст > ");
                            int age;
                            while (int.TryParse(Console.ReadLine(), out age) == false || age < 0)
                            {
                                Console.Write("Введите : Возраст > ");
                            }
                            Console.Write("Введите : Логин > ");
                            login = Console.ReadLine();
                            while (game.MethodCheckLogin(login))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Такой логин уже существует");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("Введите : Логин > ");
                                login = Console.ReadLine();
                            }
                            Console.Write("Введите : Пароль > ");
                            password = Console.ReadLine();
                            while (game.MethodCheckPassword(password))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Был введне неверно пароль");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("Введите : Пароль > ");
                                password = Console.ReadLine();
                            }
                            User user = new User(name, surname, age, login, password);
                            game.AddUser(user);
                            login = "";
                            password = "";

                        }
                        break;
                }

            }

        }
    }
}
