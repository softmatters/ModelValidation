using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel:PageModel
    {
        [Required]
        [BindProperty]
        public string Input { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }
    }
}
