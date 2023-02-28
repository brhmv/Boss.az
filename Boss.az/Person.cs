namespace Boss.az
{
    internal class Person
    {
        #region Properties
        private static int ID = 0;

        public int ObjectId { get; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }
        #endregion

        public Person() {
            ObjectId = ID++;
        }

        public Person(string name, string surname, int age, string phone, string city)
        {
            //Password= password;
            ObjectId=ID++;
            Name = name;
            Surname = surname;
            Age = age;
            Phone = phone;
            City = city;
        }

        public override string ToString() => $"Id: {ObjectId} {Name} {Surname} {Age} years old. From {City}. Phone: {Phone}\n";
    }
}