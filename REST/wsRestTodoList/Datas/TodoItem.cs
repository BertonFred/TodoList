namespace wsRestTodoList
{
    /// <summary>
    /// Définition d'un Todo item
    /// Cette element est persistant, d'ou la présence de l'ID
    /// </summary>
    public class TodoItem
    {
        public int ID { get; set; }
        public String? Titre { get; set; }
        public String? Description { get; set; }
    }
}