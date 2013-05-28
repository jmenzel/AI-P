using ProxyLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyLib
{
    public interface IProxyClient
    {
         T getServiceHost<T>(ClientInfo info);
    }
}
