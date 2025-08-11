using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FreeBytes
{
    internal class Program
    {
        private static Dictionary<string, int> segments = new()
        {
            { "PAGE0", 256 },
            { "CODE", 65536 },
            { "DATA", 65536 },
            { "UDATA", 65536 },
            { "boot", 992 },
            { "vectors", 32 },
            { "primitiv", 65536 } // custom code segment, *probably* just a 64k bank.
        };

        private static void Main(string[] args)
        {
            Option<FileInfo> bnk = new("--bank")
            {
                Description = "The ROM bank to parse used bytes from",
                Required = true
            };

            RootCommand root = new("A tool to parse WDCTools bank files to show free bytes in each section.");
            root.Add(bnk);

            ParseResult validate = root.Parse(args);

            if (validate.GetValue(bnk) is FileInfo bank &&
                bank.Extension == ".bnk")
                ParseBank(bank);
            else
                Console.WriteLine("Invalid input!");
        }

        private static void ParseBank(FileInfo bank)
        {
            string hexRegex = @"([0-9A-F]+)H";

            string[] getLines = File.ReadAllLines(bank.FullName);
            foreach (string line in getLines)
            {
                if (string.IsNullOrWhiteSpace(line) ||
                    line.Contains("Section:") ||
                    line.Contains("Total"))
                    continue;

                Match rMatch = Regex.Match(line, hexRegex);
                if (!rMatch.Success)
                    continue;

                string seg = new string(line.TakeWhile(ch => ch != ' ').ToArray());
                ushort segSize = Convert.ToUInt16(rMatch.Groups[1].Value, 16);
                ushort bytesFree = (ushort)(segments[seg] - segSize);

                // Console.WriteLine($"\n{segSize} bytes used in {seg}, {bytesFree} bytes free");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"\n{segSize}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" bytes used in ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{seg}, ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{bytesFree} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("bytes free.\n");

                // vectors will always be 32-bytes long.
                if (bytesFree == 0 && seg != "vectors")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n!!! WARNING !!! NO FREE BYTES IN {seg.ToUpper()} SECTION !!!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
