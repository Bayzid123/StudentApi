namespace StudentApi.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Department { get; set; } = String.Empty ;
        public float CGPA { get; set; }
    }
}
