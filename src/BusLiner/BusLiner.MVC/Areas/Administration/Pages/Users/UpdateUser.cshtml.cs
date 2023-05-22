using AutoMapper;
using BusLiner.Application.Features.Roles.Queries.GetAllRoles;
using BusLiner.Application.Features.Users.Commands.UpdateUser;
using BusLiner.Application.Features.Users.Queries.GetUserById;
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

        public UpdateUserModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = Request.Query["Id"];

            UserCommand = await _mediator.Send( new GetUserByIdQuery() { Id = userId } );
            Roles = await _mediator.Send( new GetAllRolesQuery() );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var mapped = _mapper.Map<UpdateUserCommand>(UserCommand);

            await _mediator.Send(mapped);

            return RedirectToPage("AllUsers");
        }
    }
}
