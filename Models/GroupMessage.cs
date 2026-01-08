using System.ComponentModel.DataAnnotations;

namespace MicroSocialPlatform.Models
{
    public class GroupMessage
    {
        [Key]
        public int Id { get; set; }

        //FK
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }



<<<<<<< HEAD
        [Required(ErrorMessage = "The message cannot be empty.")] 
=======
        [Required(ErrorMessage = "Mesajul nu poate fi gol!")]
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
        public string Content { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
