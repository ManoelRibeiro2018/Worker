using System;
using System.Collections.Generic;
using System.Text;
using Work.Entiety.Enum;
using Work.Entiety;

namespace Work.Entiety
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            this.department = department;
        }

        public void AddContracts(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContracts(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int month, int year)
        {
            double sum = BaseSalary;
            foreach(HourContract hourContract in Contracts)
            {
                if(hourContract.Date.Year == year && hourContract.Date.Month == month)
                {
                    sum += hourContract.TotalValue();
                }
            }
            return sum;

        }
    }
}
