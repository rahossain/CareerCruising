using System.Linq;

namespace GraduationTracker
{
    public class Repository : IRepository
    {
        public  Student GetStudent(int id)
        {
            var students = GetStudents();
            return students.ToList().SingleOrDefault(d => d.Id == id); ;
        }
        public Course GetCourse(int id)
        {
            var courses = GetCourses();
            return courses.ToList().SingleOrDefault(d => d.Id == id); ;
        }

        public Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            return diplomas.ToList().SingleOrDefault(d => d.Id == id); ;
        }

        public  Requirement GetRequirement(int id)
        {
            var requirements = GetRequirements();
            return requirements.ToList().SingleOrDefault(d => d.Id == id); ;            
        }

        public Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = GetRequirements()
                }
            };
        }

        public  Requirement[] GetRequirements()
        {
            return new[]
            {
                    new Requirement
                    {
                        Id = 100,
                        Name = "Math",
                        MinimumMark =50,
                        Courses = new Course[]
                                    {
                                        new Course
                                                {
                                                    Id = 1,
                                                    Name = "Math",
                                                    Mark =50
                                                }
                                    },
                        Credits =1
                    },
                    new Requirement
                    {
                        Id = 102,
                        Name = "Science",
                        MinimumMark =50,
                        Courses = new Course[] 
                        {
                            new Course
                            {
                                Id = 2,
                                Name = "Science",
                                Mark =95
                            }
                        },
                        Credits =1
                    },
                    new Requirement
                    {
                        Id = 103,
                        Name = "Literature",
                        MinimumMark =50,
                        Courses = new Course[] 
                        {
                            new Course
                            {
                                Id = 3,
                                Name = "Literature",
                                Mark =80
                            }
                        },
                        Credits =1
                    },
                    new Requirement
                    {
                        Id = 104,
                        Name = "Physichal Education",
                        MinimumMark =50,
                        Courses = new Course[] 
                        {
                            new Course
                            {
                                Id = 4,
                                Name = "Physichal Education",
                                Mark =95
                            }
                        },
                        Credits =1
                    }
                };
        }

        public Course[] GetCourses()
        {
            return new[]
            {
                new Course
                {
                    Id = 1,
                    Name = "Math",
                    Mark =95
                },
                new Course
                {
                    Id = 2,
                    Name = "Science",
                    Mark =95
                },
                new Course
                {
                    Id = 3,
                    Name = "Literature",
                    Mark =95
                },
                new Course
                {
                    Id = 4,
                    Name = "Physichal Education",
                    Mark =95
                }
             };
        }
        public  Student[] GetStudents()
        {
            return new[]
            {
                   new Student
                   {
                       Id = 1,
                       Courses = GetCourses()
                   },
                   new Student
                   {
                       Id = 2,
                       Courses = GetCourses()
                   },
                    new Student
                    {
                        Id = 3,
                        Courses = GetCourses()
                    },
                    new Student
                    {
                        Id = 4,
                        Courses = GetCourses()
                    }
            };
        }
    }
}
