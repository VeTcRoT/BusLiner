using BusLiner.Application.Features.Users.Commands.DeleteUser;
using BusLiner.Application.Features.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Users
{
    public class AllUsersModel : PageModel
    {
        [BindProperty]
        public string Id { get; set; } = string.Empty;
        public IEnumerable<GetAllUsersDto> Users { get; set; } = null!;

        private readonly IMediator _mediator;

        public AllUsersModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = await _mediator.Send( new GetAllUsersQuery() );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send( new DeleteUserCommand() { Id = Id } );

            return RedirectToPage("AllUsers");
        }
    }
}
