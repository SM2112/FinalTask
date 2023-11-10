using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string answerUser;
            string pathToBinFile; 
            
            Console.WriteLine("Уважаемый пользователь!");
            Console.WriteLine("Вы находитесь в программе по работе с бинарными файлами.");
            Console.WriteLine("Данная программа разбирает бинарный файл на текстовые файлы по ключу.");
            Console.WriteLine("Ключом является номер группы.");
            Console.WriteLine();
            Console.Write("Вы хотите продолжить? Введите ДА или нажмите любую клавишу  для  завершения программы: ");
            answerUser = Console.ReadLine();

            if (answerUser == "ДА")
            {
                Console.Write("Укажите путь к файлу: ");
                pathToBinFile = Console.ReadLine();

                if (File.Exists(pathToBinFile))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    using (var streamInfo = new FileStream(pathToBinFile, FileMode.OpenOrCreate))
                    {
                        var Students = (Student[])binaryFormatter.Deserialize(streamInfo);
                                                
                        foreach (var student in Students)
                        {
                            string pathFileTxt = "C:\\Users\\USER\\Desktop\\" + student.Group + ".txt";
                            
                            using (StreamWriter sw = new StreamWriter(pathFileTxt, true))
                            {
                                sw.Write(student.Name + ", ");
                                sw.WriteLine(student.DateOfBirth);
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Алгоритм отработал! Информация о студентах лежит в текстовых файлах на рабочем столе в разрезе групп!");
                }
                else
                {
                    Console.WriteLine("По указанному пути нужного файла не обнаружено! Программа будет закрыта!");
                }
            }
            else
            {
                Console.WriteLine("Вы отказались от дальнейших действий! Программа будет закрыта!");
            }
        }
    }
}