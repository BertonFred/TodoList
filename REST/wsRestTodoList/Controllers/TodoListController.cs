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

        /// <summary>
        /// READ Liste Todo Item 
        /// Retourne une liste des todo items avec un gestion de la pagination.
        /// </summary>
        /// <remarks>ici une remarque</remarks>
        /// <param name="pageSize">Taille de la page.</param>   
        /// <param name="pageIndex">Index du premiere elements dans la page.</param>   
        /// <response code="200">OK, renvois de la liste demandé.</response>
        /// <response code="404">Erreur, non trouvé la liste est vide.</response>
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

        /// <summary>
        /// READ Todo Item
        /// Retourne un todo item a partir de son identifiant ID
        /// </summary>
        /// <remarks>ici une remarque</remarks>
        /// <param name="id">id du todo item doit être supérieur à 0.</param>   
        /// <response code="200">OK, le todo item est retourné.</response>
        /// <response code="400">Mauvaise requete, id non invalide.</response>
        /// <response code="404">Erreur, le todo item n'est pas trouvé a partir de l'id spécifié.</response>
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
