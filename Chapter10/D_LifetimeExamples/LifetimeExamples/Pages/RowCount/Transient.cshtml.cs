using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifetimeExamples.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LifetimeExamples.Pages
{
    public class TransientModel : PageModel
    {
        public RowCountViewModel RowCounts { get; set; }

        private readonly TransientRepository _transientRepo;
        private readonly TransientDataContext _transientDataContext;

        public TransientModel(
            TransientRepository transientRepo,
            TransientDataContext transientDataContext
            )
        {
            _transientRepo = transientRepo;
            _transientDataContext = transientDataContext;
        }

        public void OnGet()
        {
            RowCounts = new RowCountViewModel
            {
                DataContextCount = _transientDataContext.RowCount,
                RepositoryCount = _transientRepo.RowCount,
            };
        }
    }
}
