namespace Student.ViewModels.ViewModels
{
    public class StudentView
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; } = null!;
        public byte? Gender { get; set; }
        public DateOnly? Dob { get; set; }

        public List<MarkView> Marks { get; set; }
    }
}
