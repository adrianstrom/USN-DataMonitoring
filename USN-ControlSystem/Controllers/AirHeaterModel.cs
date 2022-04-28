namespace USN_ControlSystem.Controllers
{
    public class AirHeaterModel
    {
        public double OutletTemperature { get; set; }
        public double EnvironmentTemperature { get; set; }
        public double ControlSignal { get; set; }
        public double HeaterGain { get; set; }


        public AirHeaterModel()
        {

        }
    }
}
