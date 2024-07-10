using Application.Features.AppUsers.Commands.Create;
using Application.Features.AppUsers.Commands.CreateAppUserBlocking;
using Application.Features.AppUsers.Commands.CreateAppUserContact;
using Application.Features.AppUsers.Commands.Delete;
using Application.Features.AppUsers.Commands.DeleteAppUserBlocking;
using Application.Features.AppUsers.Commands.DeleteAppUserContact;
using Application.Features.AppUsers.Commands.Update;
using Application.Features.AppUsers.Queries.GetById;
using Application.Features.AppUsers.Queries.GetDynamicAppUser;
using Application.Features.AppUsers.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppUsersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAppUserResponse>> Add([FromBody] CreateAppUserCommand command)
    {
        CreatedAppUserResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAppUserResponse>> Update([FromBody] UpdateAppUserCommand command)
    {
        UpdatedAppUserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAppUserResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAppUserCommand command = new() { Id = id };

        DeletedAppUserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAppUserResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAppUserQuery query = new() { Id = id };

        GetByIdAppUserResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAppUserQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAppUserQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAppUserListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("GetDynamicAppUser")]
    public async Task<ActionResult<GetListResponse<GetDynamicAppUserListItemDto>>> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamic)
    {
        GetDynamicAppUserQuery query = new() { DynamicQuery = dynamic, PageRequest = pageRequest };

        GetListResponse<GetDynamicAppUserListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("CreateAppUserContact")]
    public async Task<ActionResult<CreateAppUserContactResponse>> CreateAppUserContact([FromBody] CreateAppUserContactCommand createAppUserContactCommand)
    {
        CreateAppUserContactResponse response = await Mediator.Send(createAppUserContactCommand);
        return Ok(response);
    }

    [HttpDelete("DeleteAppUserContact/{contactId}")]
    public async Task<ActionResult<DeleteAppUserContactResponse>> DeleteAppUserContact([FromRoute] Guid contactId)
    {
        DeleteAppUserContactCommand command = new() { ContactId = contactId };
        DeleteAppUserContactResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("CreateAppUserBlocking")]
    public async Task<ActionResult<CreateAppUserBlockingResponse>> CreateAppUserBlocking([FromBody] CreateAppUserBlockingCommand createAppUserBlockingCommand)
    {
        CreateAppUserBlockingResponse response = await Mediator.Send(createAppUserBlockingCommand);
        return Ok(response);
    }

    [HttpDelete("DeleteAppUserBlocking/{blockingId}")]
    public async Task<ActionResult<DeleteAppUserBlockingResponse>> DeleteAppUserBlocking([FromRoute] Guid blockingId)
    {
        DeleteAppUserBlockingCommand command = new() { BlockingId = blockingId };
        DeleteAppUserBlockingResponse response = await Mediator.Send(command);
        return Ok(response);
    }
}
