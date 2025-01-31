using System;
using System.IO;
using System.Reflection;

namespace ExternalAssemblyReflector
{
    class Program
    {
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Типы в сборке *****");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine("Type: {0}", t);
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("***** Просмотр внешней сборки *****");
            string asmName = "";
            Assembly asm = null;

            do
            {
                Console.WriteLine("\nВведите сборку для оценки");
                Console.Write("или Q для выхода: ");
                // Получение имени сборки.
                asmName = Console.ReadLine();
                // Пользователь хочет выйти?
                if (asmName.ToUpper() == "Q")
                {
                    break;
                }
                // Проверка загрузки сборки.
                try
                {
                    asm = Assembly.LoadFrom(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Извините, не удалось найти сборку.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            } while (true);
        }
    }
}