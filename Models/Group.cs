using System.ComponentModel.DataAnnotations;

namespace MicroSocialPlatform.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }


<<<<<<< HEAD
        [Required(ErrorMessage = "The group name is required.")]
        [StringLength(100, ErrorMessage = "The group name cannot exceed 100 characters.")] public string Name { get; set; }


        [Required(ErrorMessage = "The group description is required.")]
        [StringLength(500, ErrorMessage = "The group description cannot exceed 500 characters.")] public string Description { get; set; }
=======
        [Required(ErrorMessage = "Numele grupului este obligatoriu.")]
        [StringLength(100, ErrorMessage = "Numele grupului nu poate depăși 100 de caractere.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Descrierea grupului este obligatorie.")]
        [StringLength(500, ErrorMessage = "Descrierea grupului nu poate depăși 500 de caractere.")]
        public string Description { get; set; }
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        //FK - Creatorul grupului
        public string ModeratorId { get; set; }
        public virtual ApplicationUser Moderator { get; set; }


        //Relatii - Navigation Properties
        public virtual ICollection<GroupMembership> GroupMemberships { get; set; } = new List<GroupMembership>();
        public virtual ICollection<GroupMessage> GroupPosts { get; set; } = new List<GroupMessage>();
    }
}
