namespace Question1
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }

    public class PersonImplementation
    {
        public string GetName(IList<Person> persons)
        {
            string result = "";
            foreach (var person in persons)
            {
                result += $"{person.Name} {person.Address}{Environment.NewLine}";
            }
            return result.Trim();
        }

        public double Average(IList<Person> persons)
        {
            int sum = 0;
            foreach (var person in persons)
            {
                sum += person.Age;
            }
            return (double)sum / persons.Count;
        }

        public int Max(IList<Person> persons)
        {
            int maxAge = persons[0].Age;
            for (int i = 1; i < persons.Count; i++)
            {
                if (persons[i].Age > maxAge)
                {
                    maxAge = persons[i].Age;
                }
            }
            return maxAge;
        }
    }

    class Program
    {
        static void Main()
        {
            IList<Person> persons = new List<Person>
    {
        new Person { Name = "Aarya", Address = "A2101", Age = 69 },
        new Person { Name = "Daniel", Address = "D104", Age = 40 },
        new Person { Name = "Ira", Address = "H801", Age = 25 },
        new Person { Name = "Jennifer", Address = "11704", Age = 33 }
    };

            PersonImplementation implementation = new PersonImplementation();

            Console.WriteLine(implementation.GetName(persons));
            Console.WriteLine(implementation.Average(persons));
            Console.WriteLine(implementation.Max(persons));
        }
    }

}
