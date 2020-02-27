using NUnit.Framework;
using ServiceBasis;

namespace ServiceBase.Tests
{
    [TestFixture]
    public class ExtensionDefinitionReaderTests
    {
        public string ExecutionLocation { get; set; }


        public void Initialize()
        {
        }

        [Test]
        public void Test_Create_Instance()
        {
            var instance = new DefinitionReader();
        }
    }
}