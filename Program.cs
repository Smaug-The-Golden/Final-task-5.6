/* Для команды курса. Это моя первая программа в жизни и очень старался писать её, чтобы удовлетворить поставленным требованиям. 
 * Задание к итоговому проекту написано двояко.... Я так и не понял сколько нужно создавать методов в классе Programm. В самом 
 * задании просят 5 методов,а в подсказке №7 просят всего 3 метода. Проверка корректного ввода по заданию - это числа типа int>0,
 * при этом в подсказке №7 идет намек на проверку имени пользователя на числовое значение, т.е. еще один метод проверки? В задании
 * просите вызывать методы из метода Main, но в подсказке №7 проверка на корректность ввода должна производиться из метода возвращающего
 * кортеж, т.е. из метода собирающего данные пользователя.
 * 
*/
using System;

namespace Final_task_5._6
{
    class Program
    {
        static (string name, string surname, int age, bool HasPet, int pet_numb, string[] pet_names, string[] favcolors) CollectInfo()  
        // Метод, заполняющий данные с клавиатуры, и возвращающий кортеж
        {
            (string name, string surname, int age, bool HasPet, int pet_numb, string[] pet_names, string[] favcolors) User;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tНачало работы программы:\n");
            Console.ResetColor();

            // Опрос имени, фамилии и возраста пользователя

            Console.Write("\nВведите имя: ");
            User.name = Console.ReadLine();

            Console.Write("\nВведите фамилию: ");
            User.surname = Console.ReadLine();

            Console.Write("\nВвведите свой возраст цифрами: ");
            User.age = IsValid();

            //Определение наличия питомца, количества питомцев и заполнение массива кличек

            Console.WriteLine("\nЕсть ли у вас питомец?\nЕсли есть, введите цифру 1. Если нет, нажмите любую другую клавишу: ");
            var HasPet = int.Parse(Console.ReadLine());

            if (HasPet.Equals(1)) // Тут будет ошибка, если пользователь нажмет сразу две и более клавиши. Исправлю в дальнейшем.
            {
                User.HasPet = true;
                Console.WriteLine("\nСколько у вас питомцев (введите цифру): ");
                User.pet_numb = IsValid();
                User.pet_names = new string[User.pet_numb];
                for (int i = 0; i < User.pet_names.Length; i++)
                {
                    Console.Write($"\nВведите кличку {i + 1}-го питомца: \t ");
                    User.pet_names[i] = Console.ReadLine();
                }
            }
            else
            {
                User.HasPet = false;
                User.pet_numb = 0;
                User.pet_names = new string[User.pet_numb];
            }

            //Определение количества любимых цветов

            Console.Write("\nСколько у вас любимых цветов (введите цифру): ");
            var favcolours_count = IsValid();
            User.favcolors = new string[favcolours_count];
            for (int i = 0; i < User.favcolors.Length; i++)
            {
                Console.Write($"\nВведите свой любимый цвет №{i + 1} : \t ");
                User.favcolors[i] = Console.ReadLine();
            }

            return User;
        }


        static int IsValid() // Метод принимает значение, введенное с клавиатуры, и заставляет пользователя ввести целое положительное число
        {
            int correct_value;
            do
            {
                if (int.TryParse(Console.ReadLine(), out correct_value) && correct_value >= 1 && correct_value <= int.MaxValue)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели некорректное значение.\nПожалуйста, введите целое положительное число: ");
                Console.ResetColor();
            }
            while (true);
            return correct_value;
        }
        

        static void Main(string[] args) //Метод принимает кортеж из CollectInfo() и выводит данные на экран
        {
            var (name, surname, age, HasPet, pet_numb, pet_names, favcolors) = CollectInfo();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tВывод результатов:\n");
            Console.ResetColor();

            //Вывод имени, фамилии и возраста пользователя

            Console.WriteLine("Вас зовут: {0} " + "{1}", name, surname);
            Console.WriteLine("Ваш возраст: {0} лет", age);

            // Вывод наличия питомца, количества питомцев и их кличек

            if (HasPet == true)
            {
                Console.WriteLine($"Количество ваших питомцев: {pet_numb}");
                Console.Write("Клички ваших питомцев: ");
                Console.WriteLine(string.Join(", ", pet_names));
            }
            else
            {
                Console.WriteLine("У вас нет питомца.");
            }

            //Вывод любимых цветов по их количеству

            Console.Write("Ваши любимые цвета: ");
            Console.WriteLine(string.Join(", ",favcolors));
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tКонец программы.\n");
            Console.ResetColor();
            Console.ReadLine();
        }


    }
}
