using Main;
namespace Main
{
    interface A
    {
        string Name { get; set; }
        int Age {  get; set; }
    }
    struct Person : A
    {
        public char Gender { get; set; }
        private string name;
        private int age;    
        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
            }
        }      
        public int Age
        {
            get => age;
            set
            {
                if (value > 0)
                    age = value;
            }
        }
        public Person(string name, int age, char gender)
        {
            this.Name = name;
            this.Age = age;
            if (gender == 'M' || gender == 'W') { Gender = gender; }

        }
        public void PrintInfo() => Console.WriteLine($"Name: {name} Age: {age} Gender: {Gender}");

    }
}
    internal class Program
    {
        static void Main(string[] args)
        {

        var person = new Person
        {
            Name = "Azam",
            Age = 16,
            Gender = 'M'
        };
        person.PrintInfo();
    }
    }
