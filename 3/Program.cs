using System;
using System.Collections.Generic;
using System.Linq;
//Задание 1. «Студенты / Аспиранты»
//Описать иерархию классов «Студенты/Аспиранты».
//Характеристики студента: имя, факультет, год поступления, рейтинг.
//Характеристики аспиранта: имя, факультет, год поступления, руководитель, код специальности. Методы классов разработать самостоятельно.


namespace _3
{
    abstract class Person
    {
        public string Name { get; }
        public string Fac { get; }
        public int Year { get; }

        public Person(string name, string fac, int year)
        {
            Name = name;
            Fac = fac;
            Year = year;
        }

        public void Show()
        {
            Console.Write("Name: " + Name + "\tFac: " + Fac + "\tYear: " + Year);
        }
    }

    class Student : Person
    {
        public int Rating { get; }

        public Student(string name, string fac, int year, int rating) : base(name, fac, year)
        {
            Rating = rating;
        }

        public new void Show()
        {
            base.Show();
            Console.Write("\tRating: " + Rating);
            Console.WriteLine();
        }
    }

    class Aspirant : Person
    {
        public string Leader { get; }
        public string Code { get; }

        public Aspirant(string name, string fac, int year, string leader, string code) : base(name, fac, year)
        {
            Leader = leader;
            Code = code;
        }

        public new void Show()
        {
            base.Show();
            Console.Write("\tLeader: " + Leader + "\tCode: " + Code);
            Console.WriteLine();
        }
    }
    //1. Создать массив (или коллекцию) объектов класса «Студент».
    //2. Создать массив (или коллекцию) объектов класса «Аспирант».
    //3. Получить полную информацию о трех студентах 1 курса экономического факультета с самым высоким рейтингом.
    //4. Выяснить, кто из аспирантов специальности "Специальность" 05.13.11 завершает обучение в текущем году.
    //5. Получить полную информацию обо всех студентах и аспирантах.
    class Program
    {
        static void Main(string[] args)
        {
            #region Инициализация
            List<Student> students = new List<Student>();
            students.Add(new Student("Кармазин", "Мехмат", 2019, 9));
            students.Add(new Student("Пономарев", "Эконом", 2019, 10));
            students.Add(new Student("Иванов", "Эконом", 2019, 7));
            students.Add(new Student("Петров", "Эконом", 2019, 6));
            students.Add(new Student("Козлов", "Эконом", 2019, 8));
            students.Add(new Student("Кузовов", "Мехмат", 2019, 12));
            List<Aspirant> aspirants = new List<Aspirant>();
            aspirants.Add(new Aspirant("Пушкин", "Эконом", 2019, "Лидер", "05.13.11"));
            aspirants.Add(new Aspirant("Пономарев", "Мехмат", 2020, "Лидер", "100"));
            aspirants.Add(new Aspirant("Иванов", "Мехмат", 2020, "Лидер", "200"));

            List<Person> people = new List<Person>(students);
            people.AddRange(aspirants);
            #endregion

            #region Студенты эконома топ 3 лучших(LINQ)
            Console.WriteLine("Студенты эконома топ 3 лучших(LINQ): ");
            students.Where(x => x.Fac == "Эконом").OrderBy(x => x.Rating).Take(3).ToList().ForEach(x => x.Show());

            Console.WriteLine();
            #endregion

            #region Студенты эконома топ 3 лучших (foreach):
            /*Console.WriteLine("Студенты эконома топ 3 лучших: ");
            students.Sort((x, y) => x.Rating.CompareTo(y.Rating));
            int count = 0;
            foreach (Student student in students)
            {
                if (student.Fac == "Эконом")
                {
                    count++;
                    student.Show();
                }
                if (count >= 3)
                {
                    break;
                }
            }
            Console.WriteLine();*/
            #endregion

            #region Аспиранты завершающие обучение(LINQ)
            Console.WriteLine("Аспиранты завершающие обучение(LINQ): ");
            aspirants.Where(x => x.Year <= 2019 && x.Code == "05.13.11").ToList().ForEach(x => x.Show());

            Console.WriteLine();
            #endregion

            #region Аспиранты завершающие обучение (foreach):
            /*Console.WriteLine("Аспиранты завершающие обучение: ");
            foreach (Aspirant aspirant in aspirants)
            {
                if (aspirant.Year <= 2019 && aspirant.Code == "05.13.11")
                {
                    aspirant.Show();
                }
            }
            Console.WriteLine();*/
            #endregion

            #region Вывод инфы обо всех (LINQ)
            Console.WriteLine("Вывод инфы обо всех (LINQ): ");
            people.OfType<Student>().ToList().ForEach(x => x.Show());
            people.OfType<Aspirant>().ToList().ForEach(x => x.Show());

            Console.WriteLine();
            #endregion

            #region Вывод инфы обо всех (foreach):
            /*Console.WriteLine("Вывод инфы обо всех: ");
            foreach (Person person in people)
            {
                if (person is Student)
                {
                    ((Student)person).Show();

                }
                if (person is Aspirant)
                {
                    (person as Aspirant).Show();
                }
            }*/
            #endregion

            Console.ReadLine();
        }
    }
}
