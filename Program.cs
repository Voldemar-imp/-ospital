using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Нospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Нospital нospital = new Нospital();
            bool isWork = true;
            const char CommandShowSortByName = '1';
            const char CommandShowSortByAge = '2';
            const char CommandShowByDisease = '3';
            const char CommandExit = '4';

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Здавствуйте, доктор, в травмпункте после гололеда наплыв пациентов");
                Console.WriteLine($"{CommandShowSortByName}) показать пациентов в алфавитном порядке \n{CommandShowSortByAge}) показать пациентов по возрасту " +
                    $"\n{CommandShowByDisease}) показать пациентов с указанной травмой \n{CommandExit}) выход");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();

                switch (key.KeyChar)
                {
                    case CommandShowSortByName:
                        нospital.ShowSortByName();
                        break;
                    case CommandShowSortByAge:
                        нospital.ShowSortByAge();
                        break;
                    case CommandShowByDisease:
                        нospital.ShowByDisease();
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                }

                Console.ReadKey(true);
            }
        }
    }

    class Нospital
    {
        private List <Patient> _patients = new List<Patient>();

        public Нospital()
        {
            _patients.Add(new Patient("Ковалев Фёдор Романович", 50, "Перелом руки"));
            _patients.Add(new Patient("Куликова Елизавета Артёмовна", 23, "Вывих плеча"));
            _patients.Add(new Patient("Наумов Елисей Михайлович", 35, "Сотрясение мозга"));
            _patients.Add(new Patient("Лаврентьева Амира Петровна", 18, "Вывих голени"));
            _patients.Add(new Patient("Хомяков Евгений Русланович", 22, "Перелом руки"));
            _patients.Add(new Patient("Родионов Сергей Александрович", 34, "Множественные ушибы"));
            _patients.Add(new Patient("Логинова София Мирославовна", 70, "Перелом ноги"));
            _patients.Add(new Patient("Смирнов Николай Даниилович", 44, "Перелом руки"));
            _patients.Add(new Patient("Зорина Софья Марковна", 38, "Сотрясение мозга"));
            _patients.Add(new Patient("Фролов Вячеслав Никитич", 57, "Сотрясение мозга"));
        }

        public void ShowSortByName()
        {
            var sortedPatients = _patients.OrderBy(patient => patient.Name).ToList();
            ShowList(sortedPatients);
        }

        public void ShowSortByAge()
        {
            var sortedPatients = _patients.OrderBy(patient => patient.Age).ToList();
            ShowList(sortedPatients);
        }

        public void ShowByDisease()
        {
            string userInput = GetDiseaseName();
            var sortedPatients = _patients.Where(patient => patient.Disease.ToLower() == userInput.ToLower()).OrderBy(patient => patient.Name).ToList();

            if (sortedPatients.Any() == false)
            {
                Console.WriteLine("Нет пациентов с указанной травмой.");
            }
            else
            {
                ShowList(sortedPatients);
            }
        }

        private string GetDiseaseName()
        {
            Console.WriteLine("Введите название травмы:");
            return Console.ReadLine();
        } 

        private void ShowList(List<Patient> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Name}. Возраст: {patient.Age}. Травма: {patient.Disease}");
            }
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public string Disease { get; private set; }
        public int Age { get; private set; }

        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }
    }
}
