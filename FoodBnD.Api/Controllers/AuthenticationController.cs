using Microsoft.AspNetCore.Mvc;
using FoodBnD.Contracts.Authentication;
using ErrorOr;
using FoodBnD.Application.Authentication.Commands.Register;
using FoodBnD.Application.Services.Authentication.Commands;
using FoodBnD.Application.Services.Authentication.Common;
using FoodBnD.Application.Services.Authentication.Queries;
using FoodBnD.Domain.Common.Errors;
using MediatR;


namespace FoodBnD.Api.Controllers;

[Route("auth")]

public class AuthenticationController : ApiController
{
       private readonly IMediator _mediator;

       [HttpPost("register")]
       public async Task<IActionResult> Register(RegisterRequest request)
       {
              var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
              ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
              return authResult.Match(
                     authResult => Ok(MapAuthResult(authResult)),
                     errors => Problem(errors)
              );
       }


       [HttpPost("login")]
       public IActionResult  Login(LoginRequest request)
       {
              ErrorOr<AuthenticationResult>  authResult = _authenticationQueryService.Login(
                     request.Email,
                     request.Password
              );

              if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredential)
              {
                     return Problem(
                            statusCode: StatusCodes.Status401Unauthorized, 
                            title: authResult.FirstError.Description);
              }

              return authResult.Match(
                     authResult => Ok(MapAuthResult(authResult)),
                     errors => Problem(errors)
              );
              
       }
       
       private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
       {
              return new AuthenticationResponse(
                     authResult.User.Id,
                     authResult.User.FirstName,
                     authResult.User.LastName,
                     authResult.User.Email,
                     authResult.Token
              );
       }
}