using System;

namespace GraduationTracker
{
    public interface IGraduationTracker
    {
         Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student);
    }
}
