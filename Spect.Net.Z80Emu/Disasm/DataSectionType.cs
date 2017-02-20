﻿namespace Spect.Net.Z80Emu.Disasm
{
    /// <summary>
    /// The type of the disassembly data section
    /// </summary>
    public enum DataSectionType
    {
        /// <summary>Defines .text section</summary>
        Text,

        /// <summary>Defines .db section</summary>
        Byte,

        /// <summary>Defines a .dw section</summary>
        Word
    }
}