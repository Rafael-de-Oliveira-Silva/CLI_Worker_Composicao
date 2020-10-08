using System;
using System.Collections.Generic;
using System.Text;
using CLI_Worker_Composicao.Entities.Enums;

namespace CLI_Worker_Composicao.Entities
{
    class Worker
    {
        public string Name { get; set; }

        public WorkerLevel Level { get; set; }

        public double BaseSalary { get; set; }

        public Department DepartamentWorker;

        private List<HourContract> LstContracts;

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department departamentWorker)
        {
            this.Name = name;
            this.Level = level;
            this.BaseSalary = baseSalary;
            this.DepartamentWorker = departamentWorker;
            this.LstContracts = new List<HourContract>();
        }

        public void AddContract(HourContract hc)
        {
            LstContracts.Add(hc);
        }

        public void RemoveContract(HourContract hc)
        {
            LstContracts.Remove(hc);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in LstContracts) {
                if (contract.DateContract.Year == year && contract.DateContract.Month == month) {
                    sum += contract.TotalValue();
                } 
            }
            return sum;
        }

    }
}
