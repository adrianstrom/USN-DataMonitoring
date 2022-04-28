namespace USN_ControlSystem
{
    public class PIDController
    {
        public double Kp { get; set; }
        public double Ti { get; set; }
        public double Td { get; set; }

        public bool Manual { get; set; }

        public double SetPoint { get; set; }
        public double MeasuredValue { get; set; }

        public double Error => SetPoint - MeasuredValue;

        public PIDController(double Kp, double Ti, double Td)
        {
            this.Kp = Kp;
            this.Ti = Ti;
            this.Td = Td;
        }
    }
}
