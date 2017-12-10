namespace GraduationTracker
{
    public interface IRepository
    {
        Student GetStudent(int id);
        Course GetCourse(int id);
        Diploma GetDiploma(int id);
        Requirement GetRequirement(int id);
        Diploma[] GetDiplomas();
        Requirement[] GetRequirements();
        Course[] GetCourses();
        Student[] GetStudents();

    }
}
