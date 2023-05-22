using BusLiner.Application.Features.Roles.Queries.GetAllRoles;
using BusLiner.Application.Features.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Users
{
    public class CreateUserModel : PageModel
    {
        [BindProperty]
        public CreateUserCommand UserCommand { get; set; } = null!;

        public IEnumerable<GetAllRolesDto> Roles { get; set; } = null!;

        private readonly IMediator _mediator;

        public CreateUserModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Roles = await _mediator.Send( new GetAllRolesQuery() );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(UserCommand);

            return RedirectToPage("AllUsers");
        }
    }
}
