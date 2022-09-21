using System.ComponentModel.DataAnnotations;

namespace wsRestTodoList
{
    /// <summary>
    /// Données necessaire pour la creation ou a la mise à jour d'un todo item.
    /// </summary>
    public class CreateOrUpdateTodoItem
    {
        /// <summary>
        /// Titre du todo item
        /// </summary>
        [Required]
        public string? Titre { get; set; }

        /// <summary>
        /// Description du todo item
        /// </summary>
        public string? Description { get; set; }
    }
}