using System;

namespace Domain.Persons
{
    public class Employee : Person
    {
        // Надбавка за год работы
        public const decimal bonusForYearForEMP = 0.03m;

        // Суммарная надбавка за стаж работы 
        public const decimal bonusForExperienceEMP = 0.3m;

        public Employee(string name, decimal basicRate, DateTime dateStartWorking) : base(name, basicRate, dateStartWorking)
        {
        }

        /// <summary>
        /// Расчет фактической заработной платы
        /// </summary>
        /// <param name="salaryDate"></param>
        /// <returns></returns>
        public override decimal CalculateActualSalary(DateTime? salaryDate = null)
        {
            if (!salaryDate.HasValue)
            {
                salaryDate = DateTime.Now;
            }

            return BasicRate * CalculateSalaryPercentage(bonusForYearForEMP, bonusForExperienceEMP, salaryDate);       
        }
    }
}
