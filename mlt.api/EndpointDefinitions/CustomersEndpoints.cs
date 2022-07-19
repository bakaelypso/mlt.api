using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using mlt.api.Models;
using mlt.api.Repositories;

namespace mlt.api.EndpointDefinitions;

[DisplayName("Your New Tag")]
internal static class CustomersEndpoints
{
    public static void GetEndpoints(WebApplication app)
    {
        app.MapGet("/customers", GetAllCustomers);
        app.MapGet("/customers/{id:guid}", GetCustomerById);
        app.MapPost("/customers/", CreateCustomer);
        app.MapPut("/customers/{id:guid}", UpdateCustomer);
        app.MapDelete("/customers/{id:guid}", DeleteCustomer);
    }

    private static IList<Customer> GetAllCustomers(ICustomerRepository repo) => repo.GetAll();

    private static IResult GetCustomerById(ICustomerRepository repo, Guid id) => repo.GetById(id) is { } customer ? Results.Ok(customer) : Results.NotFound();

    private static IResult CreateCustomer(ICustomerRepository repo, Customer customer)
    {
        repo.Create(customer);
        return Results.Created($"/customers/{customer.Id}", customer);
    }

    private static IResult UpdateCustomer(ICustomerRepository repo, Guid id, Customer updatedCustomer)
    {
        if (repo.GetById(id) is null)
            return Results.NotFound();

        repo.Update(updatedCustomer);
        return Results.Ok(updatedCustomer);
    }

    private static IResult DeleteCustomer(ICustomerRepository repo, Guid id)
    {
        repo.Delete(id);
        return Results.Ok();
    }
}