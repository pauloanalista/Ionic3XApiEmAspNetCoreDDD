using Microsoft.AspNetCore.Mvc;

namespace YouLearn.Api.Controllers
{
    public class UtilController
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Seja bem vindo ao YouLearn";
        }

        [HttpGet]
        [Route("Versao")]
        public string Versao()
        {
            return "Versao : 0.0.1";
        }

        //[HttpPost]
        //[Route("")]
        //public string Post()
        //{
        //    return "Post - Inserir nova informação";
        //}

        //[HttpPut]
        //[Route("")]
        //public string Put()
        //{
        //    return "Put - Atualizar informação";
        //}

        //[HttpDelete]
        //[Route("")]
        //public string Delete()
        //{
        //    return "Delete - Excluir informação";
        //}
    }
}
