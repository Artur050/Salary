using System;

namespace Domain.Persons
{
    public class Manager : LeadingPersonality
    {
        // Надбавка за год работы
        public const decimal bonusForYearForMAN = 0.05m;

        // Надбавка за подчиненных
        public const decimal bonusForSubordinateForMAN = 0.005m;

        // Суммарная надбавка за стаж работы 
        public const decimal bonusForExperienceMAN = 0.4m;

        public Manager(string name, decimal basicRate, DateTime dateStartWorking) : base(name, basicRate, dateStartWorking)
        {      
        }

        public override decimal CalculateActualSalary(DateTime? salaryDate = null)
        {
            if (!salaryDate.HasValue)
            {
                salaryDate = DateTime.Now;
            }

            var result = BasicRate * CalculateSalaryPercentage(bonusForYearForMAN, bonusForExperienceMAN, salaryDate);

            result += GetSubordinatesSalary(salaryDate.Value) * bonusForSubordinateForMAN;
            return result;
        }
    }
}
