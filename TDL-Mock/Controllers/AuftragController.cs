using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TDL_REST_Service.Models;

namespace TDL_REST_Service.Controllers
{
    public class AuftragController : ApiController
    {
        static readonly IAuftragRepository repository = new AuftragRepository();



        public IEnumerable<Auftrag> GetAllAuftraege()
        {
            return repository.GetAll();
        }

        public Auftrag GetAuftrag(int id)
        {
            Auftrag item = repository.Get(id);
            if (item == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return item;
        }

        public HttpResponseMessage PostAuftrag(Auftrag item)
        {
            item = repository.Add(item);

            var response = Request.CreateResponse<Auftrag>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutAuftrag(int id, Auftrag auftrag)
        {
            auftrag.Id = id;
            if (!repository.Update(auftrag)) throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        public void DeleteProduct(int id)
        {
            Auftrag item = repository.Get(id);
            if (item == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            repository.Remove(id);
        }
    }
}
