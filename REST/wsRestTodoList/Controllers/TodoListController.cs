using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// for information on return value : https://medium.com/awesome-net/web-api-return-types-in-net-94715415ae88

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
        // GET: api/v1/TodoList/GetTodoItems
        // OPENAPI OperationId = Name
        [HttpGet(Name="GetTodoItems")]
        public IEnumerable<TodoItem> GetTodoItems()
        {
            return Datas;
        }

        // READ by GET request with url arg for ID
        // GET api/v1/TodoList/GetTodoItem/5
        // OPENAPI OperationId = Name
        // Data in result
        [HttpGet("GetTodoItem/{id}", Name="GetTodoItem")]
        [Produces("applicagtion/json")]
        [ProducesResponseType(400)] // BadRequest
        [ProducesResponseType(404)] // NotFound
        [ProducesResponseType(200, Type = typeof(TodoItem))]
        public ActionResult GetTodoItem(int id)
        {
            if (id <= 0) 
                return BadRequest("Id doit être supérieur à 0.");

            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data == null) 
                return NotFound($"Non trouvé avec l'ID={id}");

            return Ok(data);
        }

        // CREATE by POST request
        // POST api/v1/TodoList/CreateTodoItem
        // OPENAPI OperationId = Name
        // Data in BODY
        [HttpPost("CreateTodoItem",Name="CreateTodoItem")]
        [Produces("applicagtion/json")]
        [ProducesResponseType(200, Type = typeof(TodoItem))]
        public ActionResult CreateTodoItem([FromBody] CreateOrUpdateTodoItem dataToAdd)
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
        [HttpPut("UpdateTodoItem/{id}", Name = "UpdateTodoItem")]
        public void UpdateTodoItem(int id, [FromBody] CreateOrUpdateTodoItem dataToUpdate)
        {
            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data != null) 
            {
                data.Titre = dataToUpdate.Titre;
                data.Description = dataToUpdate.Description;
            }
        }

        // DELETE by DELETE request with url arg for ID
        // DELETE api/TodoList>/DeleteTodoItem/5
        // OPENAPI OperationId = Name
        [HttpDelete("DeleteTodoItem/{id}", Name = "DeleteTodoItem")]
        public void DeleteTodoItem(int id)
        {
            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data != null)
            {
                Datas.Remove(data);
            }
        }
    }
}
