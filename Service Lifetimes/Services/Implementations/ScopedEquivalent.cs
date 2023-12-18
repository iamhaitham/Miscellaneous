using Service_Lifetimes.Services.Interfaces;

namespace Service_Lifetimes.Services.Implementations
{
    public class ScopedEquivalent : IScopedEquivalent
    {
        private readonly Guid _scopedEquivalentGuid;

        public ScopedEquivalent()
        {
            _scopedEquivalentGuid = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return _scopedEquivalentGuid;
        }
    }
}
