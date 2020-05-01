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
            RowCounts = new RowCountViewModel
            {
                DataContextCount = _scopedDataContext.RowCount,
                RepositoryCount = _capturingRepo.RowCount,
            };
        }
    }
}
