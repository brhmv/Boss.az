namespace Boss.az
{
    internal class Worker : Person
    {
        public CV? CV { get; set; }

        public Worker(string name, string surname, string city, string phone, sbyte age, CV? cv = null)
            : base(name, surname, age, phone, city)
        {
            CV = cv;
        }

        public static Worker AddWorker()
        {
            while (true)
            {
                try
                {
                    string? name, surname, city, phone;
                    sbyte age;
                    Console.Write("Insert your name: ");
                    name = Console.ReadLine();

                    Console.Write("Insert your Surname: ");
                    surname = Console.ReadLine();

                    Console.WriteLine("Insert your age:");
                    age = Convert.ToSByte(Console.ReadLine());

                    Console.Write("Insert your adress(City): ");
                    city = Console.ReadLine();

                    Console.Write("Insert your phone: ");
                    phone = Console.ReadLine();

                    Console.WriteLine("Insert password: ");
                    string? password= Console.ReadLine();

                    Worker w = new(name, surname, city, phone, age);
                    w.Password = password;
                    
                    return w;
                    //return new(name, surname, city, phone, age);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    continue;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine(base.ToString);
            CV.Print();
        }
    }
}