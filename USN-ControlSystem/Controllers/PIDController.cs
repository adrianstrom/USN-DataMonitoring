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
        public double ProcessVariable { get; set; } // This should be temperature for the Air Heater. Continously update this value from sensor.

        public double ControlSignal { get; set; }

        public double Error => SetPoint - ProcessVariable;

        private double _lastState;

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
            var u_p = Kp * Error;
            var u_i = _lastState + (Kp / Ti) * TimeStep * Error;
            var u_d = 0;
            var u_tot = u_p + u_i + u_d;
            _lastState = u_tot;
            return u_tot;
        }
    }
}
