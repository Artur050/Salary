namespace Domain.Persons
{
    /// <summary>
    /// Класс, для создания экземпляра компании
    /// </summary>
    public class CompanyInstance
    {
        public string Name { get;}

        public Dictionary<Guid, Person> Persons { get; private set; }

        public CompanyInstance(string name)
        {
            Name = name ?? throw new ArgumentNullException("Название компании не может быть пустым");
            Persons = new Dictionary<Guid, Person>();
        }

        public void AddEmployeeWithSubordinates(Person persons)
        {
            if(persons == null) 
            {
                throw new ArgumentNullException(nameof(persons));
            }

            Persons.Add(persons.Id, persons);
            if((persons as LeadingPersonality) != null)
            {
                (persons as LeadingPersonality).GetSubordinates().ForEach(p => AddEmployeeWithSubordinates(p));
            }
        }
    }
}
