using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mlt.api.Models;
using mlt.api.Repositories;

namespace mlt.api.EndpointDefinitions;

public static class WebApplicationExtension
{
    public static WebApplication DefineCustomersEndpoints(this WebApplication app)
    {
        app.MapGet("/customers", GetAllCustomers);
        app.MapGet("/customers/{id:guid}", GetCustomerById);
        app.MapPost("/customers/", CreateCustomer);
        app.MapPut("/customers/{id:guid}", UpdateCustomer);
        app.MapDelete("/customers/{id:guid}", DeleteCustomer);

        return app;
    }

    

    internal IList<Customer> GetAllCustomers(ICustomerRepository repo)
        => repo.GetAll();

    internal IResult GetCustomerById(ICustomerRepository repo, Guid id)
        => repo.GetById(id) is { } customer ? Results.Ok(customer) : Results.NotFound();

    internal IResult CreateCustomer(ICustomerRepository repo, Customer customer)
    {
        repo.Create(customer);
        return Results.Created($"/customers/{customer.Id}", customer);
    }

    internal IResult UpdateCustomer(ICustomerRepository repo, Guid id, Customer updatedCustomer)
    {
        if (repo.GetById(id) is null)
            return Results.NotFound();
        
        repo.Update(updatedCustomer);
        return Results.Ok(updatedCustomer);
    }

    internal IResult DeleteCustomer(ICustomerRepository repo, Guid id)
    {
        repo.Delete(id);
        return Results.Ok();
    }
}