using Microsoft.AspNetCore.Mvc;
using Service_Lifetimes.Services.Implementations;
using Service_Lifetimes.Services.Interfaces;

namespace Service_Lifetimes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceLifetimesController : ControllerBase
    {
        // Singleton
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;
        private readonly static ISingletonEquivalent _singletonEquivalent;

        // Scoped
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly IScopedEquivalent _scopedEquivalent;

        // Transient
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;

        public ServiceLifetimesController(
            ISingletonService singletonService1,
            ISingletonService singletonService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ITransientService transientService1,
            ITransientService transientService2
            )
        {
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _scopedEquivalent = new ScopedEquivalent();
            _transientService1 = transientService1;
            _transientService2 = transientService2;
        }

        static ServiceLifetimesController()
        {
            _singletonEquivalent = new SingletonEquivalent();
        }

        [HttpGet]
        public ActionResult Get()
        {
            // Singleton
            var singletonResult1 = _singletonService1.GetGuid();
            var singletonResult2 = _singletonService2.GetGuid();

            // Signleton Equivalent
            var singletonEquivalentResult1 = _singletonEquivalent.GetGuid();
            var singletonEquivalentResult2 = _singletonEquivalent.GetGuid();

            // Scoped
            var scopedResult1 = _scopedService1.GetGuid();
            var scopedResult2 = _scopedService2.GetGuid();

            // Scoped Equivalent
            var scopedEquivalentResult1 = _scopedEquivalent.GetGuid();
            var scopedEquivalentResult2 = _scopedEquivalent.GetGuid();

            // Transient
            var transientResult1 = _transientService1.GetGuid();
            var transientResult2 = _transientService2.GetGuid();

            // Transient Equivalent
            var transientEquivalentResult1 = new TransientEquivalent().GetGuid();
            var transientEquivalentResult2 = new TransientEquivalent().GetGuid();


            var result = $"""
                      *** SINGLETON ***
                      singletonResult1 -> {singletonResult1}
                      singletonResult2 -> {singletonResult2}

                      *** SINGLETON EQUIVALENT ***
                      singletonEquivalentResult1 -> {singletonEquivalentResult1}
                      singletonEquivalentResult2 -> {singletonEquivalentResult2}

                      *** SCOPED ***
                      scopedResult1 -> {scopedResult1}
                      scopedResult2 -> {scopedResult2}

                      *** SCOPED EQUIVALENT ***
                      scopedEquivalentResult1 -> {scopedEquivalentResult1}
                      scopedEquivalentResult2 -> {scopedEquivalentResult2}

                      *** TRANSIENT ***
                      transientResult1 -> {transientResult1}
                      transientResult2 -> {transientResult2}

                      *** TRANSIENT EQUIVALENT ***
                      transientEquivalentResult1 -> {transientEquivalentResult1}
                      transientEquivalentResult2 -> {transientEquivalentResult2}
                      """;

            return Ok(result);
        }
    }
}
