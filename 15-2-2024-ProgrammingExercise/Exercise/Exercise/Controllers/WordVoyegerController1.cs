using Exercise.Db;
using Exercise.Filters;
using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Exercise.Controllers {
    public class WordVoyegerController : ApiController {

        WordVoyegerDb wordVoyegerDb = WordVoyegerDb.GetInstance();

        // POST api/<controller>
        [AddHeaderResultFilter]
        public List<ArticleDTO> Post([FromBody] WordVoyegerRequestModel wordVoyegerRequestModel) {
            List<ArticleDTO> list = new List<ArticleDTO>();
            list = wordVoyegerDb.GetArticles(wordVoyegerRequestModel.page,wordVoyegerRequestModel.limit);
            return list;
        }



        [ExceptionArticleFilter]
        // DELETE api/<controller>/5
        public void Delete(int id) {
            if(id == 0)
                throw new Exception("Not Working Now");
        }
    }
}