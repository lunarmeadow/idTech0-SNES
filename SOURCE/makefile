#--------------------------------------------------------------------
# Makefile for SNES Super 3d Noah's Ark
#--------------------------------------------------------------------

# Paths

CC = WDC816CC.exe
ASM = WDC816AS.exe
LINK = WDCLN.exe

INCDIR = $(WDC_INC_65816)
LIBPATH = $(WDC_LIB)

OUTROM = out/noah.sfc

# Compiler/Linker Flags

DEFINES = -D__ORCAC__ 
CFLAGS = -ML -SO -WL

# Post-Build Tools

DATAINS = "BUILD/DataInsert.exe"

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

# PRE-BUILD: Delete ROM to allow new BUILD
# POST-BUILD: Delete OBJ files to reduce clutter and allow faster builds by simply running make
noah.sfc: clean_rom $(NOAH) noah.ld
	$(LINK) -F noah.ld -L "$(LIBPATH)\cl" && \
	$(MAKE) clean_obj && \
	$(DATAINS) --rom $(OUTROM) --dir BUILD/DATA/

.PHONY: clean clean_rom clean_obj

clean_rom:
	rm -f $(OUTROM)

clean_obj:
	rm -f *.obj

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
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) tables.c

sounds.obj: sounds.c
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) sounds.c

wolfio.obj:	refresh.h sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h wolfio.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) wolfio.c

snesmain.obj:	refresh.h sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h snesmain.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) snesmain.c

intermis.obj:	sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h intermis.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) intermis.c

music.obj:	refresh.h sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h music.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) music.c

intro.obj:	wolfdef.h sprites.h sneswolf.h wolfdef.h sprites.h version.h extdata.h noahmisc.h iosnes.h intro.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) intro.c

doors.obj:	wolfdef.h sprites.h doors.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) doors.c

enmove.obj:	wolfdef.h sprites.h enmove.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) enmove.c

enthink.obj:	wolfdef.h sprites.h enthink.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) enthink.c

level.obj:	wolfdef.h sprites.h level.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) level.c

missiles.obj:	wolfdef.h sprites.h missiles.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) missiles.c

plmove.obj:	wolfdef.h sprites.h plmove.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) plmove.c

plstuff.obj:	wolfdef.h sprites.h plstuff.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) plstuff.c

plthink.obj:	wolfdef.h sprites.h plthink.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) plthink.c

pushwall.obj:	wolfdef.h sprites.h pushwall.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) pushwall.c

refresh.obj:	refresh.h refresh.c
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) refresh.c

refbsp.obj:	refresh.h refbsp.c
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) refbsp.c

refspr.obj:	refresh.h sprstruc.c refspr.c
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) refspr.c

sight.obj:	wolfdef.h sprites.h sight.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) sight.c

wolfmain.obj:	wolfdef.h sprites.h wolfmain.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) wolfmain.c

statedef.obj:	wolfdef.h sprites.h statedef.c sounds.h states.h
	$(CC) $(DEFINES) $(CFLAGS) -I $(INCDIR) statedef.c