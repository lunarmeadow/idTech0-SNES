using System;
using System.CommandLine;
using System.IO;
using System.Text;

namespace MapParser;

internal class Program
{
    private static readonly int LeftHand = 0;
    private static readonly int RightHand = 1;

    static void Main(string[] args)
    {
        Option<FileInfo> mapInput = new("--map")
        {
            Description = "The symbol map to parse symbols from. (map format)",
            Required = true
        };

        Option<FileInfo> symOutput = new("--sym")
        {
            Description = "The Mesen symbol file to export. (mlb format)",
            Required = true
        };

        RootCommand root = new("A tool to parse WDCTools linker maps into Mesen symbol files for ease of debugging.");
        root.Add(mapInput);
        root.Add(symOutput);

        ParseResult validate = root.Parse(args);

        if (validate.GetValue(mapInput) is FileInfo map &&
            map.Extension == ".map" &&
            validate.GetValue(symOutput) is FileInfo sym &&
            sym.Extension == ".mlb")
            ParseMap(map, sym);
        else
            Console.WriteLine("Invalid input!");
    }

    private static void ParseMap(FileInfo map, FileInfo sym)
    {
        string[] parseLines = File.ReadAllLines(map.FullName);
        StringBuilder outBuild = new();

        for (int line = 0; line < parseLines.Length; line++)
        {
            // trim and split off for parsing
            string currLine = parseLines[line].TrimStart();

            if (string.IsNullOrWhiteSpace(currLine) || currLine.Contains("Section"))
                continue;

            string[] split = currLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (split.Length < 2)
                continue;

            // normalize split strings
            string lhs = split[LeftHand].ToUpper();
            string rhs = split[RightHand].TrimStart('~');

            // mask out
            // 00XX0000
            // 0000XXXX
            byte bank = Convert.ToByte(lhs.Substring(2, 2), 16);
            ushort addr = Convert.ToUInt16(lhs.Substring(4, 4), 16);

            // filter out section boundaries
            if (!rhs.Contains("_BEG_") &&
                !rhs.Contains("_END_"))
            switch (bank)
            {
                case 0xC0:
                    // CODE segment
                    outBuild.AppendLine($"SnesPrgRom:{addr:X4}:{rhs}:Auto-generated function");
                    break;
                case 0x7E:
                    // DATA/UDATA segment
                    outBuild.AppendLine($"SnesWorkRam:{addr:X4}:{rhs}:Auto-generated variable");
                    break;
            }
        }

        Console.WriteLine("Finished assembling .mlb file!");

        if(File.Exists(sym.FullName))
           File.Delete(sym.FullName);

        using StreamWriter sw = new(File.OpenWrite(sym.FullName));
        sw.Write(outBuild);
    }
}
