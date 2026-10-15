using System.Collections.Generic;
namespace WestCoastEducation
{
    public class EducationData
    {
        public List<Course> Courses { get; set; } = new();
        public List<Teacher> Teachers { get; set; } = new();
        public List<Student> Students { get; set; } = new();
        public List<CourseLeader> CourseLeaders { get; set; } = new();
        public List<Administrator> Administrators { get; set; } = new();
        
        
         public List<CourseApplication> Applications { get; set; } 
         = new List<CourseApplication>();
    }
}