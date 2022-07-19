using System;
using System.Collections.Generic;
using mlt.api.Models;

namespace mlt.api.Repositories;

interface ICustomerRepository
{
    void Create(Customer customer);
    Customer GetById(Guid id);
    List<Customer> GetAll();
    void Update(Customer customer);
    void Delete(Guid id);
}