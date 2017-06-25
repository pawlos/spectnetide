﻿namespace Spect.Net.SpectrumEmu.Machine
{
    /// <summary>
    /// This class provides options for the ExecuteCycle function.
    /// </summary>
    public class ExecuteCycleOptions
    {
        /// <summary>
        /// The emulation mode to use
        /// </summary>
        public EmulationMode EmulationMode { get; }

        /// <summary>
        /// The debug mode to use
        /// </summary>
        public DebugStepMode DebugStepMode { get; }

        /// <summary>
        /// Turns on or off fast mode.
        /// </summary>
        /// <remarks>
        /// In fast mode, Spectrum runs as fast as the CPU allows. It does not
        /// wait for frame sync
        /// </remarks>
        public bool FastMode { get; }

        /// <summary>
        /// Initializes the options
        /// </summary>
        /// <param name="emulationMode">Execution emulation mode</param>
        /// <param name="debugStepMode">Debugging execution mode</param>
        /// <param name="fastMode">Fast mode</param>
        public ExecuteCycleOptions(EmulationMode emulationMode = EmulationMode.Continuous, 
            DebugStepMode debugStepMode = DebugStepMode.StopAtBreakpoint, bool fastMode = false)
        {
            EmulationMode = emulationMode;
            DebugStepMode = debugStepMode;
            FastMode = fastMode;
        }
    }
}