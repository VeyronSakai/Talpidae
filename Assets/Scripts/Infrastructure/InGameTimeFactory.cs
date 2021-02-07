using Domain.Model;

namespace Infrastructure
{
    public class InGameTimeFactory : IInGameTimeFactory
    {
        public InGameTime Create(uint initialLimitTime)
        {
            return new InGameTime(initialLimitTime);
        }
    }
}