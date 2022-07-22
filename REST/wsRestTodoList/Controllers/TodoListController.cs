using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace wsRestTodoList.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        // Les données sont en memoire pour évité d'avoir une base de données
        static int TodoItem_Next_ID = 0;
        static List<TodoItem> Datas = null;

        // GET LIST
        // GET: api/v1/<TodoListController>
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            if (Datas == null)
                InitialiszeDefaultData();

            return Datas;
        }

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

        // READ
        // GET api/v1/<TodoListController>/5
        [HttpGet("{id}")]
        public TodoItem? Get(int id)
        {
            if (Datas == null)
                return null;

            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            return data;
        }

        // CREATE
        // POST api/v1/<TodoListController>
        [HttpPost]
        public void Post([FromBody] CreateOrUpdateTodoItem dataToAdd)
        {
            TodoItem_Next_ID++;
            TodoItem data = new TodoItem
            {
                ID = TodoItem_Next_ID,
                Titre = dataToAdd.Titre,
                Description = dataToAdd.Description
            };

            Datas.Add(data);
        }

        // UPDATE
        // PUT api/<TodoListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateOrUpdateTodoItem dataToUpdate)
        {
            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data != null) 
            {
                data.Titre = dataToUpdate.Titre;
                data.Description = dataToUpdate.Description;
            }
        }

        // DELETE
        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TodoItem? data = Datas.FirstOrDefault(item => item.ID == id);
            if (data != null)
            {
                Datas.Remove(data);
            }
        }
    }
}
