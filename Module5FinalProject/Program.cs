using System;

namespace Module5FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = EnterUser();
            OutPut(user);
        }
        //---------------------------------------------------------------------
        // 1. Данные пользователя
        static (string name, string lasname, int age, string[] petsnames, int favcnum, string[] favcolors) EnterUser()
        {
            (string name, string lastname, int age, string[] petsnames, int favcnum, string[] favcolors) user;

            Console.WriteLine("Введите имя:");
            user.name = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");
            user.lastname = Console.ReadLine();

            Console.WriteLine("Введите возраст целым числом:");
            int intage = TypeNumber();
            user.age = intage;

            Console.WriteLine("Имеется ли у вас питомец/питомцы? (Напечатайте \"да\",\nесли есть; если питомца/питомцев нет, печатайте, что пожелаете)");
            string havingpet = Console.ReadLine();
            if (havingpet == "да")
            {
                Console.WriteLine("Напишите количество имеющихся питомцев:");
                int numberofpets = TypeNumber();
                var pets = PetNamespace(numberofpets);
                user.petsnames = pets;
            }
            else
            {
                user.petsnames = new string[1] { "У вас нет питомцев" };
            }

            Console.WriteLine("Введите количество любимых цветов:");
            int intfavc = TypeNumber();
            user.favcnum = intfavc;
            user.favcolors = FavColors(intfavc);

            foreach(var color in user.favcolors)
            {
                switch (color)
                {
                    case "красный":
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case "желтый":
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case "зеленый":
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case "голубой":
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case "синий":
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        break;
                    case "фиолетовый":
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case "розовый":
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        break;
                    case "серый":
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case "белый":
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Ваш любимый цвет - цвет морской волны...ну или вы что-то не то ввели");
                        break;
                }
                Console.WriteLine(color);

            }

            return user;
        }
        //---------------------------------------------------------------------
        // 2. Метод вывода кортежа, который мне так и не удалось связать с EnterUser(), массивы не отображаются.
        static void OutPut((string name, string lastname, int age, string[] petsnames, int favcnum, string[] favcolors) user)
        {
            Console.WriteLine("Ваши данные:");
            Console.WriteLine($"Ваше имя {user.name}");
            Console.WriteLine($"Ваша фамилия {user.lastname}");
            Console.WriteLine($"Ваш возраст {user.age}");
            Console.WriteLine("Ваши питомцы:");
            foreach(var pet in user.petsnames)
            {
                Console.WriteLine(pet);
            }
            Console.WriteLine("Ваши любимые цвета:");
            foreach(var favc in user.favcolors)
            {
                Console.WriteLine(favc);
            }

        }
        //---------------------------------------------------------------------
        // 3. Проверка на правильность введенных чисел
        static int TypeNumber()
        {
            int corrNumber;
            string number;
            do
            {
                number = Console.ReadLine();
                if (int.TryParse(number, out int number1))
                {
                    if (number1 > 0)
                    {
                        corrNumber = number1;
                        break;
                    }
                }
                Console.WriteLine("Введите число заново. Избегайте ввода отрицательных, дробных чисел,\nнуля и букв/символов.");
            } while (true);
            return corrNumber;
        }
        //---------------------------------------------------------------------
        // 4. Клички питомцев
        static string[] PetNamespace(int num)
        {
            var arr = new string[num];
            
            for(int i = 0; i < num; i++)
            {
                Console.WriteLine($"Введите кличку питомца номер {i + 1}");
                arr[i] = Console.ReadLine();
            }
            
            return arr;
        }
        //---------------------------------------------------------------------
        // 5. Любимые цвета
        static string[] FavColors(int numf)
        {            
            var favc = new string[numf];
            for(int i = 0; i < favc.Length; i++)
            {
                Console.WriteLine($"Введите любимый цвет номер {i + 1} с маленькой буквы на русском");
                favc[i] = Console.ReadLine();
            }
            
            return favc;
        }
        
    }
}
