using WestCoastEducation;
using System.Text.Json;
using System.IO;

string filePath = "westcoast.json";

var options = new JsonSerializerOptions
{
    WriteIndented = true
};

EducationData educationData;

if (File.Exists(filePath))
{
    string savedJson = File.ReadAllText(filePath);

    educationData =
        JsonSerializer.Deserialize<EducationData>(savedJson)
        ?? new EducationData();
}
else
{
    educationData = new EducationData();

    // Skapa grunduppgifter första gången programmet körs

    CourseLeader courseLeader = new CourseLeader
    {
        FirstName = "Robert",
        LastName = "Robertsson",
        KnowledgeArea = "Utbildningsledare",
        DateOfHire = new DateTime(2000, 1, 1)
    };

    Administrator administrator = new Administrator
    {
        FirstName = "Thomas",
        LastName = "Thomasson",
        KnowledgeArea = "Administration",
        DateOfHire = new DateTime(2000, 1, 1)
    };

    Teacher teacher = new Teacher
    {
        FirstName = "Michael",
        LastName = "Gustavsson",
        PhoneNumber = 768505959,
        Town = "Malmö",
        PostalCode = 21115,
        SocialSecurityNumber = 1979000011,
        Address = "Propellergatan 1",
        KnowledgeArea = "Systemutveckling med säkerhets inriktning"
    };

    Student student = new Student
    {
        FirstName = "Viktoria",
        LastName = "Reinberger",
        PhoneNumber = 768505939,
        Town = "Malmö",
        PostalCode = 21115,
        SocialSecurityNumber = 307300000,
        Address = "Propellergatan 1"
    };

    Student student2 = new Student
    {
        FirstName = "David",
        LastName = "Eriksson"
    };

    Student student3 = new Student
    {
        FirstName = "Emma",
        LastName = "Lindborg"
    };

    Student student4 = new Student
    {
        FirstName = "Bengt",
        LastName = "Nilsson"
    };

    Course initialcourse = new Course
    {
        CourseName = "c# Grund - Programmering 1",
        CourseCode = "SySä26",
        Teacher = teacher,
        CourseStartDate = new DateTime(2026, 8, 15),
        CourseEndDate = new DateTime(2028, 5, 14),
        CoursePoints = 850
    };

    initialcourse.AddStudent(student);
    initialcourse.AddStudent(student2);
    initialcourse.AddStudent(student3);
    initialcourse.AddStudent(student4);

    educationData.Courses.Add(initialcourse);
    educationData.Teachers.Add(teacher);

    educationData.Students.Add(student);
    educationData.Students.Add(student2);
    educationData.Students.Add(student3);
    educationData.Students.Add(student4);

    educationData.CourseLeaders.Add(courseLeader);
    educationData.Administrators.Add(administrator);

    educationData.Applications.Add(new CourseApplication
    {
        FirstName = "Sofie",
        LastName = "Sofiesson",
        CourseCode = "SySä26"
    });

    string initialJson =
        JsonSerializer.Serialize(educationData, options);

    File.WriteAllText(filePath, initialJson);
}

// Använd listorna från den sparade informationen

List<Course> courses = educationData.Courses;
List<Teacher> teachers = educationData.Teachers;
List<Student> students = educationData.Students;
List<CourseLeader> courseLeaders = educationData.CourseLeaders;
List<Administrator> administrators = educationData.Administrators;
List<CourseApplication> applications = educationData.Applications;

// Använd den första kursen som standardkurs
Course course = courses[0];

Console.WriteLine("WestCoast Education System");

//Meny med alternativ

bool running = true;
while (running)
{
    Console.Clear();

    Console.WriteLine("******************************");
    Console.WriteLine(" WestCoast Education System ");
    Console.WriteLine("******************************");
    Console.WriteLine(" Tryck 1. Visa kursinformation ");
    Console.WriteLine(" Tryck 2. Visa lärarinformation ");
    Console.WriteLine(" Tryck 3. Visa alla studenter ");
    Console.WriteLine(" Tryck 4. Visa utbildningsledare och administratör ");
    Console.WriteLine(" Tryck 5. Hantera kursansökningar ");
    Console.WriteLine(" Tryck 6. Lägg till lärare ");
    Console.WriteLine(" Tryck 7. Lägg till student ");
    Console.WriteLine(" Tryck 8. Lägg till kurs ");
    Console.WriteLine(" Tryck 9. Lägg till utbildningsledare / administratör ");
    Console.WriteLine(" Tryck 0. Avsluta programmet");
    Console.WriteLine("******************************");
    Console.WriteLine("Välj ett alternativ");

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
        Console.WriteLine("--Visa Kursinformation--");
        foreach (Course currentCourse in courses)
            {
                Console.WriteLine(currentCourse.GetInfo());
                Console.WriteLine();
            }
        break;

        case "2":
        Console.WriteLine("Visa lärarinformation");
        foreach (Teacher teacher in teachers)
            {
                Console.WriteLine(teacher.GetInfo());
                Console.WriteLine();
            }
        break;

        case "3":
        Console.WriteLine("Visa alla studenter");
        course.ListStudents();
        break;

        case "4":
       Console.WriteLine("--Utbildningsledare--");

       foreach (CourseLeader leader in courseLeaders)
            {
                Console.WriteLine(leader.GetInfo());
                Console.WriteLine();
            }

            Console.WriteLine("--Administratör--");
            foreach (Administrator admin in administrators)
            {
                Console.WriteLine(admin.GetInfo());
                Console.WriteLine();
            }
        break;

        case "5":
        Console.WriteLine("Hantera kursansökningar");
        bool applicationMenu = true;

            while (applicationMenu)
            {
                Console.WriteLine();
                Console.WriteLine("--- Hantera kursansökningar ---");
                Console.WriteLine(" 1. Visa inkomna ansökningar");
                Console.WriteLine(" 2. Godkänn ansökan");
                Console.WriteLine(" 3. Avslå ansökan");
                Console.WriteLine(" 0. Tillbaka till huvudmeny");
                Console.Write(" -- Välj ett alternativ: --");

                string applicationChoice = Console.ReadLine() ?? "";
                switch (applicationChoice)
                {
                    case "1":
                    Console.WriteLine(" ---Visa inkomna ansökningar---");
                    if (applications.Count == 0)
                    {
                      Console.WriteLine("Det finns inga inkomna ansökningar");
                    }
                        else
                    {
                       for (int i = 0; i < applications.Count; i++)
                    {
                        Console.WriteLine(applications[i].GetInfo());
                    }
                }
                Console.ReadKey();
                    break;

                    case "2":
                    Console.WriteLine("---Godkänn ansökningar--");

                    if (applications.Count == 0)
                        {
                            Console.WriteLine("Det finns inga ansökningar att godkänna!!");
                            break;
                        }

                        for (int i = 0; i < applications.Count; i++)
                        {
                            Console.WriteLine(
                           $"{i + 1}. {applications[i].FirstName}" +
                           $"{applications[i].LastName} - " +
                           $"Kurskod: {applications[i].CourseCode} - " +
                           $"{applications[i].Status}" );
                        }

                        Console.Write(" Ange numret på ansökan: ");

                        if (int.TryParse(Console.ReadLine(), out int approvedNumber) && approvedNumber >= 1 && approvedNumber <= applications.Count)
                        {
                            applications[approvedNumber - 1].Status = "Godkänd";
                            Console.WriteLine("Ansökan har godkänts!");
                        }

                        else
                        {
                            Console.WriteLine("Ogiltigt ansökningsnummer!");
                        }
                        break;
                    

                    case "3":
                    Console.WriteLine("--Avslå ansökningar!--");
                    if (applications.Count == 0)
                        {
                            Console.WriteLine("Det finns inga ansökningar att avslå!!");
                            break;
                        }

                        for (int i = 0; i < applications.Count; i++)
                        {
                            Console.WriteLine(
                            $"{i + 1}. {applications[i].FirstName}" + 
                            $"{applications[i].LastName} - " +
                            $"Kurskod: {applications[i].CourseCode} - " +
                            $"{applications[i].Status}");
                        }

                        Console.Write("Ange numret på ansökan: ");

                        if (int.TryParse(Console.ReadLine(), out int rejectedNumber) && 
                        rejectedNumber >= 1 && rejectedNumber <= applications.Count)
                        {
                            applications[rejectedNumber - 1].Status = "Avslagen";
                            Console.WriteLine("Ansökan har avslagits");
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt ansökningsnummer.");
                        }
                    break;

                    case "0":
                    applicationMenu = false;
                    break;

                    default:
                    Console.WriteLine("Ogiltigt val!");
                    
                    SaveEducationData(educationData, filePath);

                    break;

                   
                }
            }
        break;

        case "6":
        Console.WriteLine("---Lägg till lärare---");

        Teacher newTeacher = new Teacher();
        Console.Write("Förnamn: ");
        newTeacher.FirstName = Console.ReadLine() ?? "";

        Console.Write("Efternamn: ");
        newTeacher.LastName = Console.ReadLine() ?? "";

        Console.Write("Adress: ");
        newTeacher.Address = Console.ReadLine() ??"";

        Console.Write("Postnummer: ");

        if (int.TryParse(Console.ReadLine(), out int postalCode))
            {
                newTeacher.PostalCode = postalCode;
            }

            Console.Write("ort: ");
            newTeacher.Town = Console.ReadLine() ?? "";

            teachers.Add(newTeacher);

            SaveEducationData(educationData, filePath);

            Console.WriteLine("Läraren har registrerats!!");
            Console.WriteLine(newTeacher.GetInfo());

        break;

        case "7":
        Console.WriteLine("---Lägg till student---");
        
        Student newStudent = new Student();
        
        Console.Write("Förnamn: ");
        newStudent.FirstName = Console.ReadLine() ?? "";

        Console.Write("Efternamn: ");
        newStudent.LastName = Console.ReadLine() ?? "";

        Console.Write("Telefonnummer: ");
        if (int.TryParse(Console.ReadLine(), out int phoneNumber))
            {
                newStudent.PhoneNumber = phoneNumber;
            
            }

            Console.Write("Adress: ");
            newStudent.Address = Console.ReadLine() ?? "";

            Console.Write("Postnummer: ");
            string postalCodeInput = Console.ReadLine() ?? "0";

            if (int.TryParse(postalCodeInput, out int parsedPostalCode))
            {
                newStudent.PostalCode = parsedPostalCode;
            }
            else
            {
                Console.WriteLine("Ogiltigt postnummer!!");
            }

            Console.Write("Ort: ");
            newStudent.Town = Console.ReadLine() ?? "";
            
        course.AddStudent(newStudent);

        SaveEducationData(educationData, filePath);

        Console.WriteLine("Studenten har lagts till!");
        Console.WriteLine(newStudent.GetInfo());
        break;

        case "8":
        Console.WriteLine("---Lägg till kurs---");
        Course newCourse = new Course();

        Console.Write("Kursnamn: ");
        newCourse.CourseName = Console.ReadLine() ?? "";

        Console.Write("Kurskod: ");
        newCourse.CourseCode = Console.ReadLine() ?? "";

        Console.Write("Antal kurspoäng: ");
        if (int.TryParse(Console.ReadLine(), out int CoursePoints))
            {
                newCourse.CoursePoints = CoursePoints;
            }
            else
            {
                Console.WriteLine("Ogiltigt antal kurspoäng!");
                break;
            }

            Console.Write("Startdatum (ÅÅÅÅ-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                newCourse.CourseStartDate = startDate;
            }
            else
            {
                Console.WriteLine("Ogitligt startdatum!!!");
                break;
            }

            Console.WriteLine("Slutdatum (ÅÅÅÅ-MM-DD)");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
            {
                newCourse.CourseEndDate = endDate;
            }
            else
            {
                Console.WriteLine("Ogiltigt slutdatum!!");
                break;
            }

            courses.Add(newCourse);

            SaveEducationData(educationData, filePath);

            Console.WriteLine("Kursen har skapats!!");
            Console.WriteLine(newCourse.GetInfo());
        break;

        case "9":
        Console.WriteLine("---Lägg till utbildningsledare / administratör---");
        Console.WriteLine("1. Lägg till utbildningsledare");
        Console.WriteLine("2. Lägg till administratör");
        Console.Write("Välj ett alternativ");

        string staffChoice = Console.ReadLine() ??"";

        if (staffChoice == "1")
            {
                CourseLeader newCourseLeader = new CourseLeader();

                Console.Write("Förnamn: ");
                newCourseLeader.FirstName = Console.ReadLine() ?? "";

                Console.Write("Efternamn. ");
                newCourseLeader.LastName = Console.ReadLine() ??"";

                Console.Write("Kunskapsområde: ");
                newCourseLeader.KnowledgeArea = Console.ReadLine() ??"";

                Console.Write("Anställningsdatum (ÅÅÅÅ-MM-DD): ");

                if (DateTime.TryParse(
                    Console.ReadLine(), out DateTime hireDate))
                {
                    newCourseLeader.DateOfHire = hireDate;
                }
                else
                {
                    Console.WriteLine("Ogiltigt datum!");
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Utbildningsledaren har registrerats!!");
                Console.WriteLine(newCourseLeader.GetInfo());
                courseLeaders.Add(newCourseLeader);

                SaveEducationData(educationData, filePath);
            }
            else if (staffChoice == "2")
            {
                Administrator newAdministrator = new Administrator();

                Console.Write("Förnamn: ");
                newAdministrator.FirstName = Console.ReadLine()?? "";

                Console.Write("Efternamn: ");
                newAdministrator.LastName = Console.ReadLine()?? "";

                Console.Write ("Kunskapsområde: ");
                newAdministrator.KnowledgeArea = Console.ReadLine() ??"";

                Console.Write("Anställnigsdatum (ÅÅÅÅ-MM-DD: )");

                if (DateTime.TryParse(

                 Console.ReadLine(), out DateTime hireDate))
                {
                    newAdministrator.DateOfHire = hireDate;
                }

                else
                {
                    Console.WriteLine("Ogiltigt datum!");
                    break;
                }

                
                Console.WriteLine("Administratören har registrerats!");
                Console.WriteLine(newAdministrator.GetInfo());
                administrators.Add(newAdministrator);

                SaveEducationData(educationData, filePath);
            }

            else
            {
                Console.WriteLine("Ogiltigt val!");
            }
        break;

        case "0":
        running = false;
        Console.WriteLine("Programmet avslutas.");
        break;

        default:
        Console.WriteLine("Ogiltigt val, försök igen.");
        break;

    }

    if (running)
    {
        Console.WriteLine();
        Console.WriteLine("Tryck på valfri tangent för att fortsätta .. ");
        Console.ReadKey();
    }

void SaveEducationData(EducationData data, string path)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

    string json = JsonSerializer.Serialize(data, options);

    File.WriteAllText(path,json);
    }
    

}