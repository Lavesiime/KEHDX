
# Save Format

This file is meant to document the save format used in KEHDX. This is describing the planned rework, and not the currently used (init - SHC) built format.

(For reference, there are 8192 available save values total, or 32768 bytes)

## General Values (0-63)

Starting off the save, there are 64 values (256 bytes) for general, non-state-specific stuff. The original idea was to put these after the stage entries, but some hardcoded indexes in the engine didn't quite want to let the idea be. 

| SaveRAM Index | Name | Description |
| - | - | - |
| `0` | Character | Used as being saved, as well as used during gameplay as a separate stage.playerListPos stand-in
| `1` | Difficulty | Radar Arrows, Normal Radar, Radar Disabled
| `2` | Radar Style | New, Old
| `3` | Last Stage Played | -
| `4-6` | Player Initials | Three characters, can be expanded to more if wished
| `7-15` | - | -
| `16` | Game Version | The version of the mod last played with
| `17` | Save File Version | The save file format that this save is following (note - will be 0 on saves from SHC)
| `18-31` | - | -
| `32` | Comp = P1 win count | (TODO: ask more about how we want VS to work, do we wanna go like base S2 route or just go original KEH route again?)
| `33` | Comp - P2 win count | -
| `34` | Comp - P3 win count | -
| `35` | Comp - P4 win count | -
| `36` | - | -
| `37` | vDPadSize | (Hard coded index from engine, applies to next few as well)
| `38` | vDPadOpacity | -
| `39` | vDPadX_Move | -
| `40` | vDPadY_Move | -
| `41` | vDPadX_Jump | -
| `42` | vDPadY_Jump | -
| `43-63` | - | -


## Stage Entries (64-8192)

The rest of the save data would be stage entries, with room for 254 stage enties in total. Each stage entry would be 32 values, or 128 bytes. In order, values would be:

| Index | Name | Description |
| - | - | - |
| `0` | Best Score | -
| `1` | Best Ring Count | -
| `2` | Best Time | -
| `3` | Total Play Count | -
| `4` | Total Death Count | -
| `5` | Total Play Time | -
| `6` | Total Ring Count | -
| `7-?` | Verification Values | Not quite planned out how this will work just yet...

