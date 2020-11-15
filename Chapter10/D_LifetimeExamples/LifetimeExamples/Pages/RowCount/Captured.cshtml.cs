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
    public class CapturedModel : PageModel
    {
        private readonly static List<RowCountViewModel.Count> _previousCounts = new(); // c#9 feature - target typing
        public RowCountViewModel RowCounts { get; set; }

        private readonly CapturingRepository _capturingRepo;
        private readonly ScopedDataContext _scopedDataContext;

        public CapturedModel(
            CapturingRepository capturingRepo,
            ScopedDataContext scopedDataContext
            )
        {
            _capturingRepo = capturingRepo;
            _scopedDataContext = scopedDataContext;
        }

        public void OnGet()
        {
            var count = new RowCountViewModel.Count
            {
                DataContext = _scopedDataContext.RowCount,
                Repository = _capturingRepo.RowCount,
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
