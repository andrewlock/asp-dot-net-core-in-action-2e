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
    public class SingletonModel : PageModel
    {
        private readonly static List<RowCountViewModel.Count> _previousCounts = new(); // c#9 feature - target typing
        public RowCountViewModel RowCounts { get; set; }

        private readonly SingletonRepository _singletonRepo;
        private readonly SingletonDataContext _singletonDataContext;

        public SingletonModel(
            SingletonRepository singletonRepo,
            SingletonDataContext singletonDataContext
            )
        {
            _singletonRepo = singletonRepo;
            _singletonDataContext = singletonDataContext;
        }

        public void OnGet()
        {
            var count = new RowCountViewModel.Count
            {
                DataContext = _singletonDataContext.RowCount,
                Repository = _singletonRepo.RowCount,
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
