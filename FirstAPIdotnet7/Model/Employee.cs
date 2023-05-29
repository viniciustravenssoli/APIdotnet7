using System.ComponentModel.DataAnnotations;

namespace FirstAPIdotnet7.Model
{
    public class Employee
    {
        public Employee(string name, int age, string photo)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
            this.photo = photo;
        }

        [Key]
        public int id { get; private set; }

        public string name { get; private set; }

        public int age { get; private set; }
        
        public string? photo { get; private set; }

    }
}
