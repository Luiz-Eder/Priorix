using Google.Cloud.AIPlatform.V1;
using Grpc.Core;

namespace Priorix.Core.Services
{
    internal class GenerativeServiceClient
    {
        private CallInvoker invoker;

        public GenerativeServiceClient(CallInvoker invoker)
        {
            this.invoker = invoker;
        }

        internal void GenerateContent(GenerateContentRequest request)
        {
            throw new NotImplementedException();
        }

        internal Task GenerateContentAsync(GenerateContentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}