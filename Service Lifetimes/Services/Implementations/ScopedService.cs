using Service_Lifetimes.Services.Interfaces;

namespace Service_Lifetimes.Services.Implementations
{
    public class ScopedService : IScopedService
    {
        private readonly Guid _scopedGuid;

        public ScopedService() 
        {
            _scopedGuid = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return _scopedGuid;
        }
    }
}
