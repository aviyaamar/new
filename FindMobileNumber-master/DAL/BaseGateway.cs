using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseGateway
    {
        protected LocalPhoneNumberEntity dbContext()
        {
            LocalPhoneNumberEntity context = new LocalPhoneNumberEntity();
            context.Configuration.ProxyCreationEnabled = false;
            context.Configuration.LazyLoadingEnabled = false;
            context.Database.CommandTimeout = 900;
            return context;
        }
    }
}
