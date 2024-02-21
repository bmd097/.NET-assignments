using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        public static List<Person> persons;

        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
            persons = new List<Person>();
        }

        public void OnGet() {

        }
    }
}
