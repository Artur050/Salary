using System;
using System.Collections.Generic;

namespace Domain.Persons
{
    /// <summary>
    /// Дополнительный класс для тех, у кого есть подчиненные
    /// </summary>
    public class LeadingPersonality : Person
    {
        private List<Person> subordinatesList = new List<Person>();

        public LeadingPersonality(string name, decimal basicRate, DateTime dateStartWorking)
            : base(name, basicRate, dateStartWorking)
        {
        }

        public void AddSubordinate(Person subordinate)
        {
            subordinatesList.Add(subordinate);
        }

        public List<Person> GetSubordinates()
        {
            return subordinatesList;
        }

        protected decimal GetSubordinatesSalary(DateTime salaryDate)
        {
            var sumSalary = 0m;
            subordinatesList.ForEach(per => sumSalary += per.CalculateActualSalary(salaryDate));

            return sumSalary;
        }
    }
}
