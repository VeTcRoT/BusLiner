using BusLiner.Application.Features.Orders.Queries.GetUserRidesByEmail;
using BusLiner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Identity.Pages.Account.Manage
{
    public class UserRidesModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;
        public IEnumerable<GetUserRidesByEmailDto>? Rides;

        public UserRidesModel(IMediator mediator, UserManager<IdentityUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Rides = await _mediator.Send(new GetUserRidesByEmailQuery() { Email = user.Email });

            return Page();
        }
    }
}
