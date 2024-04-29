namespace Student.ViewModels.ViewModels
{
    public class StudentView
    {
        public int Id { get; set; }
        //public Guid StudentId { get; set; }
        public string Name { get; set; } = null!;
        public byte? Gender { get; set; }
        public DateOnly? Dob { get; set; }


        //student can have multiple markdetails.
        public  List<MarkView> Markdetail { get; set; }

        //public List<MarkView> Marks { get; set; }
    }
}