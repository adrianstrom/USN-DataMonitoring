namespace USN_ControlSystem
{
    public class PIDController
    {
        public double Kp { get; set; }
        public double Ti { get; set; }
        public double Td { get; set; }

        public double TimeStep { get; set; }

        public bool Manual { get; set; }

        public double SetPoint { get; set; }
        public double MeasuredValue { get; set; }

        public double ControlSignal { get; set; }

        public double Error => SetPoint - MeasuredValue;

        public PIDController(double Kp, double Ti = default, double Td = default)
        {
            this.Kp = Kp;
            this.Ti = Ti;
            this.Td = Td;
        }

        public double GetControlSignal()
        {
            if (Manual)
            {
                return ControlSignal;
            }
            var lastprocessvalue = 0;
            var u_p = Kp * Error;
            var u_i = lastprocessvalue + (Kp / Ti) * TimeStep * Error;
            // TODO: u_d (deriviate term)
            return u_p + u_i;
        }
    }
}
