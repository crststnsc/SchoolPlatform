namespace SchoolPlatform.Models.EntityLayer
{
    public class Grade : BaseEntity
    {
        public int Value { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public bool IsSemestrial { get; set; }
    }
}