using AutoMapper;
using BusLiner.Application.Features.Roles.Queries.GetAllRoles;
using BusLiner.Application.Features.Users.Commands.UpdateUser;
using BusLiner.Application.Features.Users.Queries.GetUserById;
using BusLiner.MVC.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BusLiner.MVC.Areas.Administration.Pages.Users
{
    public class UpdateUserModel : PageModel
    {
        [BindProperty]
        public GetUserByIdDto UserCommand { get; set; } = null!;
        public IEnumerable<GetAllRolesDto> Roles { get; set; } = null!;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateUserCommand> _validator;

        public UpdateUserModel(IMediator mediator, IMapper mapper, IValidator<UpdateUserCommand> validator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            string? userId = Request.Query["Id"];

            if (!Guid.TryParse(userId, out Guid a))
                return RedirectToPage("AllUsers");

            UserCommand = await _mediator.Send( new GetUserByIdQuery() { Id = userId } );
            Roles = await _mediator.Send( new GetAllRolesQuery() );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mapped = _mapper.Map<UpdateUserCommand>(UserCommand);

            var validationResult = await _validator.ValidateAsync(mapped);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelStateWithObjectName(ModelState, "UserCommand");
                Roles = await _mediator.Send(new GetAllRolesQuery());
                return Page();
            }

            await _mediator.Send(mapped);

            return RedirectToPage("AllUsers");
        }
    }
}
