using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankingApplication.Pages
{
    // Remove the attribute below to protect again CSRF attacks
    [IgnoreAntiforgeryToken]
    [Authorize]
    public class BalanceModel : PageModel
    {
        private static ConcurrentDictionary<string, int> _balances = new ConcurrentDictionary<string, int>();

        public int Balance { get; set; }

        public void OnGet()
        {
            var userId = User.Identity.Name;

            Balance = GetBalance(userId);
        }

        public IActionResult OnPost(int amount)
        {
            if (amount <= 0)
            {
                return BadRequest();
            }

            var userId = User.Identity.Name;
            var balance = GetBalance(userId);
            _balances[userId] = balance - amount;

            return RedirectToPage("/Balance");
        }

        private static int GetBalance(string userId)
        {
            //everyone starts with a balance of 10,000
            return _balances.GetOrAdd(userId, 10_000);
        }
    }
}
