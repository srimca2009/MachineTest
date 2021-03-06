﻿using MachineTest.Model;
using MachineTest.Service.Common;

namespace MachineTest.Service
{
    public interface ICustomerService : IEntityService<Customer>
    {
        Customer GetById(int id);
        int Delete(int Id);
    }
}
