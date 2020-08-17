using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Elasticsearch.Net;
using ElasticsearchLibrary;
using Nest;

namespace ELKCRUDApp.Areas.ElasticsearchApi.Controllers
{
    public class SearchApiController : ApiController
    {
        ElasticsearchConnector elasticsearchConnector;
        public SearchApiController()
        {
            elasticsearchConnector = new ElasticsearchConnector();
        }
        // GET: api/SearchApi

        // public async Task<string> GetAsync()
        public async Task<IEnumerable<UserModel>> GetAsync()
        {
           /* //creating index
            var user = new UserModel
            {
                Id = 1,
                Name = "Rezi",
            };
            var indexResponse = elasticsearchConnector.ElasticClient.Index(user, i => i.Index("bkuser"));
            // byte[] responseBytes = indexResponse.Body;
            var asyncIndexResponse = await elasticsearchConnector.ElasticClient.IndexDocumentAsync(user);
            string responseString = indexResponse.ToString();
            return responseString;*/

            //Searching data from 
            var searchResponse =  elasticsearchConnector.ElasticClient.Search<UserModel>(s => s
                               .Index("bkupgrade-jagadeesh"));
            return searchResponse.Documents;


        }

   
        // GET: api/SearchApi/5
        public async Task<string> GetAsync(int id)
        {
            var user = new UserModel
            {
                Id = 1
            };
            var indexResponse = elasticsearchConnector.ElasticClient.Index(user,i=>i.Index("bkupgrade-jagadeesh"));
            // byte[] responseBytes = indexResponse.Body;
            var asyncIndexResponse = await elasticsearchConnector.ElasticClient.IndexDocumentAsync(user);
            string responseString = indexResponse.ToString();
            return responseString;
        }
        public async Task<string> GetAsyncER(int id, string name)
        {
            UserModel user = new UserModel();

            user.Id = id;
            user.Name = name;
            var indexResponse = elasticsearchConnector.ElasticClient.Index(user, i => i.Index("bkupgrade-jagadeesh"));
            // byte[] responseBytes = indexResponse.Body;
            var asyncIndexResponse = await elasticsearchConnector.ElasticClient.IndexDocumentAsync(user);
            string responseString = indexResponse.ToString();
            return responseString;
        }
        public async Task<string> GetAsyncUp(int id, string name)
        {
            UserModel user = new UserModel();

            user.Id = id;
            user.Name = name;
            var indexResponse = elasticsearchConnector.ElasticClient.Update<UserModel>(user.Id, u => u

                             .Index("bkupgrade-jagadeesh")
                             //.Type("doc")
                             .Script(s => s
                                    .Source("ctx._source.name = params.name")
                                    .Params(p => p
                                    .Add("name", name)))
                            .Refresh(Refresh.True)
                            );
            // byte[] responseBytes = indexResponse.Body;
            //var asyncIndexResponse = await elasticsearchConnector.ElasticClient.IndexDocumentAsync(user);
            string responseString = indexResponse.ToString();
            return responseString;
        }
        public async Task<string> GetAsyncDelete(int id)
        {
            UserModel user = new UserModel();

            user.Id = id;

            //var indexResponse = elasticsearchConnector.ElasticClient.Indices.Delete("bkupgrade-jagadeesh");
            var indexResponse = elasticsearchConnector.ElasticClient.Delete<UserModel>(user.Id);
            // byte[] responseBytes = indexResponse.Body;
            //var asyncIndexResponse = await elasticsearchConnector.ElasticClient.IndexDocumentAsync(user);
            string responseString = indexResponse.ToString();
            return responseString;
        }

        // POST: api/SearchApi
        /*  public void Post(int id, string name)
          {
             *//* UserModel user = new UserModel();

              user.Id = id;
              user.Name = name;

              var indexResponse = elasticsearchConnector.ElasticClient.Index(user, i => i.Index("bkuser"));
              // byte[] responseBytes = indexResponse.Body;
              var asyncIndexResponse = await elasticsearchConnector.ElasticClient.IndexDocumentAsync(user);
              string responseString = indexResponse.ToString();
              return responseString;*//*
          }*/

        // PUT: api/SearchApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SearchApi/5
        public void Delete(int id)
        {
        }
    }
}
