﻿using System;

namespace Module5FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            EnterUser();
        }
        //---------------------------------------------------------------------
        // Данные пользователя
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

            Console.WriteLine("Имеется ли у вас питомец/питомцы? (Напечатайте \"Да\",\nесли есть; если питомца/питомцев нет, печатайте, что пожелаете)");
            string havingpet = Console.ReadLine();
            if (havingpet == "Да")
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

            Console.WriteLine($"Итак, ваши данные:\nВас зовут {user.name}, ваша фамилия {user.lastname}, вам {user.age} лет.");
            if(havingpet == "Да")
            {
                Console.WriteLine("Ваши питомцы:");
                foreach(var pet in user.petsnames)
                {
                    Console.Write(pet + " ");
                }
            }
            else
            {
                Console.WriteLine("У вас нет питомцев");
            }
            Console.WriteLine("Ваши любимые цвета:");
            foreach(var color in user.favcolors)
            {
                switch (color)
                {
                    case "красный":
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case "желтый":
                        Console.BackgroundColor = ConsoleColor.Yellow;
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
        // Метод вывода кортежа, который мне так и не удалось связать с EnterUser(), массивы не отображаются.
        static void OutPut()
        {
            var user = EnterUser();
            Console.WriteLine(user);
        }
        //---------------------------------------------------------------------
        // Проверка на правильность введенных чисел
        static bool CheckNumber(string number, out int corrnumber)
        {
            if(int.TryParse(number, out int intnum))
            {
                if(intnum > 0)
                {
                    corrnumber = intnum;
                    return true;
                }
            }
            {
                corrnumber = 0;
                return false;
            }
        }
        //---------------------------------------------------------------------
        /*Еще один метод для проверки. Дело в том, что я не понял по подсказкам,
        * как сделать проверку, у меня получалось так, что приходится бесконечно вводить числа,
        * а при ошибке компиляция останавливается. В общем, добавление еще одного метода это решило,
        * надеюсь, что так тоже можно.
        */
        static int TypeNumber()
        {
            int intnumber;
            string number;
            do
            {
                number = Console.ReadLine();
                if(CheckNumber(number, out intnumber))
                {
                    break;
                }
                else if (CheckNumber(number, out intnumber) == false)
                {
                    Console.WriteLine("Введите число заново. Избегайте ввода отрицательных, дробных чисел,\nнуля и букв/символов.");
                    intnumber = TypeNumber();
                    break;
                }
                else
                {
                    break;
                }
            } while (CheckNumber(number, out intnumber));
            return intnumber;
        }
        //---------------------------------------------------------------------
        // Наличие питомцев и их количетсво
        static string HasPet()
        {
            Console.WriteLine("Имеется ли у вас питомец/питомцы? (Напечатайте \"Да\",\nесли есть; если питомца/питомцев нет, печатайте, что пожелаете)");
            string pet = Console.ReadLine();
            
            if(pet == "Да")
            {
                Console.WriteLine("Напишите количество имеющихся питомцев:");
                int numberofpets = TypeNumber();
                var pets = PetNamespace(numberofpets);
                
                if(numberofpets == 1)  // Если питомец один
                {
                    Console.Write($"У вас {numberofpets} питомец с кличкой:");
                    Console.Write($"{pets}");
                }
                
                else if(numberofpets > 1 & numberofpets < 5)  // Если питомцев 2, 3 или 4
                {
                    Console.WriteLine($"У вас {numberofpets} питомца с кличками:");
                    foreach(var petname in pets)
                    {
                        Console.Write(petname + " ");
                    }
                }
                
                else  // Если питомцев 5 и больше (21-24, 31-34,... - маловероятные кейсы, да и лень это расписывать :-)
                {
                    Console.WriteLine($"У вас {numberofpets} питомцев с кличками:");
                    foreach(var petname in pets)
                    {
                        Console.Write(petname + " ");
                    }
                }
            }
            
            else
            {
                Console.WriteLine("Окей, у вас нет питомцев");
            }
            
            return pet;
        }
        //---------------------------------------------------------------------
        // Клички питомцев
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
        // Количество любимых цветов
        static string[] FavColors(int numf)
        {            
            var favc = new string[numf];
            for(int i = 0; i < favc.Length; i++)
            {
                Console.WriteLine($"Введите любимый цвет номер {i + 1}");
                favc[i] = Console.ReadLine();
            }
            
            return favc;
        }
        
    }
}
