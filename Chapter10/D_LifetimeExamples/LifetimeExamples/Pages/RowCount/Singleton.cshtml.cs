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
            RowCounts = new RowCountViewModel
            {
                DataContextCount = _singletonDataContext.RowCount,
                RepositoryCount = _singletonRepo.RowCount,
            };
        }
    }
}
