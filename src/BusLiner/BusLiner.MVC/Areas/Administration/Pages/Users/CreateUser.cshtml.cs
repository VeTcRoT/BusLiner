using BusLiner.Application.Features.Roles.Queries.GetAllRoles;
using BusLiner.Application.Features.Users.Commands.CreateUser;
using BusLiner.MVC.Extensions;
using FluentValidation;
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
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserModel(IMediator mediator, IValidator<CreateUserCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Roles = await _mediator.Send( new GetAllRolesQuery() );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var validationResult = await _validator.ValidateAsync(UserCommand);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "UserCommand");
                Roles = await _mediator.Send(new GetAllRolesQuery());

                return Page();
            }

            await _mediator.Send(UserCommand);

            return RedirectToPage("AllUsers");
        }
    }
}
