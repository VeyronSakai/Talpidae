namespace Domain.Model
{
    public interface IInGameTimeFactory
    {
        InGameTime Create(uint initialLimitTime);
    }
}