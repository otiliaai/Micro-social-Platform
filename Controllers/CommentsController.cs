using MicroSocialPlatform.Data;
using MicroSocialPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using MicroSocialPlatform.Services;
=======
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0

namespace MicroSocialPlatform.Controllers
{
    public class CommentsController : Controller
    {
<<<<<<< HEAD
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICommentValidationService _commentValidation;

        public CommentsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ICommentValidationService commentValidation)
=======
        // adaugare, editare si stergere comentarii
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CommentsController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
<<<<<<< HEAD
            _commentValidation = commentValidation;
        }


=======
        }

>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
<<<<<<< HEAD
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Comment comment)
        {
            // 1) Setăm câmpurile controlate de server (nu vin din form)
            comment.UserId = _userManager.GetUserId(User);
            comment.Content = (comment.Content ?? "").Trim();

            // 2) Scoatem din ModelState câmpurile care NU vin din form,
            //    altfel ModelState rămâne invalid din cauza [Required] pe UserId / navigații.
            ModelState.Remove(nameof(Comment.UserId));
            ModelState.Remove(nameof(Comment.User));
            ModelState.Remove(nameof(Comment.Post));

            // 3) Validare clasică (DataAnnotations) pentru Content + PostId etc.
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "The comment cannot be empty.";
                return Redirect("/Posts/Details/" + comment.PostId);
            }

            // 4) Validare AI (Gemini) – dacă e ofensator, nu salvăm în DB
            var isOk = await _commentValidation.IsCommentValidAsync(comment.Content);
            if (!isOk)
            {
                TempData["Message"] = "Comentariul a fost respins (conținut inadecvat).";
                return Redirect("/Posts/Details/" + comment.PostId);
            }

            // 5) Salvăm comentariul
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            TempData["Message"] = "The comment has been added!";

            // 6) NOTIFICARE către owner-ul postării (dacă nu îți comentezi singur)
            var post = await _context.Posts.FindAsync(comment.PostId);
            var currentUserId = comment.UserId;

            if (post != null && post.UserId != currentUserId)
            {
                string previewContent = comment.Content.Length > 50
                    ? comment.Content.Substring(0, 50) + "..."
                    : comment.Content;

                var notif = new Notification
                {
                    UserId = post.UserId,
                    RelatedUserId = currentUserId,
                    Type = "NewComment",
                    Title = "New Comment",
                    Content = $"commented: \"{previewContent}\"",
                    Link = $"/Posts/Details/{post.Id}",
                    CreatedAt = DateTime.UtcNow,
                    IsRead = false
                };

                _context.Notifications.Add(notif);
                await _context.SaveChangesAsync();
            }

            // 7) Ne întoarcem înapoi la pagina postării
            return Redirect("/Posts/Details/" + comment.PostId);
        }


        [Authorize]
        public IActionResult Edit(int id)
        {
            Comment comment = _context.Comments.Find(id);
            if (comment == null) return NotFound();
=======
        [Authorize] // orice utilizator autentificat poate adauga comentarii
        public IActionResult New(Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.UserId = _userManager.GetUserId(User); 

            if (!string.IsNullOrWhiteSpace(comment.Content))
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                TempData["Message"] = "The comment has been added!";

                return Redirect("/Posts/Details/" + comment.PostId);
            }

            TempData["Message"] = "The comment cannot be empty.";
            return Redirect("/Posts/Details/" + comment.PostId);
        }

        [Authorize] 
        public IActionResult Edit(int id)
        {
            Comment comment = _context.Comments.Find(id);
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0

            if (comment.UserId == _userManager.GetUserId(User) || User.IsInRole("Admin"))
            {
                TempData["EditingCommentId"] = id;
                return Redirect("/Posts/Details/" + comment.PostId);
            }
<<<<<<< HEAD

            TempData["Message"] = "You do not have permission to edit this comment.";
            return Redirect("/Posts/Details/" + comment.PostId);
        }

=======
            else
            {
                TempData["Message"] = "You do not have permission to edit this comment.";
                return Redirect("/Posts/Details/" + comment.PostId);
            }
        }



>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, Comment commentRequest)
        {
            var comm = _context.Comments.Find(id);
<<<<<<< HEAD
            if (comm == null) return NotFound();

=======

            if (comm == null) return NotFound();
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
            if (comm.UserId != _userManager.GetUserId(User) && !User.IsInRole("Admin"))
            {
                return Json(new { success = false, message = "You do not have permission to edit this comment." });
            }

<<<<<<< HEAD
            var newContent = (commentRequest.Content ?? "").Trim();
            if (string.IsNullOrWhiteSpace(newContent))
            {
                return Json(new { success = false, message = "The comment text cannot be empty." });
            }

            if (newContent.Length > 1000)
            {
                return Json(new { success = false, message = "The comment cannot exceed 1000 characters." });
            }

            comm.Content = newContent;
            // daca vrei "updated at", adauga un camp UpdatedAt in model; altfel nu forta Date
            // comm.UpdatedAt = DateTime.UtcNow;

            _context.Comments.Update(comm);
            _context.SaveChanges();

            return Json(new { success = true, newContent = comm.Content });
        }

        [HttpPost]
        [Authorize]
    
        public IActionResult Delete(int id)
        {
            Comment comment = _context.Comments.Find(id);
            if (comment == null) return NotFound();

            int postId = comment.PostId;

            if (comment.UserId == _userManager.GetUserId(User) || User.IsInRole("Admin"))
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();

                TempData["Message"] = "The comment has been deleted!";
                return Redirect("/Posts/Details/" + postId);
            }

            TempData["Message"] = "You do not have permission to delete this comment.";
            return Redirect("/Posts/Details/" + postId);
        }
    }
}
=======
          
            if (!string.IsNullOrWhiteSpace(commentRequest.Content))
            {
                comm.Content = commentRequest.Content;
                comm.Date = DateTime.Now;

                _context.Comments.Update(comm);
                _context.SaveChanges();

                return Json(new { success = true, newContent = comm.Content });
            }

            return Json(new { success = false, message = "The comment text cannot be empty." });
        }

        [HttpPost]
        [Authorize] // doar utilizatori autentificati (autorul sau adminul)
        public IActionResult Delete(int id)
        {
            Comment comment = _context.Comments.Find(id);

            // salvam postId inainte de stergere pentru redirectionare
            int postId = comment.PostId;

            if (comment.UserId == _userManager.GetUserId(User) ||
                User.IsInRole("Admin"))
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
                TempData["Message"] = "The comment has been deleted!";

                return Redirect("/Posts/Details/" + postId);
            }
            else
            {
                TempData["Message"] = "You do not have permission to delete this comment.";
                return Redirect("/Posts/Details/" + postId);
            }
        }
    }
}
>>>>>>> efb3eb4a47a9c6afe9b76812eaceb1b9c58010d0
