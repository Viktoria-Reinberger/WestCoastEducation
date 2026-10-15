namespace WestCoastEducation
{
    public class Teacher : Person
    {
        public string KnowledgeArea { get; set; } ="";
        public string ResponsibleCourses { get; set; } ="";

        public override string GetInfo()
        {
            return $"Teacher: {base.GetInfo()}, {KnowledgeArea}, {ResponsibleCourses}";
        }
        
    }
}