using BibliotecaUnit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaUnit.Pages
{
    public class UploadModel : PageModel
    {
        private readonly DatabaseContext _databaseContext;

        public UploadModel(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public IList<Invoices> Invoices { get; set; }
        public int? myID { get; set; }

        [BindProperty]
        public IFormFile file { get; set; }

        [BindProperty]
        public int? ID { get; set; }

        public void OnGet(int? id)
        {
            myID = id;
        }


        public async Task<IActionResult> OnPostAsync()
        {


                    var myInv = _databaseContext.Invoices.FirstOrDefault(x => x.Id == ID);

                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        myInv.Attachment = target.ToArray();

                    }
                    _databaseContext.Invoices.Update(myInv);
                    await _databaseContext.SaveChangesAsync();
                
            

            return RedirectToPage("Privacy");
        }
    }
}
  



