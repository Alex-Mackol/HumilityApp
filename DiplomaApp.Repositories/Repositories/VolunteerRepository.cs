﻿using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Data.Data;

namespace DiplomaApp.Repositories.Repositories
{
    public class VolunteerRepository : IRepository<Volunteer>
    {
        private readonly ApplicationContext context;
        public VolunteerRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<Volunteer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetEntityNames()
        {
            throw new NotImplementedException();
        }

        public bool IsEntityExist(Volunteer entity)
        {
            throw new NotImplementedException();
        }

        public Volunteer Read(ushort id)
        {
            throw new NotImplementedException();
        }

        public void Create(Volunteer item)
        {
            context.Volunteers.Add(item);
        }
     
        public void Update(Volunteer item)
        {
            throw new NotImplementedException();
        }
        public void Delete(ushort id)
        {
            throw new NotImplementedException();
        }
    }
}
