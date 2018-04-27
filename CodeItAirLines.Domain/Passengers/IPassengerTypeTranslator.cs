namespace CodeItAirLines.Domain.Passengers
{
    public interface IPassengerTypeTranslator
    {
        string Translate(EPassengerType type);
    }
}