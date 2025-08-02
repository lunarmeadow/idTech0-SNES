#--------------------------------------------------------------------
# Makefile for SNES Super 3d Noah's Ark
#--------------------------------------------------------------------

# Paths

WDCROOT = C:\wdc

CC = $(WDCROOT)\Tools\bin\WDC816CC.exe
ASM = $(WDCROOT)\Tools\bin\WDC816AS.exe
LINK = $(WDCROOT)\Tools\bin\WDCLN.exe

INCLUDEPATH = $(WDCROOT)\Tools\include
LIBPATH = $(WDCROOT)\Tools\lib\cl

# Compiler/Linker Flags

DEFINES = -D__ORCAC__ 
BUILDFLAGS = -ML -SO -WL

#--------------------------------------------------------------------
#--------------------------------------------------------------------
# NOAH.SFC
#--------------------------------------------------------------------

NOAH = \
test.obj \
wolfasm.obj \
struc.obj \
tables.obj \
sounds.obj \
iosnes.obj \
wolfio.obj \
snesmain.obj \
intermis.obj \
newrefa.obj \
extdata.obj \
rwall.obj \
rsprite.obj \
music.obj \
intro.obj \
doors.obj \
enmove.obj \
enthink.obj \
level.obj \
missiles.obj \
plmove.obj \
plstuff.obj \
plthink.obj \
pushwall.obj \
refresh.obj \
refbsp.obj \
refspr.obj \
sight.obj \
wolfmain.obj \
statedef.obj

noah.sfc:	$(NOAH) noah.ld
	$(LINK) -F noah.ld -L $(LIBPATH)

.PHONY: clean

clean:
	rm -f *.obj *.sfc

#--------------------------------------------------------------------
# ASM FILES
#--------------------------------------------------------------------

test.obj:	snes.equ idmacros.asm test.asm
	$(ASM) test.asm

wolfasm.obj:	snes.equ idmacros.asm wolfasm.asm
	$(ASM) wolfasm.asm

struc.obj: struc.asm
	$(ASM) struc.asm

iosnes.obj:	snes.equ idmacros.asm iosnes.asm
	$(ASM) iosnes.asm

newrefa.obj:	snes.equ idmacros.asm newrefa.asm
	$(ASM) newrefa.asm

extdata.obj: extdata.asm
	$(ASM) extdata.asm

rwall.obj:	snes.equ idmacros.asm notes.asm rwall.asm
	$(ASM) rwall.asm

rsprite.obj:	snes.equ idmacros.asm rsprite.asm
	$(ASM) rsprite.asm


#--------------------------------------------------------------------
# C FILES
#--------------------------------------------------------------------

tables.obj:	wolfdef.h sprites.h tables.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) tables.c

sounds.obj: sounds.c
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) sounds.c

wolfio.obj:	refresh.h sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h wolfio.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) wolfio.c

snesmain.obj:	refresh.h sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h snesmain.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) snesmain.c

intermis.obj:	sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h intermis.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) intermis.c

music.obj:	refresh.h sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h music.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) music.c

intro.obj:	wolfdef.h sprites.h sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h intro.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) intro.c

doors.obj:	wolfdef.h sprites.h doors.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) doors.c

enmove.obj:	wolfdef.h sprites.h enmove.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) enmove.c

enthink.obj:	wolfdef.h sprites.h enthink.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) enthink.c

level.obj:	wolfdef.h sprites.h level.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) level.c

missiles.obj:	wolfdef.h sprites.h missiles.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) missiles.c

plmove.obj:	wolfdef.h sprites.h plmove.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) plmove.c

plstuff.obj:	wolfdef.h sprites.h plstuff.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) plstuff.c

plthink.obj:	wolfdef.h sprites.h plthink.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) plthink.c

pushwall.obj:	wolfdef.h sprites.h pushwall.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) pushwall.c

refresh.obj:	refresh.h refresh.c
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) refresh.c

refbsp.obj:	refresh.h refbsp.c
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) refbsp.c

refspr.obj:	refresh.h sprstruc.c refspr.c
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) refspr.c

sight.obj:	wolfdef.h sprites.h sight.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) sight.c

wolfmain.obj:	wolfdef.h sprites.h wolfmain.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) wolfmain.c

statedef.obj:	wolfdef.h sprites.h statedef.c sounds.h states.h
	$(CC) $(DEFINES) $(BUILDFLAGS) -I $(INCLUDEPATH) statedef.c

