namespace CodeItAirLines.Domain.DriveBehaviors
{
    public class NotDrive : IDriveBehavior
    {
        public bool StartDrive()
        {
            return false;
        }
    }
}