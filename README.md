# idTech0-SNES

A project to take the source code release of Super Noah's Ark 3D and create a modern development environment for the Wolfenstein 3D engine on SNES. Furthermore, this project serves to facilitate a reconstruction of the Wolfenstein 3D development repository, allowing for SNES Wolf3D ROM hacks.

## Setup

Download [WDCTools](https://www.westerndesigncenter.com/wdc/WDCTools/WDCTOOLS.exe) and install it as normal, or select a convenient path. Note that as of now, the makefile will have to be manually updated to point to the WDCTools root directory, if it is not installed in the default location.

WDCTools works on Linux via WINE, but this configuration is not officially supported by this project. Your mileage may vary, please report any issues with this configuration in the issue tracker.

You will also need a way to run standard Makefiles on Windows environments. 

The `make` package on Chocolatey is a good choice, or you could use Cygwin or MinGW's make.

An MS-DOS environment is required for the legacy tooling present within the repo, and [DOSBox-X](https://github.com/joncampbell123/dosbox-x/releases) is strongly recommended for this purpose.

## Documentation

Below is relevant, official WDC documentation for the 65816 CPU and WDCTools compiler suite.

[65816 Datasheet](https://www.westerndesigncenter.com/wdc/documentation/w65c816s.pdf)

[Compiler/Optimizer](http://www.wdc65xx.com/wdc/documentation/816cc.pdf)

[Assembler/Linker/Librarian](http://www.wdc65xx.com/wdc/documentation/Assembler_Linker.pdf)

There are small pieces of documentation within the codebase as well, which have been put into a `DOCS` folder within each directory they're found.

## Tech

The original source code depended on Zardoz, an old, proprietary, and long lost 6502-series C compiler/assembler/linker suite for MS-DOS. Luckily, Western Design Centre bought Zardoz, and ported it to Windows as freely available software. The resulting binaries are minimally different to the original compiler, but some code sections may slightly vary in size.

## Authors

- id Software
- Rebecca Heineman
- Color Dreams