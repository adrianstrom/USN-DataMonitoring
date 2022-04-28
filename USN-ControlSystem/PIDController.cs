namespace USN_ControlSystem
{
    public class PIDController
    {
        private double _kp;
        private double _ti;
        private double _td;

        public PIDController(double Kp, double Ti, double Td)
        {
            _kp = Kp;
            _ti = Ti;
            _td = Td;
        }
    }
}
