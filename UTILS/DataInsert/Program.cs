using System;
using System.CommandLine;
using System.Data.Common;

internal class Program
{
    private const int pDEMO1 = 0xE000;
    private const int pDEMO2 = 0xF000;
    private const int pSCALERS = 0x10000;
    private const int pEXTDATA = 0x20000;

    private const byte pad = 0x00;

    private static void Main(string[] args)
    {
        Option<FileInfo> romInput = new("--rom")
        {
            Description = "The ROM to insert the data blobs into.",
            Required = true
        };

        Option<DirectoryInfo> dataDir = new("--dir")
        {
            Description = "The directory containing DEMO1.bin, DEMO2.bin, SCALERS.bin, and EXTDATA.bin",
            Required = true
        };

        RootCommand root = new("A tool to insert data blobs into a compiled ROM");
        root.Add(romInput);
        root.Add(dataDir);

        ParseResult validate = root.Parse(args);

        if (validate.GetValue(romInput) is FileInfo rom &&
            validate.GetValue(dataDir) is DirectoryInfo dir)
            PopulateROM(rom, dir);
        else
            Console.WriteLine("Invalid input!");
    }

    private static void PopulateROM(FileInfo rom, DirectoryInfo dir)
    {
        var insertData = new[]
        {
            (Offset: 0xE000, Path: Path.Combine(dir.FullName, "DEMO1.BIN")),
            (Offset: 0xF000, Path: Path.Combine(dir.FullName, "DEMO2.BIN")),
            (Offset: 0x10000, Path: Path.Combine(dir.FullName, "SCALERS.BIN")),
            (Offset: 0x20000, Path: Path.Combine(dir.FullName, "EXTDATA.BIN"))
        };

        using FileStream outRom = new(rom.FullName, FileMode.Open, FileAccess.ReadWrite);

        foreach (var (offset, blobPath) in insertData)
        {
            string fileName = Path.GetFileName(blobPath);

            if (!File.Exists(blobPath))
                throw new FileNotFoundException($"{fileName} not found!");

            byte[] data = File.ReadAllBytes(blobPath);
            
            outRom.Seek(offset, SeekOrigin.Begin);

            if (outRom.Length < offset + data.Length)
                throw new InvalidDataException($"Insertion of {fileName} would result in over-running end of file! Aborting!");

            for (int chk = 0; chk < data.Length; chk++)
            {
                if (outRom.ReadByte() != pad)
                    throw new InvalidDataException($"Insertion of {fileName} would collide with non-pad byte at 0x{(offset + chk):X}! Aborting!");
            }

            outRom.Seek(offset, SeekOrigin.Begin);
            outRom.Write(data, 0, data.Length);

            Console.WriteLine($"{Path.GetFileName(blobPath)} write at 0x{offset:X} success!");
        }

        Console.WriteLine("ROM build complete!");
    }
}