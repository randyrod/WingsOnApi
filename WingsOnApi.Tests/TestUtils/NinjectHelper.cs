using Ninject;
using WingsOnApi.App_Start;

namespace WingsOnApi.Tests.TestUtils
{
    internal  static class NinjectHelper
    {
        private static readonly IKernel _kernel;

        static NinjectHelper()
        {
            _kernel = NinjectWebCommon.CreateKernel();
        }

        public static T Get<T>() => _kernel.Get<T>();

    }
}