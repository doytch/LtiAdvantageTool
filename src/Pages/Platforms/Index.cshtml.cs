﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvantageTool.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdvantageTool.Pages.Platforms
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AdvantageToolUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<AdvantageToolUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<PlatformModel> Platforms { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _context.GetUserAsync(User);
            Platforms = user.Platforms
                .OrderBy(p => p.Name)
                .Select(p => new PlatformModel(p))
                .ToList();
        }
    }
}
