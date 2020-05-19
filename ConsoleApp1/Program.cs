using System;
using System.Collections.Generic;
using System.Globalization;
using Work.Entiety;
using Work.Entiety.Enum;

namespace Work
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string nameDepart = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.Write("How many constracts to this worker? ");

            Department department = new Department(nameDepart);
            Worker worker = new Worker(name, level, baseSalary, department);
            int n = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write($"Enter {i} contracts data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double perHours = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = Int32.Parse(Console.ReadLine());

                HourContract hourContract = new HourContract(date, perHours, hours);
                worker.AddContracts(hourContract);
            }

            Console.WriteLine("Enter month and yaer to calculate income (MM/YYYY): ");
            String dateWrite = Console.ReadLine();
            int mm = Int32.Parse(dateWrite.Substring(0, 2));
            int yyyy = Int32.Parse(dateWrite.Substring(3));


            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.department.Name);
            Console.WriteLine($"Income for {dateWrite} : " + worker.Income(mm, yyyy).ToString("F2",CultureInfo.InvariantCulture));



        }
    }
}
