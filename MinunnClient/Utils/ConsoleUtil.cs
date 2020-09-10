﻿using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinunnClient.Utils
{
    public static class ConsoleUtil
    {
        public static void Info(string text) => WriteToConsole(ConsoleColor.Cyan, $"[MClient] [INFO] {text}");

        public static void Error(string text) => WriteToConsole(ConsoleColor.Red, $"[MClient] [ERROR] {text}");

        public static void Success(string text) => WriteToConsole(ConsoleColor.Green, $"[MClient] [SUCCESS] {text}");

        public static void Exception(Exception e)
        {
            WriteToConsole(ConsoleColor.Yellow, $"[MClient] [EXCEPTION (REPORT TO YAEKITH)]: ");
            WriteToConsole(ConsoleColor.Red, $"============= STACK TRACE ====================");
            WriteToConsole(ConsoleColor.White, e.StackTrace.ToString());
            WriteToConsole(ConsoleColor.Red, "===============================================");
            WriteToConsole(ConsoleColor.Red, "============== MESSAGE ========================");
            WriteToConsole(ConsoleColor.White, e.Message.ToString());
            WriteToConsole(ConsoleColor.Red, "===============================================");
        }
        public static void WriteToConsole(ConsoleColor col, string value)
        {
            System.Console.ForegroundColor = col;
            System.Console.WriteLine(value);
            System.Console.ResetColor();
        }
        public static void SetTitle(string title) => System.Console.Title = title;
    }
}
