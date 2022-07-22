using Grpc.Core;
using GrpcTodoList;

namespace GrpcTodoList
{
    public class TodoListService : TodoList.TodoListBase
    {
        static private int TodoItem_Next_ID = 0;
        static private List<TodoItem> Datas = new List<TodoItem>();

        private readonly ILogger<TodoListService> _logger;

        public TodoListService(ILogger<TodoListService> logger)
        {
            _logger = logger;

            if (Datas == null)
                InitialiszeDefaultData();
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
                    Id = TodoItem_Next_ID,
                    Titre = $"Titre test {TodoItem_Next_ID}",
                    Description = $"Description test {TodoItem_Next_ID}"
                };
                Datas.Add(data);
            }
        }

        /// <summary>
        /// Creation d'un item de todo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<TodoItem> CreateTodoItem(CreateTodoItemRequest request, ServerCallContext context)
        {
            TodoItem_Next_ID++;
            TodoItem item = new TodoItem 
                                {
                                    Id = TodoItem_Next_ID,
                                    Titre = request.Titre,
                                    Description = request.Description,
                                };
            Datas.Add(item);
            return Task.FromResult(item);
        }

        /// <summary>
        /// Lecture d'un todo item
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<TodoItem> GetTodoItem(GetTodoItemRequest request, ServerCallContext context)
        {
            TodoItem? result;
            if (Datas.Count > 0)
            {
                TodoItem? item = Datas.FirstOrDefault(i => i.Id == request.Id);
                if (item == null)
                    result = new TodoItem();
                else
                    result = new TodoItem
                    {
                                    Id = item.Id,
                                    Titre = item.Titre,
                                    Description = item.Description
                                };
            }
            else
                result = new TodoItem(); // Todo item vide

            return Task.FromResult(result);
        }

        /// <summary>
        /// Demande la listes des todo items
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<GetTodoListReply> GetTodoList(GetTodoListRequest request, ServerCallContext context)
        {
            // recherche a faire

            // TODO : Renvoyer une liste des todo list
            var reply = new GetTodoListReply();
            reply.Items.AddRange(Datas);
            return Task.FromResult(reply);
        }
    }
}