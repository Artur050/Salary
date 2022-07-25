namespace Domain.Persons
{
    /// <summary>
    /// Класс базовый класс для всех сотрудников
    /// </summary>
    public class Person
    {
        public decimal BasicRate;
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateStartWorking { get; set; }

        public PersonRole personRole { get; set; }
        public decimal Salary { get; set; }

        /// <summary>
        /// Метод для подсчета актуальной(фактической) заработной платы
        /// </summary>
        /// <param name="salaryDate"></param>
        /// <returns></returns>
        public virtual decimal CalculateActualSalary(DateTime? salaryDate = null)
        {
            return BasicRate;
        }
        
        public Person()
        {
            Id = Guid.NewGuid();
            Name = "";
            BasicRate = 0;
            DateStartWorking = DateTime.Today;
        }

        /// <summary>
        /// Конструктор, для установления значений
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="basicRate"></param>
        /// <param name="dateStartWorking"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Person(string name, decimal basicRate,  DateTime dateStartWorking)
        {
            if (basicRate <= 0)
            {
                throw new ArgumentException("Зарплата не может быть меньше или равной 0", nameof(basicRate));
            }

            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException("Имя не может быть пустым", nameof(name));
            BasicRate = basicRate;
            DateStartWorking = dateStartWorking;            
        }
        /// <summary>
        /// Метод для расчета количества рабочих лет
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="salaryDate"></param>
        /// <returns></returns>
        private int CalculateNumberOfWorkingYears(DateTime startDate, DateTime? salaryDate = null)
        {
            if (!salaryDate.HasValue)
            {
                salaryDate = DateTime.Now;
            }
            if(startDate == DateTime.MinValue)
            {
                return 0;
            }

            var begining = new DateTime(1, 1, 1);
            var span = (DateTime)salaryDate - startDate;

            if(span.Milliseconds < 0)
            {
                return 0;
            }

            int result = (begining + span).Year - 1;

            return result > 0 ? result : 0;
        }
        /// <summary>
        /// Метод для расчета зп с учетом максимального процента
        /// </summary>
        /// <param name="additionalYear"></param>
        /// <param name="maximumComplement"></param>
        /// <param name="salaryDate"></param>
        /// <returns></returns>
        protected decimal CalculateSalaryPercentage(decimal additionalYear, decimal maximumComplement, DateTime? salaryDate = null)
        {
            if (!salaryDate.HasValue)
            {
                salaryDate = DateTime.Now;
            }
            decimal percent = decimal.Multiply(CalculateNumberOfWorkingYears(DateStartWorking, salaryDate), additionalYear);

            return percent <= maximumComplement ? percent + 1 : maximumComplement + 1;
        }
    }
}
