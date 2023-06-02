using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// for information on return value : https://medium.com/awesome-net/web-api-return-types-in-net-94715415ae88
// Scott Hanselman. ASP.NET Core RESTful Web API versioning made easy : http://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx
// ASP.NET Web API Help Pages using Swagger : https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger
// Data annotations for help : https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio// HttpStatusCode Énumération https://docs.microsoft.com/fr-fr/dotnet/api/system.net.httpstatuscode?view=net-6.0
// Data annotations attributes : https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
// data annotation : https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api?source=recommendations
// data validation : https://code-maze.com/aspnetcore-modelstate-validation-web-api/
// Créer la documentation des Web API ASP.NET Core avec Swagger https://rdonfack.developpez.com/tutoriels/documenter-web-api-aspnet-core-swagger/
// Analyseur de valeur de retour : https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/analyzers?view=aspnetcore-6.0
// action asynchrone : https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0
// Api controller documentation : https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0#apicontroller-attribute

// Activer le support update partiel d'objet : https://learn.microsoft.com/fr-fr/aspnet/core/web-api/jsonpatch?view=aspnetcore-6.0
// avec le nuget : Microsoft.AspNetCore.JsonPatch
// le jsonpatch est décodée par : Microsoft.AspNetCore.Mvc.NewtonsoftJson
// article JSON Patch With ASP.NET Core : https://dotnetcoretutorials.com/2017/11/29/json-patch-asp-net-core/
//
// Surveillance intégré applicative
// hebergement et supervision applicative / Contrôles d’intégrité (builder.Services.AddHealthChecks() :
// https://learn.microsoft.com/fr-fr/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-6.0
// Surveillance de l’intégrité: https://learn.microsoft.com/fr-fr/dotnet/architecture/microservices/implement-resilient-applications/monitor-app-health?source=recommendations
// HealthCheck UI : AspNetCore.HealthChecks.UI
// explication sur les methodes de retour Createxxx https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core#createdataction-explained
namespace wsRestTodoList.Controllers
{
    /// <summary>
    /// Web service Todo List 
    /// Ici on assure le routage vers une URL qui contiendra la dénomination : /api/v1/ et le nom du controleur 
    /// comme d'habitude .NET prendra le soin de supprimer tout seul le texte "Controller" sur le nom du service
    /// 
    /// ApiController : action des controle d'erreur
    /// </summary>
    [ApiVersion("1.1")]
    [ApiVersion("1.2")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TodoListController : ControllerBase
    {
        // Les données sont en memoire pour évité d'avoir une base de données
        private static int TodoItem_Next_ID = 0; // Générateur de numero unique
        private static List<TodoItem> Datas = null; // Liste des données

        /// <summary>
        /// Service de log injecté par le constructeur
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Constructeur
        /// Assure l'initialisation des données de test
        /// </summary>
        public TodoListController(ILogger<TodoListController> _logger)
        {
            logger = _logger;
            logger.LogInformation("CTOR");

            // initialisé des données statique de test si besoins
            if (Datas == null)
                InitialiszeDefaultData();
        }

        /// <summary>
        /// Creation de données de test
        /// </summary>
        private void InitialiszeDefaultData()
        {
            logger.LogInformation("InitialiszeDefaultData enter");

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

            logger.LogInformation("InitialiszeDefaultData leave");
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
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems([FromQuery]int pageSize = 10,[FromQuery] int pageIndex = 0)
        {
            logger.LogInformation("GetTodoItems enter");

            if (Datas == null)
                return NotFound($"Pas de données dans la liste");

            List<TodoItem> datas = Datas.Skip(pageSize * pageIndex)
                                        .Take(pageSize)
                                        .ToList();
            
            logger.LogInformation("GetTodoItems leave");

            return Ok(datas);
        }

        /// <summary>
        /// Lecture d'un Todo Item
        /// Retourne un todo item a partir de son identifiant ID
        /// </summary>
        /// <remarks>ici une remarque</remarks>
        /// <param name="id">id du todo item doit être supérieur à 0.</param>   
        /// <response code="200">OK, le todo item est retourné.</response>
        /// <response code="400">Mauvaise requete, id non invalide.</response>
        /// <response code="404">Erreur, le todo item n'est pas trouvé a partir de l'id spécifié.</response>
        [HttpGet()]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TodoItem> GetTodoItem(int id)
        {
            if (id <= 0) 
                return BadRequest("Id doit être supérieur à 0.");

            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data == null) 
                return NotFound($"Non trouvé avec l'ID = {id}");

            return Ok(data);
        }

        /// <summary>
        /// CREATE Todo Item
        /// Creation d'un todo items dans la listes des todo items
        /// </summary>
        /// <remarks>ici une remarque</remarks>
        /// <param name="dataToAdd">Données du todo item a ajouter.</param>   
        /// <response code="200">OK, le todo item est retourné.</response>
        [HttpPost()]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<TodoItem> CreateTodoItem([FromBody] CreateOrUpdateTodoItem dataToAdd)
        {
            // Verifier les données
            if (string.IsNullOrEmpty(dataToAdd.Titre) == true)
                return BadRequest();

            TodoItem_Next_ID++;
            TodoItem data = new TodoItem
            {
                ID = TodoItem_Next_ID,
                Titre = dataToAdd.Titre,
                Description = dataToAdd.Description
            };

            // test fake, mais c'est l'idée
            if (Datas.Find(item => item.ID == data.ID) != null)
                return Conflict();

            Datas.Add(data);

            return CreatedAtAction(nameof(GetTodoItem), new { id = data.ID }, data);
        }

        /// <summary>
        /// UPDATE Todo Item
        /// Mise a jour d'un Todo item dans la liste des Todo items.
        /// La mise a jour est reéalisé à partir de l'ID
        /// </summary>
        /// <remarks>ici une remarque</remarks>
        /// <param name="id">id du todo item doit être supérieur à 0.</param>   
        /// <param name="dataToUpdate">Données du todo item a mettre a jour.</param>   
        /// <response code="200">OK, le todo item est mise a jour.</response>
        /// <response code="400">Mauvaise requete, id non invalide.</response>
        /// <response code="404">Erreur, le todo item n'est pas trouvé a partir de l'id spécifié.</response>
        [HttpPut()]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
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

        /// <summary>
        /// DELETE Todo Item
        /// Supprimer un todo item a partir de son identifiant ID
        /// </summary>
        /// <param name="id">id du todo item doit être supérieur à 0.</param>   
        /// <response code="200">OK, le todo item est supprimé.</response>
        /// <response code="400">Mauvaise requete, id non invalide.</response>
        /// <response code="404">Erreur, le todo item n'est pas trouvé a partir de l'id spécifié.</response>
        [HttpDelete()]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// PATCH Todo Item
        /// Mettre a jour partiellement un todo item a partir de son identifiant ID
        /// </summary>
        /// <remarks>
        /// Documentation sur le format des patch : https://www.rfc-editor.org/rfc/rfc6902
        /// Tutorial rapide : https://dotnetcoretutorials.com/2017/11/29/json-patch-asp-net-core/
        /// Exemple :<br/>
        ///   mise à jour d'un attribut :  [ { "op": "replace", "path": "/Titre", "value": "modif du tire sur id=1" } ]<br/>
        ///   mise à jour d'un attribut vers null: [ { "op": "remove", "path": "/Titre" } ]<br/>
        /// </remarks>
        /// <param name="id">id du todo item doit être supérieur à 0.</param>   
        /// <param name="patchDoc">Document JSon de déclaration des demandes de patch (modification partielle) d'un objet.</param>   
        /// <response code="200">OK, le todo item est supprimé.</response>
        /// <response code="400">Mauvaise requete, id non invalide.</response>
        /// <response code="404">Erreur, le todo item n'est pas trouvé a partir de l'id spécifié.</response>
        [HttpPatch()]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PatchTodoItem(int id,[FromBody] JsonPatchDocument<TodoItem> patchDoc)
        {
            // Controle des données d'entrée
            if (id <= 0)
                return BadRequest("Id doit être supérieur à 0.");

            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data == null)
                return NotFound($"Non trouvé avec l'ID = {id}");

            if (patchDoc == null)
                return BadRequest(ModelState);

            // Execution du traitement
            patchDoc.ApplyTo(data);
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

    }
}
