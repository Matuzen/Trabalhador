using System;
using System.Collections.Generic;
using Trabalhador.Entities.Enums;

namespace Trabalhador.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } // Composição de objetos - Associação de objetos - Dentro da classe Worker declarar o objeto Department
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // Composição para vários e instanciada pra garantir que não seja nula
        public Worker()
        {
        }
        public Worker(string name, WorkerLevel level, double baseSalary, Department department) // Associação para muitos (Contracts) nao será incluída no construtor
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addContract(HourContract contract)
        {
            Contracts.Add(contract); // Acessar a lista de contratos e adicionar o contrato que chegou como parâmentro de entrada 
        }

        public void removeContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int mounth)
        {
            double sum = BaseSalary; // Mesmo que o trabalhador não tenha nenhum contrato, ele tem um salário base
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == mounth)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }

    }
}
