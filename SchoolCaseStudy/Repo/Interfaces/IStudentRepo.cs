using SchoolCaseStudy.DTOs;

namespace SchoolCaseStudy.Repo.Interfaces
{
    public interface IStudentRepo
    {
        List<GetStudentDTO> GetStudents();
        GetStudentDTO GetStudent(int id);
        void AddStudent(CreateStudentDTO student);

        void UpdateStudent(int id, CreateStudentDTO student);

        void DeleteStudent(int id);

    }
}
