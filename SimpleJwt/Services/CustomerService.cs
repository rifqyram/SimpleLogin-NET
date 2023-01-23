using SimpleJwt.Entities;
using SimpleJwt.Repositories;

namespace SimpleJwt.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repository;
    private readonly IPersistence _persistence;

    public CustomerService(IRepository<Customer> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
    }

    public async Task<Customer> Create(Customer request)
    {
        var customer = await _repository.SaveAsync(request);
        await _persistence.SaveChangesAsync();
        return customer;
    }
}