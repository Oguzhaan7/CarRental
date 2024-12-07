﻿using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Interfaces.Persistance
{
    public interface ICarRepository : IRepository<Car>
    {
    }
}
