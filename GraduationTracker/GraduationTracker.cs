using System;
using System.Linq;

namespace GraduationTracker
{
    public  class GraduationTracker : IGraduationTracker
    {
        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;

            foreach (var diplomaRequirement in diploma.Requirements)
            {
                foreach (var requiredcourse in diplomaRequirement.Courses.ToList())
                {
                    var studentCourse = student.Courses.SingleOrDefault(c => c.Id == requiredcourse.Id);
                    if (studentCourse != null)
                    {
                        average += studentCourse.Mark;
                        credits += (studentCourse.Mark > diplomaRequirement.MinimumMark) ? diplomaRequirement.Credits : 0;
                    }
                }
            }

            average = average / student.Courses.Length;          
            var standing = GetStanding(average);

            return (standing == STANDING.Average ||
                    standing == STANDING.SumaCumLaude ||
                    standing == STANDING.MagnaCumLaude)
                        ? new Tuple<bool, STANDING>(true, standing)
                        : new Tuple<bool, STANDING>(false, standing);
        }

        private static STANDING GetStanding(int average)
        {
            STANDING standing;
            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80 && average > 50)
                standing = STANDING.Average;
            else if (average < 95  && average > 80)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.SumaCumLaude;
            return standing;
        }
    }
}
