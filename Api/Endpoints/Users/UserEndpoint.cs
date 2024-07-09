using Application.Commands.User.CreateUser;
using Application.Commands.User.DeleteUser;
using Application.Commands.User.UpdateUser;
using Application.Query.User;
using Carter;
using MediatR;

namespace Api.Endpoints.Users;

public  class UserEndpoint : ICarterModule
{
  public void AddRoutes(IEndpointRouteBuilder app)
  {
    var group  = app.MapGroup("api/users");
    
    group.MapPost("", CreateUser).WithName(nameof(CreateUser));
    group.MapPut("{id}", UpdateUser).WithName(nameof(UpdateUser));
    group.MapGet("{id}", GetUser).WithName(nameof(GetUser));
    group.MapDelete("{id}", DeleteUser).WithName(nameof(DeleteUser));
  }
  
  private static async Task<IResult> CreateUser(UserRequests.CreateUserRequest request, ISender sender)
  {
    var command = new CreateUserCommand(request.UserId, request.FullName, request.Email);
    await sender.Send(command);

    return TypedResults.Ok();
  }
  
  private static async Task<IResult> UpdateUser(Guid id, UserRequests.UpdateUserRequest request, ISender sender)
  {
    var command = new UpdateUserCommand(id, request.FullName, request.Email);
    await sender.Send(command);

    return TypedResults.Ok();
  }
  
  private static async Task<IResult> GetUser(Guid id, ISender sender)
  {
    var query = new GetUserQuery(id);
    var user = await sender.Send(query);

    if (user == null)
    {
      return TypedResults.NotFound();
    }

    return TypedResults.Ok(user);
  }
  
  private static async Task<IResult> DeleteUser(Guid userId, ISender sender)
  {
    var command = new DeleteUserCommand(userId);
    await sender.Send(command);
    
    return Results.Ok();
  }
}