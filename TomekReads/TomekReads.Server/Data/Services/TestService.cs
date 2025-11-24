namespace TomekReads.Server.Data.Services
{
    public class TestService
    {
        private string _arm;
        public string Arm
        {
            get { return _arm; }
            set {  _arm = value; }
        }

        public string getArm(string arm)
        {
            Arm = arm;
            return Arm;
        }
    }
}
