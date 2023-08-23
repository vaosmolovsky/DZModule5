namespace DZModule5
{
    public class Program
    {
        public static void Main()
        {
            ShowUserData(PersonData());
            Console.WriteLine("\nДля продолжения нажмите люблю клавишу...");
            Console.ReadKey();
        }

        static void ShowUserData((string Name, string Surname, int Age, bool HasPet, string[] PetName, string[] FavColors) Person)
        {
            Console.WriteLine("\n\t\t Данные о пользователе\n");
            Console.WriteLine($"Имя: {Person.Name} \nФамилия: {Person.Surname} \nВозраст: {Person.Age}");

            Console.Write("Питомцы: ");
            for (int i = 0; i < Person.PetName.Length; i++)
            {
                if (i == Person.PetName.Length - 1)
                {
                    Console.Write($"{Person.PetName[i]}.");
                }
                else
                {
                    Console.Write($"{Person.PetName[i]}, ");
                }
            }
            Console.WriteLine();

            Console.Write("Любимые цвета: ");
            for (int i = 0; i < Person.FavColors.Length; i++)
            {
                if (i == Person.FavColors.Length - 1)
                {
                    Console.Write($"{Person.FavColors[i]}.");
                }
                else
                {
                    Console.Write($"{Person.FavColors[i]}, ");
                }
            }
            Console.WriteLine();
        }

        // Анкета
        static (string Name, string Surname, int Age, bool HasPet, string[] PetName, string[] FavColors) PersonData()
        {
            Console.WriteLine("Заполните пожалуйста анкету\n");

            (string Name, string Surname, int Age, bool HasPet, string[] PetName, string[] FavColors) Person;
                    
            Console.Write("Введите ваше имя: ");
            Person.Name = Console.ReadLine();
            string editedName;
            Editing("Имя", Person.Name, out editedName);
                       
            Console.Write("Введите вашу фамилию: ");
            Person.Surname = Console.ReadLine();
            string editedSurname;
            Editing("Фамилия", Person.Surname, out editedSurname);
                        
            Console.Write("Введите ваш возраст: ");
            string Age = Console.ReadLine();
            string editingAge;
            Editing("Возраст", Age, out editingAge);
            Person.Age = Int32.Parse(editingAge);
                       
            Console.Write("У вас есть домашние животные? ");
            if (Console.ReadLine() == "Да")
            {
                Person.HasPet = true;
                Console.Write("Сколько у вас питомцев? ");
                int petsCount = int.Parse(Console.ReadLine());
                Person.PetName = new string[petsCount];
                Console.WriteLine();
                Person.PetName = UserPets(petsCount);
                Console.WriteLine();
            }

            else
            {
                Person.PetName = new string[0];
                Person.HasPet = false;
            }
                     
            Console.Write("Сколько у вас любимых цветов? ");
            int favColorsCount = int.Parse(Console.ReadLine());
            if (favColorsCount > 0)
            {
                Person.FavColors = new string[favColorsCount];
                Console.WriteLine();
                Person.FavColors = UserFavColors(favColorsCount);
                Console.WriteLine();
            }

            else
            {
                Person.FavColors = new string[0];
            }

            return Person;

            // Метод "Клички питомцев"
            static string[] UserPets(int count)
            {
                string[] petName = new string[count];

                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Введите кличку {i + 1} питомца: ");
                    petName[i] = Console.ReadLine();
                }

                return petName;
            }

            // Метод "Любимые цвета"
            static string[] UserFavColors(int count)
            {
                string[] favColors = new string[count];

                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Введите любимый цвет #{i + 1}: ");
                    favColors[i] = Console.ReadLine();
                }

                return favColors;
            }

            // Метод проверки

            static string Editing(string data, string enter, out string edit)
            {
                if (data == "Имя" || data == "Фамилия")
                {
                    foreach (var sign in enter)
                    {
                        bool signCheck = Char.IsNumber(sign);
                        while (signCheck == true)
                        {
                            Console.Write($"{data} не может содержать цифры!\nВведите еще раз: ");
                            enter = Console.ReadLine();
                            foreach (var signSecond in enter)
                            {
                                signCheck = Char.IsNumber(signSecond);
                            }
                            Console.WriteLine();
                        }
                    }
                    edit = enter;
                    return edit;
                }
                else
                {
                    bool signCheck = int.TryParse(enter, out int number);

                    while (signCheck == false || (signCheck == true && number <= 0))
                    {
                        Console.Write($"{data} должен состоять только из цифр и быть больше нуля!\nВведите еще раз: ");
                        enter = Console.ReadLine();
                        signCheck = int.TryParse(enter, out number);
                        Console.WriteLine();
                    }
                    edit = enter;
                    return edit;
                }
            }
        }
    }
}