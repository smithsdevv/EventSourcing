namespace Api.Endpoints.Users;

public class UserRequests
{
  public record UpdateUserRequest(string FullName, string Email);
  
  public record CreateUserRequest(Guid UserId, string FullName, string Email);
}