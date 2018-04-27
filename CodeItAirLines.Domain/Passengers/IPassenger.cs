namespace CodeItAirLines.Domain.Passengers
{
    public interface IPassenger
    {
        EPassengerType GetPassengerType();
        bool DriverPerform();
    }
}