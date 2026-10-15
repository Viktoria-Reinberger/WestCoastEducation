namespace WestCoastEducation
{
    public class CourseLeader : Teacher
    {
        public DateTime DateOfHire { get; set; } 
        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Anställd:{DateOfHire:d}";
        }
    }
}