using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.MessageBroker;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.Repositories;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.Services;
using AzureNaPratica.Serverless.Domain.Base.Interfaces.HttpService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Student.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        private readonly IStudentMessageBroker _studentMessageBroker;

        private readonly ILuckyNumber _luckyNumber;

        private readonly IValidator<Entities.Student> _validator;

        public StudentService(
            IStudentRepository courseRepository,
            IStudentMessageBroker studentMessageBroker,
            ILuckyNumber luckyNumber,
            IValidator<Entities.Student> validator)
        {
            _studentRepository = courseRepository;
            _studentMessageBroker = studentMessageBroker;
            _luckyNumber = luckyNumber;
            _validator = validator;
        }

        public async Task DeleteAsync(string id) =>
            await _studentRepository.DeleteAsync(id);

        public async Task<IList<Entities.Student>> GetAllAsync() =>
            await _studentRepository.FindAllAsync();

        public async Task<Entities.Student> GetByIdAsync(string id) =>
            await _studentRepository.FindByIdAsync(id);

        public async Task<Entities.Student> InsertAsync(Entities.Student entity)
        {
            var validated = await _validator.ValidateAsync(entity, opt =>
            {
                opt.IncludeRuleSets("new");
            });

            entity.ValidationResult = validated;

            if (!entity.ValidationResult.IsValid)
            {
                return entity;
            }

            int number = await _luckyNumber.GetLuckyNumber();

            entity.SetLucyNumber(number);

            entity.SetEventType(Base.Entity.EventType.create);

            await _studentRepository.InsertAsync(entity);

            await _studentMessageBroker.SendMessage(entity);

            return entity;
        }

        public async Task<Entities.Student> UpdateAsync(Entities.Student entity)
        {
            var validated = await _validator.ValidateAsync(entity, opt =>
            {
                opt.IncludeRuleSets("update");
            });

            entity.ValidationResult = validated;

            if (!entity.ValidationResult.IsValid)
            {
                return entity;
            }

            await _studentRepository.UpdateAsync(entity);

            return entity;
        }
    }
}
