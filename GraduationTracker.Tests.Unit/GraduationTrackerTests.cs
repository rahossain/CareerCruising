using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {

        private readonly IGraduationTracker graduationTracker;
        public GraduationTrackerTests()
        {
            graduationTracker = new GraduationTracker();
        }

        #region TestData
        private Student FakeSumaCumLaudeStudent
        {
            get
            {
                return new Student
                {
                    Id = 1,
                    Courses = new Course[]
                          {
                                new Course{Id = 1, Name = "Math", Mark=95 },
                                new Course{Id = 2, Name = "Science", Mark=95 },
                                new Course{Id = 3, Name = "Literature", Mark=95 },
                                new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                          }
                };
            }
        }
        private Student FakeMagnaCumLaudeStudent
        {
            get
            {
                return new Student
                {
                    Id = 2,
                    Courses = new Course[]
                           {
                                new Course{Id = 1, Name = "Math", Mark=81 },
                                new Course{Id = 2, Name = "Science", Mark=81 },
                                new Course{Id = 3, Name = "Literature", Mark=81 },
                                new Course{Id = 4, Name = "Physichal Education", Mark=81 }
                           }
                };
            }
        }

        private Student FakeAverageStudent
        {
            get
            {
                return new Student
                {
                    Id = 3,
                    Courses = new Course[]
                        {
                            new Course{Id = 1, Name = "Math", Mark=51 },
                            new Course{Id = 2, Name = "Science", Mark=51 },
                            new Course{Id = 3, Name = "Literature", Mark=51 },
                            new Course{Id = 4, Name = "Physichal Education", Mark=51 }
                        }
                };
            }
        }
        private Student FakeRemedialStudent
        {
            get
            {
                return new Student
                {
                    Id = 4,
                    Courses = new Course[]
                        {
                            new Course{Id = 1, Name = "Math", Mark=40 },
                            new Course{Id = 2, Name = "Science", Mark=40 },
                            new Course{Id = 3, Name = "Literature", Mark=40 },
                            new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                        }
                };
            }
        }
        private Student[] FakeStudents
        {
            get
            {
                return new[]
                    {
                       new Student
                       {
                           Id = 1,
                           Courses = new Course[]
                           {
                                new Course{Id = 1, Name = "Math", Mark=95 },
                                new Course{Id = 2, Name = "Science", Mark=95 },
                                new Course{Id = 3, Name = "Literature", Mark=95 },
                                new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                           }
                       },
                       new Student
                       {
                           Id = 2,
                           Courses = new Course[]
                           {
                                new Course{Id = 1, Name = "Math", Mark=80 },
                                new Course{Id = 2, Name = "Science", Mark=80 },
                                new Course{Id = 3, Name = "Literature", Mark=80 },
                                new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                           }
                       },
                    new Student
                    {
                        Id = 3,
                        Courses = new Course[]
                        {
                            new Course{Id = 1, Name = "Math", Mark=50 },
                            new Course{Id = 2, Name = "Science", Mark=50 },
                            new Course{Id = 3, Name = "Literature", Mark=50 },
                            new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                        }
                    },
                    new Student
                    {
                        Id = 4,
                        Courses = new Course[]
                        {
                            new Course{Id = 1, Name = "Math", Mark=40 },
                            new Course{Id = 2, Name = "Science", Mark=40 },
                            new Course{Id = 3, Name = "Literature", Mark=40 },
                            new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                        }
                    }
                };
            }
        }
        private Requirement[] FakeRequirements
        {
            get
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

        }

        private Diploma FakeDiploma
        {
            get
            {
                return
               new Diploma
               {
                   Id = 1,
                   Credits = 4,
                   Requirements = FakeRequirements
               };
            }
        }
        #endregion

        #region TestCases
        [TestMethod]
        public void HasGraduated_CheckAnyStudentGraduated()
        {

            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in FakeStudents)
            {
                graduated.Add(graduationTracker.HasGraduated(FakeDiploma, student));
            }

            Assert.IsTrue(graduated.Any(g => g.Item1 == true));
        }

        [TestMethod]
        public void HasGraduated_CheckStudentGraduationWithSumaCumLaude()
        {
            var result = graduationTracker.HasGraduated(FakeDiploma, FakeSumaCumLaudeStudent);
            Assert.IsTrue(result.Item1 && result.Item2 == STANDING.SumaCumLaude);
        }
        [TestMethod]
        public void HasGraduated_CheckStudentGraduationWithMagnaCumLaude()
        {
            var result = graduationTracker.HasGraduated(FakeDiploma, FakeMagnaCumLaudeStudent);
            Assert.IsTrue(result.Item1 && result.Item2 == STANDING.MagnaCumLaude);
        }
        [TestMethod]
        public void HasGraduated_CheckStudentGraduationWithAverage()
        {
            var result = graduationTracker.HasGraduated(FakeDiploma, FakeAverageStudent);
            Assert.IsTrue(result.Item1 && result.Item2 == STANDING.Average);
        }
        [TestMethod]
        public void HasGraduated_CheckStudentGraduationFailWithRemedial()
        {
            var result = graduationTracker.HasGraduated(FakeDiploma, FakeRemedialStudent);
            Assert.IsTrue(!result.Item1 && result.Item2 == STANDING.Remedial);
        }
        #endregion

    }
}
