﻿using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Repositories;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Course.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        private readonly IValidator<Entities.Course> _validator;

        public CourseService(
            ICourseRepository courseRepository,
            IValidator<Entities.Course> validator)
        {
            _courseRepository = courseRepository;
            _validator = validator;
        }

        public async Task DeleteAsync(string id) =>
            await _courseRepository.DeleteAsync(id);

        public async Task<IList<Entities.Course>> GetAllAsync() =>
            await _courseRepository.FindAllAsync();

        public async Task<Entities.Course> GetByIdAsync(string id) =>
            await _courseRepository.FindByIdAsync(id);

        public async Task<Entities.Course> InsertAsync(Entities.Course entity)
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

            await _courseRepository.InsertAsync(entity);

            return entity;
        }

        public async Task<Entities.Course> UpdateAsync(Entities.Course entity)
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

            await _courseRepository.UpdateAsync(entity);

            return entity;
        }
    }
}
