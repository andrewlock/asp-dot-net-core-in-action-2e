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
        private readonly static List<RowCountViewModel.Count> _previousCounts = new(); // c#9 feature - target typing
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
            var count = new RowCountViewModel.Count
            {
                DataContext = _transientDataContext.RowCount,
                Repository = _transientRepo.RowCount,
            };
            _previousCounts.Insert(0, count);
            RowCounts = new RowCountViewModel
            {
                Current = count,
                Previous = _previousCounts,
            };
        }
    }
}
