using LibraryManagement.Core.Contract;
using LibraryManagement.Core.Domain.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValidationController : ControllerBase
{
    private readonly IValidationServices _validationServices;
    public ValidationController(IValidationServices validationServices)
    {
        _validationServices = validationServices;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequestModel)
    {
        var response = await _validationServices.ValidateLoginAsync(loginRequestModel);
        return Ok(response == null ? Unauthorized() : response);
    }

    //[AllowAnonymous]
    [HttpPost("signup")]
    public async Task<IActionResult> Signup([FromBody] StudentRequestModel studentRequestModel)
    {
        await _validationServices.ValidateSignupAsync(studentRequestModel);
        return Created();
    }
}
