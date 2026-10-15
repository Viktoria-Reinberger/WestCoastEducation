namespace WestCoastEducation
{
  public class Course : IDisplayable
    {
        public string CourseName { get; set; } = "";
        public string CourseCode { get; set; } = "";
        public int CoursePoints { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public bool DistanceCourse { get; set; }
        public Teacher Teacher { get; set; } = new();
        public List<Student> Students { get; set; } = new();

        public string GetInfo()
        {
            return $"{CourseCode} - {CourseName}";
        }
        
        public void AddStudent(Student Student)
        {
            Students.Add(Student);
        }

        public void ListStudents()
        {
            foreach (Student student in Students)
            {
                Console.WriteLine(student.GetInfo());
            }
        }

        public bool LimitOfStudents()
        {
           return Students.Count >= 30;
        }

    
    }
}