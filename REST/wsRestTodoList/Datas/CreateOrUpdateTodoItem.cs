namespace wsRestTodoList
{
    /// <summary>
    /// Element de données necessaire pour la creation d'une todo list
    /// </summary>
    public class CreateOrUpdateTodoItem
    {
        public string? Titre { get; set; }
        public string? Description { get; set; }
    }
}