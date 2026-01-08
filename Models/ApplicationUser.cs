using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroSocialPlatform.Models
{
    public class ApplicationUser : IdentityUser
    {
<<<<<<< HEAD
        [Required(ErrorMessage = "First name is required.")]
=======
        [Required(ErrorMessage = "Prenumele este obligatoriu!")]
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
        [MaxLength(50)]
        public string FirstName { get; set; }


<<<<<<< HEAD
        [Required(ErrorMessage = "Last name is required.")]
=======
        [Required(ErrorMessage = "Numele de familie este obligatoriu!")]
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
        [MaxLength(50)]
        public string LastName { get; set; }


<<<<<<< HEAD
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")] public string? Description { get; set; }


        //este obligatoarie
        public string ProfileImage { get; set; }
=======
        [StringLength(500, ErrorMessage = "Descrierea nu poate depăși 500 de caractere")]
        public string? Description { get; set; }


        public string? ProfileImage { get; set; }
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0


        public bool IsPrivate { get; set; } = false;


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        //Proprietate ajutatoare care nu se salveaza in Bd
        [NotMapped]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }



        //Relatii (Navigation Properties)
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Comment> Comments { get; set;} = new List<Comment>();
        public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();

        //M:M
        public virtual ICollection<Follow> Followers { get; set; } = new List<Follow>();
        public virtual ICollection<Follow> Following { get; set; } = new List<Follow>();


        public virtual ICollection<GroupMembership> GroupMemberships { get; set; } = new List<GroupMembership>();


    }
}
