using AutoMapper;
using LibraryManagement.Core.Contract;
using LibraryManagement.Core.Domain.RequestModels;
using LibraryManagement.Core.EncryptDecrypt;
using LibraryManagement.Infra.Contract;
using LibraryManagement.Infra.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagement.Core.Services;

public class ValidationServices : IValidationServices
{
    private readonly IStudentRepository _studentRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    public ValidationServices(IStudentRepository studentRepository, IMapper mapper, IConfiguration configuration)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _configuration = configuration;
    }
    //helper methods
    private Student AuthenticateUser(LoginRequestModel loginRequestModel)
    {
        EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
        Student student = _studentRepository.GetStudentAsync(loginRequestModel.Email).Result;

        if (student == null || !student.IsActive)
            throw new Exception("Student Not Found");

        if (!encryptionDecryption.VerifyPassword(loginRequestModel.Password, student.Hash, Convert.FromHexString(student.Salt)))
            throw new Exception("Wrong Password");

        return student;
    }
    private string GenerateToken(Student student)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //second method with claims
        var claims = new[]
        {
            new Claim(ClaimTypes.Sid,student.StudentId.ToString()),
            new Claim(ClaimTypes.Name,student.FirstName),
            //new Claim(ClaimTypes.Role,users.Roles),
            //new Claim(ClaimTypes.Role,"ADMIN"),
            //new Claim(ClaimTypes.Role,"USER")
        };

        var token = new JwtSecurityToken(null,
            null,
            claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    //[AllowAnonymous]

    public async Task<string> ValidateLoginAsync(LoginRequestModel loginRequestModel)
    {
        string response = null;
        var student = AuthenticateUser(loginRequestModel);
        if (student != null)
        {
            var tokenString = GenerateToken(student);
            response = tokenString;
        }
        return response;
    }
    public async Task ValidateSignupAsync(StudentRequestModel studentRequestModel)
    {
        if (_studentRepository.GetStudentAsync(studentRequestModel.Email).Result != null)
        {
            throw new Exception("Student Already Exists with entered Email");
        }

        Student student = _mapper.Map<Student>(studentRequestModel);

        EncryptionDecryption encryptDecrypt = new EncryptionDecryption();

        student.Hash = encryptDecrypt.HashPasword(studentRequestModel.Password, out var salt);
        student.Salt = Convert.ToHexString(salt);

        await _studentRepository.CreateStudentAsync(student);
    }
}
