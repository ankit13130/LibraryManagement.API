using AutoMapper;
using LibraryManagement.Core.Contract;
using LibraryManagement.Core.Domain.RequestModels;
using LibraryManagement.Core.Domain.ResponseModels;
using LibraryManagement.Infra.Contract;
using LibraryManagement.Infra.Domain.Models;

namespace LibraryManagement.Core.Services;

public class StudentServices : IStudentServices
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    public StudentServices(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    public async Task CreateStudentAsync(StudentRequestModel student)
    {
        await _studentRepository.CreateStudentAsync(_mapper.Map<Student>(student));
    }

    public async Task UpdateStudentAsync(long studentId, StudentRequestModel student)
    {
        Student data = await _studentRepository.GetStudentAsync(studentId);
        if(data == null)
            throw new Exception("Student Not Exist");

        await _studentRepository.UpdateStudentAsync(_mapper.Map(student, data));
    }

    public async Task RemoveStudentAsync(long studentId)
    {
        Student data = await _studentRepository.GetStudentAsync(studentId);
        if (data == null)
            throw new Exception("Student Not Exist");

        await _studentRepository.RemoveStudentAsync(data);
    }

    public async Task<StudentResponseModel> GetStudentAsync(long studentId)
    {
        Student data = await _studentRepository.GetStudentAsync(studentId);
        if (data == null)
            throw new Exception("Student Not Exist");
        return _mapper.Map<StudentResponseModel>(await _studentRepository.GetStudentAsync(studentId));
    }

    public async Task<IList<StudentResponseModel>> GetAllStudentsAsync()
    {
        return _mapper.Map<List<StudentResponseModel>>(await _studentRepository.GetAllStudentsAsync());
    }
}
