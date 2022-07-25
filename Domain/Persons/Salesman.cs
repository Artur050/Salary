using System;

namespace Domain.Persons
{
    public class Salesman : Manager
    {
        // Надбавка за год работы
        public const decimal bonusForYearForSLM = 0.01m;

        // Надбавка за подчиненных
        public const decimal bonusForSubordinateForSLM = 0.003m;

        // Суммарная надбавка за стаж работы 
        public const decimal bonusForExperienceSLM = 0.35m;

        public Salesman(string name, decimal basicRate, DateTime dateStartWorking) : base(name, basicRate, dateStartWorking)
        {
        }

        public override decimal CalculateActualSalary(DateTime? salaryDate = null)
        {
            if (!salaryDate.HasValue)
            {
                salaryDate = DateTime.Now;
            }

            var result = BasicRate * CalculateSalaryPercentage(bonusForYearForSLM, bonusForExperienceSLM, salaryDate);

            result += GetSubordinatesSalary(salaryDate.Value) * bonusForSubordinateForSLM;

            return result; 
        }
    }
}
