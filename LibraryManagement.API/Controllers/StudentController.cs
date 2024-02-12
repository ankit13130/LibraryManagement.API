using LibraryManagement.Core.Contract;
using LibraryManagement.Core.Domain.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentServices _studentServices;

    public StudentController(IStudentServices studentServices)
    {
        _studentServices = studentServices;
    }

    [Authorize(Roles ="student")]
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        return Ok(await _studentServices.GetAllStudentsAsync());
    }

    [Authorize(Roles = "admin")]
    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetStudent(long studentId)
    {
        return Ok(await _studentServices.GetStudentAsync(studentId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(StudentRequestModel studentRequestModel)
    {
        await _studentServices.CreateStudentAsync(studentRequestModel);
        return Created();
    }

    [HttpDelete("{studentId}")]
    public async Task<IActionResult> RemoveStudent(long studentId)
    {
        await _studentServices.RemoveStudentAsync(studentId);
        return Ok("Removed");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudent(long student,StudentRequestModel studentRequestModel)
    {
        await _studentServices.UpdateStudentAsync(student, studentRequestModel);
        return Ok("Updated");
    }
}
