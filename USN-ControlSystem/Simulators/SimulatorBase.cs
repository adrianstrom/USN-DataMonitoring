namespace USN_ControlSystem.Simulators
{
    public abstract class SimulatorBase
    {
        public double TimeStep { get; set; }
        public int StartTime { get; set; } // in seconds
        public int EndTime { get; set; } // in seconds
        public double NumberOfSimulations => ((EndTime - StartTime) / TimeStep) + 1;
    }
}
