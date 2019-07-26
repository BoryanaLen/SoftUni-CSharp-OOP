namespace ValidationAttributes
{
    public class Person
    {
        private const int MIN_AGE = 12;

        private const int MAX_AGE = 90;

        [MyRequiredAttribute]
        public string FullName { get; private set; }

        [MyRangeAttribute(MIN_AGE,MAX_AGE)]
        public int Age { get; private set; }

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }
    }
}
