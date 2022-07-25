using Domain.Interfaces;
using Domain.Response;
using Domain.Persons;
using Domain.Interfaces.Service;
using Repository;

namespace Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<BaseResponse> CreateUser(string name, int personrole, decimal salary, DateTime dateStartWorking)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var person = await _personRepository.Get(name);
                if (person == null)
                {
                    person = new Person 
                    { Name = name, personRole = (PersonRole)personrole, 
                    Salary = salary, DateStartWorking = dateStartWorking };

                    await _personRepository.Insert(person);

                    baseResponse.Data = person;
                    baseResponse.Message = $"Пользователь {person.Name} добавился";
                    return baseResponse;
                }
                baseResponse.Message = $"Пользователь {person.Name} уже есть";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<BaseResponse> GetUser(string name)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var person = await _personRepository.Get(name);
                if (person != null)
                {
                    baseResponse.Data = person;
                    return baseResponse;
                }

                baseResponse.Message = "Пользователь не найден";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<BaseResponse> Delete(string name)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var person = await _personRepository.Get(name);
                if (person != null)
                {
                    await _personRepository.Delete(person);

                    baseResponse.Message = "Пользователь удалён";
                    baseResponse.Data = person;
                    return baseResponse;
                }

                baseResponse.Message = "Пользователь не найден";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<BaseResponse> Update(string name, string newName)
        {
            var baseResponse = new BaseResponse();
            try
            {
                var person = await _personRepository.Get(name);
                if (person != null)
                {
                    person.Name = newName;
                    await _personRepository.Update(person);

                    baseResponse.Data = person;
                    baseResponse.Message = $"Имя обновилось с {name} на {newName}";
                }

                baseResponse.Message = "Пользователь не найден";
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse()
                {
                    Message = ex.Message
                };
            }
        }
    }
    }