using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace TDL_Mock
{
    [ServiceContract]
    public interface ITDL
    {
        [OperationContract]
        [WebGet(UriTemplate = "test/{s}", RequestFormat = WebMessageFormat.Json)]
        string test(string s);

        [OperationContract]
        [WebInvoke(UriTemplate = "test2?s={s}&bla={bla}", ResponseFormat = WebMessageFormat.Json)]
        string test2(string s, string bla);
    }
}
