using Service_Lifetimes.Services.Interfaces;

namespace Service_Lifetimes.Services.Implementations
{
    public class SingletonEquivalent : ISingletonEquivalent
    {
        private readonly Guid _singletonEquivalent;

        public SingletonEquivalent() 
        {
            _singletonEquivalent = Guid.NewGuid();
        }

        public Guid GetGuid() 
        {
            return _singletonEquivalent;
        }
    }
}
