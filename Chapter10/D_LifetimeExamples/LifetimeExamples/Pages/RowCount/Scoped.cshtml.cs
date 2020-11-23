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
    public class ScopedModel : PageModel
    {
        private readonly static List<RowCountViewModel.Count> _previousCounts = new(); // c#9 feature - target typing
        public RowCountViewModel RowCounts { get; set; }

        private readonly ScopedRepository _scopedRepo;
        private readonly ScopedDataContext _scopedDataContext;

        public ScopedModel(
            ScopedRepository scopedRepo,
            ScopedDataContext scopedDataContext
            )
        {
            _scopedRepo = scopedRepo;
            _scopedDataContext = scopedDataContext;
        }

        public void OnGet()
        {
            var count = new RowCountViewModel.Count
            {
                DataContext = _scopedDataContext.RowCount,
                Repository = _scopedRepo.RowCount,
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
