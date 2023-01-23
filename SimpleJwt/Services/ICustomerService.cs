using SimpleJwt.Entities;

namespace SimpleJwt.Services;

public interface ICustomerService
{
    Task<Customer> Create(Customer customer);
}