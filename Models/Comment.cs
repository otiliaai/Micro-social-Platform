using System.ComponentModel.DataAnnotations;

namespace MicroSocialPlatform.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

<<<<<<< HEAD
        // Cine a comentat
        [Required]
        public string UserId { get; set; } = string.Empty;

        public virtual ApplicationUser? User { get; set; } // un comentariu apartine unui singur user

        // La ce postare a comentat
        [Required]
        public int PostId { get; set; }

        public virtual Post? Post { get; set; }

        // Continut
        [Required(ErrorMessage = "The comment cannot be empty.")]
        [MinLength(2, ErrorMessage = "The comment is too short.")]
        [StringLength(1000, ErrorMessage = "The comment cannot exceed 1000 characters.")]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

       }
=======

        //Cine a comentat
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; } //un comentariu apartine unui singur user


        //La ce postare a comentat
        public int PostId { get; set; }
        public virtual Post Post { get; set; }


        [Required(ErrorMessage = "Comentariul nu poate fi gol!")]
        [StringLength(1000, ErrorMessage = "Comentariul nu poate depăși 1000 de caractere.")]
        public string Content { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime Date { get; internal set; }
    }
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
}
