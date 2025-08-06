using System;
using System.CommandLine;
using System.IO;

namespace Padder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Option<FileInfo> romInput = new("--rom")
            {
                Description = "The ROM to pad to a 2^n boundary",
                Required = true
            };

            RootCommand root = new();

            root.Add(romInput);

            ParseResult validate = root.Parse(args);

            if(validate.GetValue(romInput) is FileInfo rom)
            {
                Pad(rom);
            }
        }

        private static void Pad(FileInfo rom)
        {
            using FileStream outRom = new(rom.FullName, FileMode.Open, FileAccess.ReadWrite);

            int trgSize = FetchNextNearest2n((int)outRom.Length);
            int romLen = (int)outRom.Length;

            int diffBytes = trgSize - romLen;

            if(diffBytes == 0)
            {
                Console.WriteLine("File is already 2^n bytes!");
                return;
            }    

            Console.WriteLine($"Input file is 0x{romLen:X} bytes, expanding to 0x{trgSize:X}...");
            Console.WriteLine($"Free bytes: 0x{diffBytes:X}");

            outRom.SetLength(trgSize);

            Console.WriteLine("Done writing!");
        }

        private static int FetchNextNearest2n(int num)
        {
            if (num <= 0) return 1;
            num--;
            num |= num >> 1;
            num |= num >> 2;
            num |= num >> 4;
            num |= num >> 8;
            num |= num >> 16;
            num++;
            return num;
        }
    }
}
