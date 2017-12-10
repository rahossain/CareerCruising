namespace GraduationTracker
{
    public class Diploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public Requirement[] Requirements { get; set; }
    }
}
