﻿using Microsoft.AspNetCore.Http;

namespace LibraryManagement.Core.Domain.RequestModels;

public record StudentRequestModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IFormFile ProfileImage { get; set; }
}
