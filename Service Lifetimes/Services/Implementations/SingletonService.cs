using Service_Lifetimes.Services.Interfaces;

namespace Service_Lifetimes.Services.Implementations
{
    public class SingletonService : ISingletonService
    {
        private readonly Guid _singletonGuid;

        public SingletonService() 
        {
            _singletonGuid = Guid.NewGuid();
        }

        public Guid GetGuid() 
        {
            return _singletonGuid;
        }
    }
}
