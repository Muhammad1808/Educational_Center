
using O_quvMarkaz.Services;

public static class Program
{
    static void Main(string[] args)
    {
        var service = new Center();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. O`quv markazi");
            Console.WriteLine("2. O`quvchi");
            Console.WriteLine("3. Exit");
            Console.Write("Tanlang: ");
            var choise = Console.ReadLine();
            Console.Clear();

            switch (choise)
            {
                case "1":
                    TrainingCenter(service);
                    Console.Clear();
                    break;
                case "2":
                    Student(service);
                    Console.Clear();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Xato, qaytadan urinib ko`ring");
                    break;

            }
        }

    }

    static void TrainingCenter(Center center)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("    Admin    ");
            Console.WriteLine("1. Kurslar");
            Console.WriteLine("2. Mentorlar");
            Console.WriteLine("3. Arizalar");
            Console.WriteLine("4. Markaz haqida");
            Console.WriteLine("5. Back");
            Console.Write("Tanlang: ");
            var choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    bool back1 = false;
                    while (!back1)
                    {
                        Console.WriteLine("    Admin    ");
                        Console.WriteLine("1. Add Kurs");
                        Console.WriteLine("2. Update Kurs");
                        Console.WriteLine("3. Delete Kurs");
                        Console.WriteLine("4. List Kurslar");
                        Console.WriteLine("5. Back");
                        Console.Write("Tanlang: ");
                        var choice1 = Console.ReadLine();

                        switch (choice1)
                        {
                            case "1":
                                Console.Write("Kurs nomini kiriting: ");
                                var tName = Console.ReadLine();
                                center.AddKurs(tName);
                                Console.WriteLine("Muvaffaqqiyatli qo`shildi");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                Console.Write("Kurs Id sini kiriting: ");
                                var tId = int.Parse(Console.ReadLine());
                                Console.Write("Kurs nomini kiriting: ");
                                var newTName = Console.ReadLine();
                                center.UpdateKurs(tId, newTName);
                                Console.Clear();
                                break;
                            case "3":
                                Console.Write("Kurs Id sini kiriting: ");
                                var deleteTId = int.Parse(Console.ReadLine());
                                center.DeleteKurs(deleteTId);
                                Console.Clear();
                                break;
                            case "4":
                                center.ListKurslar();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                back1 = true;
                                Console.Clear() ;
                                break;
                            default:
                                Console.WriteLine("Xato,qaytadan urinib ko`ring");
                                break;
                        }
                    }
                    break;
                case "2":
                    bool back2 = false;
                    while (!back2)
                    {
                        Console.WriteLine("    Admin    ");
                        Console.WriteLine("1. Add Mentor");
                        Console.WriteLine("2. Update Mentor");
                        Console.WriteLine("3. Delete Mentor");
                        Console.WriteLine("4. List Mentorlar");
                        Console.WriteLine("5. Back");
                        Console.Write("Tanlang: ");
                        var choice1 = Console.ReadLine();

                        switch (choice1)
                        {
                            case "1":
                                Console.Write("Mentor ismini kiriting: ");
                                var tName = Console.ReadLine();
                                center.AddMentor(tName);
                                Console.WriteLine("Muvaffaqqiyatli qo`shildi");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                Console.Write("Mentor Id sini kiriting: ");
                                var tId = int.Parse(Console.ReadLine());
                                Console.Write("Mentor ismini kiriting: ");
                                var newTName = Console.ReadLine();
                                center.UpdateMentor(tId, newTName);
                                Console.Clear();
                                break;
                            case "3":
                                Console.Write("Mentor Id sini kiriting: ");
                                var deleteTId = int.Parse(Console.ReadLine());
                                center.DeleteMentor(deleteTId);
                                Console.Clear();
                                break;
                            case "4":
                                center.ListMentorlar();
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "5":
                                back2 = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Xato,qaytadan urinib ko`ring");
                                break;
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("    Admin    ");
                    center.ListArizalar();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.WriteLine("    Admin    ");
                    center.About();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    back = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Xato, qaytadan urinib ko`ring");
                    break;
            }

        }
    }

    static void Student(Center center)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("      Student     ");
            Console.WriteLine("1. Kurslar");
            Console.WriteLine("2. Mentorlar");
            Console.WriteLine("3. Arizalar");
            Console.WriteLine("4. Markaz haqida");
            Console.WriteLine("5. Back");
            Console.Write("Tanlang: ");
            var choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("      Student     ");
                    center.ListKurslar();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("      Student     ");
                    center.ListMentorlar();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("      Student     ");
                    bool back1 = false;
                    while (!back1)
                    {
                        Console.WriteLine("1. Add Ariza");
                        Console.WriteLine("2. Update Ariza");
                        Console.WriteLine("3. Delete Ariza");
                        Console.WriteLine("4. Back");
                        Console.Write("Tanlang: ");
                        var choice1 = Console.ReadLine();

                        switch (choice1)
                        {
                            case "1":
                                Console.Write("Ismingizni kiriting: ");
                                var tName = Console.ReadLine();
                                Console.Write("Familiyangizni kiriting: ");
                                var fName = Console.ReadLine();
                                Console.Write("Telefon raqamingizni kiriting: ");
                                var rName = Console.ReadLine();
                                center.AddAriza(tName, fName, rName);
                                Console.WriteLine("Muvaffaqqiyatli qo`shildi");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                Console.Write(" Id kiriting: ");
                                var tId = int.Parse(Console.ReadLine());
                                Console.Write("Ism kiriting: ");
                                var newTName = Console.ReadLine();
                                center.UpdateAriza(tId, newTName);
                                Console.Clear();
                                break;
                            case "3":
                                Console.Write("Id kiriting: ");
                                var deleteTId = int.Parse(Console.ReadLine());
                                center.DeleteAriza(deleteTId);
                                Console.Clear();
                                break;
                            case "4":
                                back1 = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Xato,qaytadan urinib ko`ring");
                                break;
                        }


                    }
                    break;
                case "4":
                    Console.WriteLine("      Student     ");
                    center.About();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    back = true;
                    Console.Clear() ;
                    break;
                default:
                    Console.WriteLine("Xato, qaytadan urinib ko`ring");
                    break;

            }
        }
    }
}

