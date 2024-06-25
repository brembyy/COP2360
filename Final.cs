using System;
using System.Collections.Generic;

namespace ContractorApp
{
    public class Contractor
    {
        public string ContractorName { get; set; }
        public int ContractorNumber { get; set; }
        public DateTime ContractorStartDate { get; set; }

        public Contractor(string name, int number, DateTime startDate)
        {
            ContractorName = name;
            ContractorNumber = number;
            ContractorStartDate = startDate;
        }

        public override string ToString()
        {
            return $"Contractor: {ContractorName}, Number: {ContractorNumber}, Start Date: {ContractorStartDate.ToShortDateString()}";
        }
    }

    public class Subcontractor : Contractor
    {
        public int Shift { get; set; }
        public double HourlyPayRate { get; set; }

        public Subcontractor(string name, int number, DateTime startDate, int shift, double hourlyPayRate)
            : base(name, number, startDate)
        {
            Shift = shift;
            HourlyPayRate = hourlyPayRate;
        }

        public override string ToString()
        {
            return base.ToString() + $", Shift: {Shift}, Hourly Pay Rate: {HourlyPayRate}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Contractor> contractors = new List<Contractor>();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Contractor Management System");
                Console.WriteLine("1. Add Contractor");
                Console.WriteLine("2. Add Subcontractor");
                Console.WriteLine("3. View All Contractors");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddContractor(contractors);
                        break;
                    case "2":
                        AddSubcontractor(contractors);
                        break;
                    case "3":
                        ViewContractors(contractors);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddContractor(List<Contractor> contractors)
        {
            Console.Clear();
            Console.WriteLine("Add Contractor");
            Console.Write("Enter Contractor Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Contractor Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter Contractor Start Date (YYYY-MM-DD): ");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.Write("Invalid date. Please enter again (YYYY-MM-DD): ");
            }
            contractors.Add(new Contractor(name, number, startDate));
            Console.WriteLine("Contractor added successfully. Press any key to continue.");
            Console.ReadKey();
        }

        static void AddSubcontractor(List<Contractor> contractors)
        {
            Console.Clear();
            Console.WriteLine("Add Subcontractor");
            Console.Write("Enter Subcontractor Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Subcontractor Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter Subcontractor Start Date (YYYY-MM-DD): ");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.Write("Invalid date. Please enter again (YYYY-MM-DD): ");
            }
            Console.Write("Enter Shift (1 for day, 2 for night): ");
            int shift;
            while (!int.TryParse(Console.ReadLine(), out shift))
            {
                Console.Write("Invalid shift. Please enter an integer value: ");
            }
            Console.Write("Enter Hourly Pay Rate: ");
            double payRate;
            while (!double.TryParse(Console.ReadLine(), out payRate))
            {
                Console.Write("Invalid pay rate. Please enter a numeric value: ");
            }
            contractors.Add(new Subcontractor(name, number, startDate, shift, payRate));
            Console.WriteLine("Subcontractor added successfully. Press any key to continue.");
            Console.ReadKey();
        }

        static void ViewContractors(List<Contractor> contractors)
        {
            Console.Clear();
            Console.WriteLine("All Contractors and Subcontractors:");
            foreach (var contractor in contractors)
            {
                Console.WriteLine(contractor);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}