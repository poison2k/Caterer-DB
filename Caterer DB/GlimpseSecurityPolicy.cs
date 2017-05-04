

using Glimpse.AspNet.Extensions;
using Glimpse.Core.Extensibility;

namespace Caterer_DB
{
    public class GlimpseSecurityPolicy:IRuntimePolicy
    {
        public RuntimePolicy Execute(IRuntimePolicyContext policyContext)
        {
             
			 var httpContext = policyContext.GetHttpContext();
              
             if (!httpContext.User.IsInRole("GlimpseUsing"))
			 {
                 return RuntimePolicy.Off;
			 }

            return RuntimePolicy.On;
        }

        public RuntimeEvent ExecuteOn
        {
			
            get { return RuntimeEvent.EndRequest | RuntimeEvent.ExecuteResource; }
        }
    }
}
