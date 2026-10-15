namespace WestCoastEducation
{
    public class Person : IDisplayable
    {
       public string FirstName { get; set; } ="";
        public string LastName { get; set; } ="";
        public int PhoneNumber { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string Address { get; set; } ="";
        public int PostalCode { get; set; }
        public string Town { get; set; } ="";

        public virtual string GetInfo()
        {
            return $"{FirstName} {LastName}";
        }
    }
}