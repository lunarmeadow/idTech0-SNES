# Building extdata.bin
The EXTDATA blob is essentially all of the data such as maps, music, sounds, and graphics that are required by the game.

To build it, you need to run `romlink extdata` in DOS, which uses the extdata.rl script to align the data along 64k banks. 
Moreover, the tool automatically generates a C header containing the absolute offsets for each section in EXTDATA.
The resulting EXTDATA.ROM file must be inserted at position 0x20000 in the compiled ROM, and a tool for the insertion of external dependencies such as EXTDATA at the correct ROM offset will soon be provided by this repo.