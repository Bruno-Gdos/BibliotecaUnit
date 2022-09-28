using BibliotecaUnit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BibliotecaUnit.Pages
{
    public class CreateModel : PageModel
    {

        private readonly DatabaseContext _databaseContext;

        public CreateModel(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void OnGet()
        {
        }

        [BindProperty]
        public Invoices Invoices { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            _databaseContext.Invoices.Add(Invoices);
            await _databaseContext.SaveChangesAsync();
            return RedirectToPage("./Privacy");
        }
    }
}
