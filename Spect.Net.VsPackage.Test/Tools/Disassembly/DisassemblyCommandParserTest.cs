﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Spect.Net.VsPackage.Tools.Disassembly;

namespace Spect.Net.VsPackage.Test.Tools.Disassembly
{
    [TestClass]
    public class DisassemblyCommandParserTest
    {
        [TestMethod]
        public void ParserRecognizesEmptyCommand()
        {
            // --- Act
            var p1 = new DisassemblyCommandParser(null);
            var p2 = new DisassemblyCommandParser("    ");

            // --- Assert
            p1.Command.ShouldBe(DisassemblyCommandType.None);
            p2.Command.ShouldBe(DisassemblyCommandType.None);
        }

        [TestMethod]
        public void ParserRecognizesGotoCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("g45BF");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Goto);
            p.Address.ShouldBe((ushort)0x45BF);
        }

        [TestMethod]
        public void ParserRecognizesGotoCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("G45BF");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Goto);
            p.Address.ShouldBe((ushort)0x45BF);
        }

        [TestMethod]
        public void ParserRecognizesGotoCommand3()
        {
            // --- Act
            var p = new DisassemblyCommandParser("g  45BF");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Goto);
            p.Address.ShouldBe((ushort)0x45BF);
        }

        [TestMethod]
        public void ParserRefusesInvalidGotoCommand()
        {
            // --- Act
            var p = new DisassemblyCommandParser("45BQ");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Invalid);
        }

        [TestMethod]
        public void ParserRecognizesAddLabelCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("l 3456 This is my label...");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Label);
            p.Address.ShouldBe((ushort)0x3456);
            p.Arg1.ShouldBe("This is my label...");
        }

        [TestMethod]
        public void ParserRecognizesAddLabelCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("L3456 This is my label...");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Label);
            p.Address.ShouldBe((ushort)0x3456);
            p.Arg1.ShouldBe("This is my label...");
        }

        [TestMethod]
        public void ParserRecognizesRemoveLabelCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("L 3fC6    ");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Label);
            p.Address.ShouldBe((ushort)0x3FC6);
            p.Arg1.ShouldBe("");
        }

        [TestMethod]
        public void ParserRecognizesRemoveLabelCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("l 8");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Label);
            p.Address.ShouldBe((ushort)0x0008);
            p.Arg1.ShouldBeNull();
        }

        [TestMethod]
        public void ParserRecognizesInvalidLabelCommand()
        {
            // --- Act
            var p = new DisassemblyCommandParser("L 3fCBD4");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Invalid);
        }

        [TestMethod]
        public void ParserRecognizesAddCommentCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("c 3456 This is my comment...");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Comment);
            p.Address.ShouldBe((ushort)0x3456);
            p.Arg1.ShouldBe("This is my comment...");
        }

        [TestMethod]
        public void ParserRecognizesAddCommentCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("C3456 This is my comment...");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Comment);
            p.Address.ShouldBe((ushort)0x3456);
            p.Arg1.ShouldBe("This is my comment...");
        }

        [TestMethod]
        public void ParserRecognizesRemoveCommentCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("C 3fC6    ");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Comment);
            p.Address.ShouldBe((ushort)0x3FC6);
            p.Arg1.ShouldBe("");
        }

        [TestMethod]
        public void ParserRecognizesRemoveCommentCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("C 3fC6");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Comment);
            p.Address.ShouldBe((ushort)0x3FC6);
            p.Arg1.ShouldBe(null);
        }

        [TestMethod]
        public void ParserRecognizesInvalidCommentCommand()
        {
            // --- Act
            var p = new DisassemblyCommandParser("C 3fCBD4");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Invalid);
        }

        [TestMethod]
        public void ParserRecognizesAddPrefixCommentCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("p 3456 This is my comment...");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.PrefixComment);
            p.Address.ShouldBe((ushort)0x3456);
            p.Arg1.ShouldBe("This is my comment...");
        }

        [TestMethod]
        public void ParserRecognizesAddPrefixCommentCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("P3456 This is my comment...");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.PrefixComment);
            p.Address.ShouldBe((ushort)0x3456);
            p.Arg1.ShouldBe("This is my comment...");
        }

        [TestMethod]
        public void ParserRecognizesRemovePrefixCommentCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("P 3fC6    ");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.PrefixComment);
            p.Address.ShouldBe((ushort)0x3FC6);
            p.Arg1.ShouldBe("");
        }

        [TestMethod]
        public void ParserRecognizesRemovePrefixCommentCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("P 3fC6");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.PrefixComment);
            p.Address.ShouldBe((ushort)0x3FC6);
            p.Arg1.ShouldBe(null);
        }

        [TestMethod]
        public void ParserRecognizesInvalidPrefixCommentCommand()
        {
            // --- Act
            var p = new DisassemblyCommandParser("P 3fCBD4");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Invalid);
        }

        [TestMethod]
        public void ParserRecognizesSetBreakpointCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("sb45BF");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.SetBreakPoint);
            p.Address.ShouldBe((ushort)0x45BF);
        }

        [TestMethod]
        public void ParserRecognizesSetBreakpointCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("SB 45BF");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.SetBreakPoint);
            p.Address.ShouldBe((ushort)0x45BF);
        }

        [TestMethod]
        public void ParserRefusesInvalidSetBreakpointCommand()
        {
            // --- Act
            var p = new DisassemblyCommandParser("sb45BFE345");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Invalid);
        }

        [TestMethod]
        public void ParserRecognizesToggleBreakpointCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("tb45BF");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.ToggleBreakPoint);
            p.Address.ShouldBe((ushort)0x45BF);
        }

        [TestMethod]
        public void ParserRecognizesToggleBreakpointCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("TB 45BF");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.ToggleBreakPoint);
            p.Address.ShouldBe((ushort)0x45BF);
        }

        [TestMethod]
        public void ParserRefusesInvalidToggleBreakpointCommand()
        {
            // --- Act
            var p = new DisassemblyCommandParser("TB45BFE345");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Invalid);
        }

        [TestMethod]
        public void ParserRecognizesClearBreakpointCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("rb45BF");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.RemoveBreakPoint);
            p.Address.ShouldBe((ushort)0x45BF);
        }

        [TestMethod]
        public void ParserRecognizesClearBreakpointCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("RB 45BF");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.RemoveBreakPoint);
            p.Address.ShouldBe((ushort)0x45BF);
        }

        [TestMethod]
        public void ParserRefusesInvalidClearBreakpointCommand()
        {
            // --- Act
            var p = new DisassemblyCommandParser("rb45BFE345");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.Invalid);
        }

        [TestMethod]
        public void ParserRecognizesEraseAllBreakpointCommand1()
        {
            // --- Act
            var p = new DisassemblyCommandParser("eb");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.EraseAllBreakPoint);
        }

        [TestMethod]
        public void ParserRecognizesEraseAllBreakpointCommand2()
        {
            // --- Act
            var p = new DisassemblyCommandParser("EB");

            // --- Assert
            p.Command.ShouldBe(DisassemblyCommandType.EraseAllBreakPoint);
        }

    }
}