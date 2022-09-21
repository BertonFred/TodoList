using System.ComponentModel.DataAnnotations;

namespace wsRestTodoList
{
    /// <summary>
    /// D�finition d'un Todo item.
    /// Cette element est persistant, d'ou la pr�sence de l'ID
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// ID de l'enregistrement
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Titre du todo item
        /// </summary>
        [Required]
        public String? Titre { get; set; }

        /// <summary>
        /// Description du todo item
        /// </summary>
        public String? Description { get; set; }
    }
}