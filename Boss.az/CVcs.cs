namespace Boss.az
{
    enum Level { A1 = 1, A2, B1, B2, C1, C2 }
    enum CVstatus { accepted=1,reject}

    class Language
    {
        #region Properties
        public string? Name { get; set; }
        public Level languageLevel { get; set; }
        #endregion

        public Language(string name, Level languageLevel)
        {
            Name = name;
            this.languageLevel = languageLevel;
        }

        public static Language CreateLanguage()
        {
            while (true)
            {
                try
                {
                    string? name;
                    Console.WriteLine("Insert language name: ");
                    name = Console.ReadLine();

                    Level languageLevel;
                    Console.WriteLine("Insert level of it( 1)A1 2)A2 3)B1 4)B2 5)C1 6)C2)");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    var a = Level.A1;

                    switch (choice)
                    {
                        case 1:
                            languageLevel = Level.A1;
                            break;
                        case 2:
                            languageLevel = Level.A2;
                            break;
                        case 3:
                            languageLevel = Level.B1;
                            break;
                        case 4:
                            languageLevel = Level.B2;
                            break;
                        case 5:
                            languageLevel = Level.C1;
                            break;
                        case 6:
                            languageLevel = Level.C2;
                            break;
                        default:
                            Console.WriteLine("Choose one of them!");
                            Console.ReadKey();
                            continue;
                    }
                    return new(name, languageLevel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    continue;
                }

            }
        }

        public override string ToString() => $"{Name}=>{languageLevel}\n";
    }

    internal class CV
    {
        #region Properties
        public CVstatus CVstatus { get; set; }

        public string? Proffesion { get; set; }

        public string? UniversityName { get; set; }

        public double UniversityScore { get; set; }

        public string[]? Skills { get; set; }

        public double Experience { get; set; }

        public string[]? Companies { get; set; }

        public bool DifferSertificate { get; set; }

        public string? Linkedin { get; set; }

        public string? Gitlink { get; set; }

        public List<Language>? Languages { get; }
        #endregion

        public CV(string? profession, string? universityName, double universityScore, string[]? skills, string[]? companies,

        bool differSertificate, string? linkedin, string? gitlink, List<Language>? languages, double experience)
        {
            Proffesion = profession;
            UniversityName = universityName;
            UniversityScore = universityScore;
            Skills = skills;
            Companies = companies;
            DifferSertificate = differSertificate;
            Linkedin = linkedin;
            Gitlink = gitlink;
            Languages = languages;
            Experience = experience;
        }

        public static CV CreateCv()
        {
            while (true)
            {
                try
                {
                    string? profession, universityname, linkedin, gitlink;

                    double universityScore, experience;

                    bool differSertificate;

                    string[] skills;
                    string[] companies;

                    Console.Write("Insert your profession: ");
                    profession = Console.ReadLine();

                    Console.Write("Insert your university name: ");
                    universityname = Console.ReadLine();

                    Console.Write("Insert your university enterance score: ");
                    universityScore = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Insert your university enterance score: ");
                    experience = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Do you have special certificate from university(yes=1 no=0) ?");
                    differSertificate = Convert.ToBoolean(Console.ReadLine());

                    Console.Write("Insert your linkedin: ");
                    linkedin = Console.ReadLine();

                    Console.Write("Insert your gitlink: ");
                    gitlink = Console.ReadLine();

                    Console.WriteLine("Insert your skills (use | for split):");
                    skills = Console.ReadLine().Split('|');


                    Console.WriteLine("Insert companies which you worked (use | for split):");
                    companies = Console.ReadLine().Split('|');

                    List<Language> languages = default;

                    int lcount = default;

                    Console.Write("Insert amount of languages:");
                    lcount = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < lcount; i++)
                    {
                        Language l = Language.CreateLanguage();
                        languages.Add(l);
                    }

                    return new(profession, universityname, universityScore, skills, companies, differSertificate, linkedin, gitlink, languages, experience);
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
            Console.WriteLine($"**CV**\nProffesion:{Proffesion}\nUniversity:{UniversityName}\nUniversity Score:{UniversityScore}\nSpecial Certificste:{DifferSertificate}\n");

            Console.WriteLine("Skills:");
            foreach (var item in Skills)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Companies:");
            foreach (var item in Companies)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Languages:");
            foreach (var item in Languages)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"GitLink: {Gitlink}");
            Console.WriteLine($"Linkedin: {Linkedin}");
        }
    }
}