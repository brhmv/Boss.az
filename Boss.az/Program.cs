using Boss.az;
using System.Text.Json;

List<Worker> Workers = new();

List<Employer> Employers = new();

List<Vacancy> AllVacancies = new();

#region Test

Employer e1 = new("ali", "aliyev", 42, "055", "baku");
Employer e2 = new("akif", "Alziade", 23, "050", "baku");
Employer e3 = new("aqil", "Agazade", 13, "070", "baku");

Vacancy v11 = new("it1", "a", 2000, 6, 45, Worktype.Remoute);
v11.FromWhichEmployer = e1;

Vacancy v12 = new("it1", "a", 100, 2, 50, Worktype.Freelance);
v12.FromWhichEmployer = e1;

Vacancy v21 = new("it2", "a", 30000, 1, 55, Worktype.Fulltime);
v21.FromWhichEmployer = e2;

Vacancy v22 = new("it2", "a", 1500, 3, 55, Worktype.Parttime);
v22.FromWhichEmployer = e2;

Vacancy v31 = new("it3", "a", 3000, 4, 65, Worktype.Freelance);
v31.FromWhichEmployer = e3;

Vacancy v32 = new("it3", "a", 2500, 0, 45, Worktype.Outsource);
v32.FromWhichEmployer = e3;

Employers.Add(e1);
Employers.Add(e2);
Employers.Add(e3);

e1.AddVacancy(v12);
e1.AddVacancy(v11);
e2.AddVacancy(v22);
e2.AddVacancy(v21);
e3.AddVacancy(v31);
e3.AddVacancy(v32);

List<Vacancy> vs1 = new();
List<Vacancy> vs2 = new();
List<Vacancy> vs3 = new();

vs1.Add(v12);
vs1.Add(v11);
vs2.Add(v21);
vs2.Add(v22);
vs3.Add(v31);
vs3.Add(v32);

e1.Vacancies = vs1;
e2.Vacancies = vs2;
e3.Vacancies = vs3;

#endregion

#region Functions
//read from file
void readEmployersFromFileToList(List<Employer> list1)
{
    var json = File.ReadAllText("Employers.json");
    list1 = JsonSerializer.Deserialize<List<Employer>>(json);
}

void readWorkerssFromFileToList(List<Worker> list)
{
    var json = File.ReadAllText("Workers.json");
    list = JsonSerializer.Deserialize<List<Worker>>(json);
}

//Write to File
void writeEmployersToFile(List<Employer> list)
{
    var json1 = JsonSerializer.Serialize(list);
    File.WriteAllText("Employers.json", json1);
}

void writeWorkersToFile(List<Worker> list)
{
    var json1 = JsonSerializer.Serialize(list);
    File.WriteAllText("Workers.json", json1);
}

//////////////////////////////////////////////////////////

Employer GetEmployerFromList(string? empname, string? emppassword)
{
    foreach (var item in Employers)
    {
        if (item.Name == empname && item.Password == emppassword)
        {
            return item;
        }
    }
    return null;
}

Worker GetWorkerFromList(string? workername, string? workerpassword)
{
    foreach (var item in Workers)
    {
        if (item.Name == workername && item.Password == workerpassword)
        {
            return item;
        }
    }
    return null;
}

//////////////////////////////////////////////////////////

bool EmployerIsExistInList(string? empname, string? emppassword)
{
    foreach (var item in Employers)
    {
        if (item.Name == empname && item.Password == emppassword)
        {
            return true;
        }
    }
    return false;
}

bool WorkersIsExistInList(string? workername, string? workerpassword)
{
    foreach (var item in Workers)
    {
        if (item.Name == workername && item.Password == workerpassword)
        {
            return true;
        }
    }
    return false;
}

//////////////////////////////////////////////////////////

int IDgetter()
{
    Console.WriteLine("Insert Id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    return id;
}

//ilk ishlet bunu ki vacansiyalar liste yigilsin
void FillListWithAllVacancies()
{
    foreach (var item in Employers)
    {
        foreach (var item1 in item.Vacancies)
        {
            AllVacancies.Add(item1);
        }
    }
}

void ShowAnyVacancyList(List<Vacancy> list)
{
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }
}

void FilterVacancies()
{
    List<Vacancy> vacanciesForFilter = AllVacancies;

    bool exit = false;

    while (!exit)
    {
        try
        {
            int choice;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1)FilterVacancieByAge\n2)FilterVacancieByName\n3)FilterVacancieByExperience\n4)FilterVacancieBySalary\n5)FilterVacancieByWorkType\n6)Exit\n");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            switch (choice)
            {
                case 1:
                    sbyte maxAge;
                    Console.WriteLine("Insert maximum age: ");
                    maxAge = Convert.ToSByte(Console.ReadLine());
                    vacanciesForFilter = Filter.FilterVacancieByAge(vacanciesForFilter, maxAge);
                    Console.Clear();
                    break;
                case 2:
                    string? jobName;
                    Console.WriteLine("Insert Job name: ");
                    jobName = Console.ReadLine();
                    vacanciesForFilter = Filter.FilterVacancieByName(vacanciesForFilter, jobName);
                    break;
                case 3:
                    sbyte experience;
                    Console.WriteLine("Insert minumum experience: ");
                    experience = Convert.ToSByte(Console.ReadLine());
                    vacanciesForFilter = Filter.FilterVacancieByExperience(vacanciesForFilter, experience);
                    break;
                case 4:
                    double minSalary;
                    Console.WriteLine("Insert minumum Salary: ");
                    minSalary = Convert.ToDouble(Console.ReadLine());
                    vacanciesForFilter = Filter.FilterVacancieBySalary(vacanciesForFilter, minSalary);
                    break;

                case 5:
                    Worktype wt;
                    Console.Write("Insert worktype 1)Fulltime 2)Part-time 3)Freelance 4)Remoute 5)Outsource: ");
                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    switch (choice2)
                    {
                        case 1:
                            wt = Worktype.Fulltime;
                            break;
                        case 2:
                            wt = Worktype.Parttime;
                            break;
                        case 3:
                            wt = Worktype.Freelance;
                            break;
                        case 4:
                            wt = Worktype.Remoute;
                            break;
                        case 5:
                            wt = Worktype.Outsource;
                            break;
                        default:
                            continue;
                    }

                    vacanciesForFilter = Filter.FilterVacancieByWorkType(vacanciesForFilter, wt);
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Choose one of them!");
                    Thread.Sleep(1000);
                    continue;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();

            ShowAnyVacancyList(vacanciesForFilter);
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            continue;
        }
    }
}

void EditNotifications(Employer Item)
{
    int ch2;
    while (true)
    {
        Console.Clear();
        Item.ShowAllNotifications();
        Console.WriteLine("1)Delete Notification(ID)\n2)Accept Notification(ID)\n3)Reject Notification(ID)\n4)Exit\n");
        ch2 = Convert.ToInt32(Console.ReadLine());

        if (ch2 == 1)
        {
            Console.Clear();
            Item.ShowAllNotifications();
            Item.DeleteNotification(IDgetter());
            Console.ReadKey();
            Console.Clear();
        }
        else if (ch2 == 2)
        {
            Console.Clear();
            Item.ShowAllNotifications();
            Item.AcceptNotification(IDgetter());
            Console.ReadKey();
            Console.Clear();
        }
        else if (ch2 == 3)
        {
            Console.Clear();
            Item.ShowAllNotifications();
            Item.RejectNotification(IDgetter());
            Console.ReadKey();
            Console.Clear();
        }
        else if (ch2 == 4) break;
        else
        {
            ElseFunction();
            continue;
        }
    }
}

void apply(string? content, Worker worker)
{
    int id;
    Console.WriteLine("Id:");
    id = Convert.ToInt32(Console.ReadLine());

    foreach (var item in Employers)
    {
        foreach (var vacancy in item.Vacancies)
        {
            if (vacancy.ObjectId == id)
            {
                item.Notifications.Add(new Notification(content, worker, vacancy));
            }
        }
    }
}


List<CV> GetCVsFromAllNotification(Employer employer)
{
    List<CV> cvs = new();

    foreach (var item in employer.Notifications)
    {
        cvs.Add(item.Worker.CV);
    }
    return cvs;
}

void ElseFunction()
{
    Console.WriteLine("Choose one of them!");
    Console.ReadKey();
    Console.Clear();
}
#endregion

/////////
//Start//

writeEmployersToFile(Employers);

List<Employer> temp=null;

readEmployersFromFileToList(temp);

//readWorkerssFromFileToList(Workers);




FillListWithAllVacancies();

//foreach (var item in temp)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine();

//foreach (var item in AllVacancies)
//{
//    Console.WriteLine(item);
//}

while (true)
{
    int ch2;
    Console.WriteLine("1)Employer 2)Worker 3)Exit");
    ch2 = Convert.ToInt32(Console.ReadLine());

    //employer

    if (ch2 == 1)
    {
        while (true)
        {
            Console.WriteLine("1)Sign up\n2)Sign in\n3)Exit\n");

            ch2 = Convert.ToInt32(Console.ReadLine());

            if (ch2 == 1)
            {
                //addNewEmployerToFile();
                Employers.Add(Employer.CreateEmployer());
                continue;
            }

            else if (ch2 == 2)
            {
                string name, password;
                Console.WriteLine("Insert name: ");
                name = Console.ReadLine();

                Console.WriteLine("Insert password: ");
                password = Console.ReadLine();

                if (EmployerIsExistInList(name, password))
                {
                    Employer Item = GetEmployerFromList(name, password);
                    while (true)
                    {
                        Console.WriteLine("1)Show all vacancies\n2)Show all Notifications\n3)Exit\n");
                        ch2 = Convert.ToInt32(Console.ReadLine());

                        if (ch2 == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("1)Add Vacancy\n2)Delete Vacancy\n3)Exit\n");
                            ch2 = Convert.ToInt32(Console.ReadLine());

                            if (ch2 == 1)
                            {
                                Console.Clear();
                                Item.AddVacancy(Vacancy.CreateVacancy());
                                Console.WriteLine("Vacancy added succesfully!");
                            }
                            else if (ch2 == 2)
                            {
                                Console.Clear();
                                int id;
                                Console.WriteLine("Insert id:");
                                id = Convert.ToInt32(Console.ReadLine());
                                Item.DeleteVacancy(id);
                                Console.WriteLine("Vacancy deleted succesfully!");
                                Console.ReadKey();
                            }
                            else if (ch2 == 3) break;
                            else
                            {
                                Console.WriteLine("Choose one of them!");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                        }

                        else if (ch2 == 2)
                        {
                            Console.Clear();
                            Item.ShowAllNotifications();
                            EditNotifications(Item);
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else if (ch2 == 3) break;

                        else
                        {
                            ElseFunction();
                            continue;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Employer isnt exist!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }

            else if (ch2 == 3) break;

            else
            {
                ElseFunction();
                continue;
            }
        }
    }

    //worker

    else if (ch2 == 2)
    {
        while (true)
        {
            Console.WriteLine("1)Sign up\n2)Sign in\n3)Exit\n");
            ch2 = Convert.ToInt32(Console.ReadLine());

            if (ch2 == 1)
            {
                Workers.Add(Worker.AddWorker());
                //addNewWorkerToFile();
                continue;
            }

            else if (ch2 == 2)
            {
                string name, password;
                Console.WriteLine("Insert name: ");
                name = Console.ReadLine();

                Console.WriteLine("Insert password: ");
                password = Console.ReadLine();

                if (WorkersIsExistInList(name, password))
                {
                    Worker worker = GetWorkerFromList(name, password);

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1)Create CV\n2)Show All Vacancies\n3)Filter vacancies\n4)Apply Work\n5)Exit:");
                        ch2 = Convert.ToInt32(Console.ReadLine());

                        if (ch2 == 1)
                        {
                            worker.CV = CV.CreateCv();
                            Console.WriteLine("CV created succesfully!");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else if (ch2 == 2)
                        {
                            foreach (var item in AllVacancies)
                            {
                                Console.WriteLine(item);
                            }
                        }

                        else if (ch2 == 3)
                        {
                            FilterVacancies();
                            Console.ReadKey();
                            continue;
                        }

                        else if (ch2 == 4)
                        {
                            Console.WriteLine("Insert content:");
                            string? content = Console.ReadLine();
                            apply(content, worker);
                            Console.WriteLine("Applied succesfully");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        else if (ch2 == 5) break;

                        else
                        {
                            Console.WriteLine("Choose one of them!");
                            Console.ReadKey();
                            continue;
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Worker cant found !");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
            }
            else if (ch2 == 3) break;

            else continue;
        }
    }
    //Exit

    else if (ch2 == 3) break;

    else
    {
        ElseFunction();
        continue;
    }
}

writeEmployersToFile(Employers);
writeWorkersToFile(Workers);