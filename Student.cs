namespace WestCoastEducation
{
    public class Student : Person, IDisplayable
    {
        public override string GetInfo()
        {
            return $"Student: {base.GetInfo()}";
        }
       
    }
}