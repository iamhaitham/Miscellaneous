using Service_Lifetimes.Services.Interfaces;

namespace Service_Lifetimes.Services.Implementations
{
    public class TransientService : ITransientService
    {
        private readonly Guid _transientGuid;

        public TransientService()
        {
            _transientGuid = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return _transientGuid;
        }
    }
}
