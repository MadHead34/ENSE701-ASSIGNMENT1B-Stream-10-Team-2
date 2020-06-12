using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using SEER.Data;
using SEER.Models;

namespace SEER
{
    public class AcceptModel : PageModel
    {
        private readonly SEER.Data.SEERContext _context;

        public AcceptModel(SEER.Data.SEERContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InitialArticle InitialArticle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InitialArticle = await _context.InitialArticle.FirstOrDefaultAsync(m => m.ID == id);

            if (InitialArticle == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InitialArticle = await _context.InitialArticle.FindAsync(id);

            if (InitialArticle != null)
            {
                _context.AcceptedArticle.Add(
                    new AcceptedArticle
                    {
                        Title = InitialArticle.Title,
                        Author = InitialArticle.Author,
                        Source = InitialArticle.Source,
                        Year = InitialArticle.Year,
                        DOI = InitialArticle.DOI
                    });

                if (!String.IsNullOrEmpty(InitialArticle.Email))
                {
                    string body = $@"Dear {(String.IsNullOrEmpty(InitialArticle.Name) ? "User" : $"{InitialArticle.Name}")},

Your submission {InitialArticle.Title} has been accepted by SEER moderators and is in the process of being analyzed by SEER analysts.
Your submission should be available to view in the SEER database in around 24-48 hours.

Thank you for helping SEER grow.
-- SEER Administration";
                    if (!String.IsNullOrEmpty(InitialArticle.Name))
                    {
                        SendEmail("SEER Administration", "admin@seer.com", InitialArticle.Name, InitialArticle.Email, body);
                    }
                    else
                    {
                        SendEmail("SEER Administration", "admin@seer.com", "User", InitialArticle.Email, body);
                    }
                }

                _context.InitialArticle.Remove(InitialArticle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Moderate");
        }

        // email function here
        public void SendEmail(string admin, string admin_email, string user, string user_email, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(admin, admin_email));
            message.To.Add(new MailboxAddress(user, user_email));
            message.Subject = "Testing";

            message.Body = new TextPart("plain")
            {
                Text = body

            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("testingseer123", "test123!@#");

                client.Send(message);
                client.Disconnect(true);
            }

        }
    }
}
