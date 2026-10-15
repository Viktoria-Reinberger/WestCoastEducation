namespace WestCoastEducation
{
    public class CourseApplication
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string CourseCode { get; set; } = "";
        public string Status { get; set; } = " Väntar på beslut";

        public string GetInfo()
        {
            return $"Sökande: {FirstName } {LastName}\n" + 
            $"Kurskod: {CourseCode}`\n" +
            $"Status: {Status}";
        }
    }
}