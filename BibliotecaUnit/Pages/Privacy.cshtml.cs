using BibliotecaUnit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaUnit.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly DatabaseContext _databaseContext;


        public PrivacyModel(ILogger<PrivacyModel> logger, DatabaseContext databaseContext) 
        {
            _logger = logger;
            _databaseContext = databaseContext;

        }

        public IList<Invoices> Invoices { get; set; }

        public void OnGet()
        {
            Invoices = _databaseContext.Invoices.ToList();
        }

        public async Task<IActionResult> OnPostDownloadAsync(int? id)
        {
            var myInv = _databaseContext.Invoices.FirstOrDefault(x => x.Id == id);
            if (myInv == null)
            {
                return NotFound();
            }
            if (myInv.Attachment == null)
            {
                return Page();
            }
            else
            {
                byte[] byteArr = myInv.Attachment;
                string mimeType = "application/pdf";
                return new FileContentResult(byteArr, mimeType)


                {
                    FileDownloadName = $"{myInv.Name}.pdf"
                };

            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            var myInv = _databaseContext.Invoices.FirstOrDefault(x => x.Id == id);
            if (myInv == null)
            {
                return NotFound();
            }
            if (myInv.Attachment == null)
            {
                return Page();
            }
            else
            {
                myInv.Attachment = null;
                _databaseContext.Update(myInv);
                await _databaseContext.SaveChangesAsync();
            }

            Invoices = await _databaseContext.Invoices.ToListAsync();
            return Page();

        }
    }
    }
