using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreViewerApplication.Pages
{
    public class IndexModel : PageModel
    {
        public List<Store> Stores { get; }
        public MapSettings MapSettings { get; }
        public AppDisplaySettings AppSettings { get; }

        public IndexModel(
            IOptions<List<Store>> stores,
            IOptions<MapSettings> mapSettings,
            IOptions<AppDisplaySettings> appSettings
            )
        {
            Stores = stores.Value;
            MapSettings = mapSettings.Value;
            AppSettings = appSettings.Value;
        }

        public void OnGet()
        {

        }
    }
}
