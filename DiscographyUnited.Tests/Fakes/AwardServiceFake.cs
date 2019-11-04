using System;
using System.Collections.Generic;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;

namespace DiscographyUnited.Tests.Fakes
{
    public class AwardServiceFake : IAwardService
    {
        private readonly List<AwardModel> _awardModels;

        public AwardServiceFake()
        {
            _awardModels = new List<AwardModel>
            {
                new AwardModel
                {
                    Id = 1,
                    Name = "Entertainer of the Year",
                    Description =
                        "The Academy of Country Music Award for Entertainer of the Year is the biggest competitive category presented at the Academy of Country Music Awards",
                    ReceivedDate = new DateTime(2017, 1, 1)
                },
                new AwardModel
                {
                    Id = 2,
                    Name = "Male Vocalist of the Year",
                    Description = "Top male vocalist of the year",
                    ReceivedDate = new DateTime(2018, 1, 1)
                },
                new AwardModel
                {
                    Id = 3,
                    Name = "Female Vocalist of the Year",
                    Description = "Top female vocalist of the year",
                    ReceivedDate = new DateTime(2019, 1, 1)
                }
            };
        }

        public void Create(AwardModel entity)
        {
            _awardModels.Add(entity);
        }

        public void Delete(AwardModel entity)
        {
            _awardModels.Remove(entity);
        }

        public IEnumerable<AwardModel> FindAll()
        {
            return _awardModels;
        }

        public AwardModel FindById(long id)
        {
            return _awardModels.Find(a => a.Id == id);
        }

        public void Save()
        {
        }

        public void Update(AwardModel entity)
        {
            var index = _awardModels.FindIndex(a => a.Id == entity.Id);
            if (index > 0)
            {
                _awardModels[index] = entity;
            }
        }
    }
}