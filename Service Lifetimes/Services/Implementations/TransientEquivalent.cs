using Service_Lifetimes.Services.Interfaces;

namespace Service_Lifetimes.Services.Implementations
{
    public class TransientEquivalent : ITransientEquivalent
    {
        private readonly Guid _transientEquivalentGuid;

        public TransientEquivalent()
        {
            _transientEquivalentGuid = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return _transientEquivalentGuid;
        }
    }
}
