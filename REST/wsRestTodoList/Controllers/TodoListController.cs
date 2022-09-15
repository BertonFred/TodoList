using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit : https://go.microsoft.com/fwlink/?LinkID=397860
// for information on return value : https://medium.com/awesome-net/web-api-return-types-in-net-94715415ae88
// Scott Hanselman. ASP.NET Core RESTful Web API versioning made easy : http://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx
// ASP.NET Web API Help Pages using Swagger : https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger
// HttpStatusCode Énumération https://docs.microsoft.com/fr-fr/dotnet/api/system.net.httpstatuscode?view=net-6.0
// Créer la documentation des Web API ASP.NET Core avec Swagger https://rdonfack.developpez.com/tutoriels/documenter-web-api-aspnet-core-swagger/
namespace wsRestTodoList.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        // Les données sont en memoire pour évité d'avoir une base de données
        private static int TodoItem_Next_ID = 0;
        private static List<TodoItem> Datas = null;

        public TodoListController()
        {
            // initialisé des données statique de test si besoins
            if (Datas == null)
                InitialiszeDefaultData();
        }

        /// <summary>
        /// Creation de données de test
        /// </summary>
        private void InitialiszeDefaultData()
        {
            Datas = new List<TodoItem>();
            int iNbItemToCreate = 5;
            for (int i = 1; i < iNbItemToCreate; i++)
            {
                TodoItem_Next_ID++;
                TodoItem data = new TodoItem
                {
                    ID = TodoItem_Next_ID,
                    Titre = $"Titre test {TodoItem_Next_ID}",
                    Description = $"Description test {TodoItem_Next_ID}"
                };
                Datas.Add(data);
            }
        }

        // GET LIST by GET request with no url arg
        // GET: api/v1/TodoList/GetTodoItems[?pageSize=30&pageIndex=10]
        // OPENAPI OperationId = Name
        //[HttpGet(Name="GetTodoItems")]
        [HttpGet()]
        [Route("[action]")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)] 
        [ProducesResponseType((int)HttpStatusCode.OK)] 
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems([FromQuery]int pageSize = 10,[FromQuery] int pageIndex = 0)
        {
            if (Datas == null)
                return NotFound($"Pas de données dans la liste");

            List<TodoItem> datas = Datas.Skip(pageSize * pageIndex)
                                        .Take(pageSize)
                                        .ToList();
            return Ok(datas);
        }

        // READ by GET request with url arg for ID
        // GET api/v1/TodoList/GetTodoItem/5
        // OPENAPI OperationId = Name
        // Data in result
        //        [HttpGet("GetTodoItem/{id}", Name="GetTodoItem")]
        /// <summary>
        /// Retourne un todo item specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id du client a retourné</param>   
        /// <response code="200">client selectionné</response>
        /// <response code="404">client introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        [HttpGet()]
        [Route("[action]/{id}")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)] 
        [ProducesResponseType((int)HttpStatusCode.NotFound)] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<TodoItem> GetTodoItem(int id)
        {
            if (id <= 0) 
                return BadRequest("Id doit être supérieur à 0.");

            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data == null) 
                return NotFound($"Non trouvé avec l'ID = {id}");

            return Ok(data);
        }

        // CREATE by POST request
        // POST api/v1/TodoList/CreateTodoItem
        // OPENAPI OperationId = Name
        // Data in BODY
        [HttpPost()]
        [Route("[action]")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<TodoItem> CreateTodoItem([FromBody] CreateOrUpdateTodoItem dataToAdd)
        {
            TodoItem_Next_ID++;
            TodoItem data = new TodoItem
            {
                ID = TodoItem_Next_ID,
                Titre = dataToAdd.Titre,
                Description = dataToAdd.Description
            };

            Datas.Add(data);

            return Ok(data);
        }

        // UPDATE by PUT request with url arg for ID
        // PUT api/TodoList/UpdateTodoItem/5
        // OPENAPI OperationId = Name
        // Data in BODY
        [HttpPut()]
        [Route("[action]/{id}")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)] 
        [ProducesResponseType((int)HttpStatusCode.NotFound)] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult UpdateTodoItem(int id, [FromBody] CreateOrUpdateTodoItem dataToUpdate)
        {
            if (id <= 0)
                return BadRequest("Id doit être supérieur à 0.");

            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data == null)
                return NotFound($"Non trouvé avec l'ID = {id}");

            data.Titre = dataToUpdate.Titre;
            data.Description = dataToUpdate.Description;

            return Ok();
        }

        // DELETE by DELETE request with url arg for ID
        // DELETE api/TodoList>/DeleteTodoItem/5
        // OPENAPI OperationId = Name
        [HttpDelete()]
        [Route("[action]/{id}")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)] 
        [ProducesResponseType((int)HttpStatusCode.NotFound)] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult DeleteTodoItem(int id)
        {
            if (id <= 0)
                return BadRequest("Id doit être supérieur à 0.");

            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data == null)
                return NotFound($"Non trouvé avec l'ID = {id}");

            Datas.Remove(data);

            return Ok();
        }
    }
}
