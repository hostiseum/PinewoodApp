
using Castle.Core.Configuration;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using PinewoodApp.CustomerAPI.Data;
using PinewoodApp.CustomerAPI.Models;
using PinewoodApp.CustomerAPI.Repositories;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace PinewoodApp.CustomerAPI.Tests
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public async void GetCustomerByIdAsync_ReturnsCustomer_Success()
        {
            var configFromApi = new Dictionary<string, string>
            {
                {"Database","Customer" }
            };

            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configFromApi).Build();
            
            //Arrange
            //create In Memory Database
            var options = new DbContextOptionsBuilder<AppDBContext>()
            .UseInMemoryDatabase(databaseName: "Customer")
            .Options;

            var customerData = new List<Customer> {
               new Customer {
                    Id = 1,
                    FirstName= "Fake FirstName",
                    LastName = "Fake LastName",
                    Email="fake@email.com",
                    Phone="19283745",
                    City = "Fake City",
                    PostalCode = "Fake Code",
                    Country = "Fake country"
                },
                new Customer {
                     Id = 2,
                    FirstName = "Fake FirstName2",
                    LastName = "Fake LastName2",
                    Email = "fake@email.com2",
                    Phone = "192837452",
                    City = "Fake City2",
                    PostalCode = "Fake Code2",
                    Country = "Fake country2"
                }
                };

            using (var context= new AppDBContext(configuration))
            {
                context.Customers.AddRange(customerData);

                context.SaveChanges();
            }

            //ACT
            using (var context = new AppDBContext(configuration))
            {

                CustomerRepository customerRepository = new CustomerRepository(context);
                var result = await customerRepository.GetCustomerByIdAsync(1);
                
                //Assert
                result.Should().NotBeNull();
                Assert.IsType<Customer>(result);

                result.Id.Should().Be(customerData.Where(c=>c.Id ==1).First().Id);
                result.FirstName.Should().Be(customerData.Where(c => c.Id == 1).First().FirstName);
                result.LastName.Should().Be(customerData.Where(c => c.Id == 1).First().LastName);
                result.Email.Should().Be(customerData.Where(c => c.Id == 1).First().Email);
                result.Phone.Should().Be(customerData.Where(c => c.Id == 1).First().Phone);
                result.City.Should().Be(customerData.Where(c => c.Id == 1).First().City);
                result.PostalCode.Should().Be(customerData.Where(c => c.Id == 1).First().PostalCode);
                result.Country.Should().Be(customerData.Where(c => c.Id == 1).First().Country);
            }
        }

        [Fact]
        public async void GetCustomerListAsync_ReturnsCustomers_Success()
        {
            var configFromApi = new Dictionary<string, string>
            {
                {"Database","Customer" }
            };

            var configuration = new ConfigurationBuilder().AddInMemoryCollection(configFromApi).Build();

            //Arrange
            //create In Memory Database
            var options = new DbContextOptionsBuilder<AppDBContext>()
            .UseInMemoryDatabase(databaseName: "Customer")
            .Options;

            var customerData = new List<Customer> {
               new Customer {
                    Id = 1,
                    FirstName= "Fake FirstName",
                    LastName = "Fake LastName",
                    Email="fake@email.com",
                    Phone="19283745",
                    City = "Fake City",
                    PostalCode = "Fake Code",
                    Country = "Fake country"
                },
                new Customer {
                     Id = 2,
                    FirstName = "Fake FirstName2",
                    LastName = "Fake LastName2",
                    Email = "fake@email.com2",
                    Phone = "192837452",
                    City = "Fake City2",
                    PostalCode = "Fake Code2",
                    Country = "Fake country2"
                }
                };

            using (var context = new AppDBContext(configuration))
            {
                context.Customers.AddRange(customerData);

                context.SaveChanges();
            }

            //ACT
            using (var context = new AppDBContext(configuration))
            {

                CustomerRepository customerRepository = new CustomerRepository(context);
                var result = await customerRepository.GetCustomerListAsync();

                //Assert
                result.Should().NotBeNull();
                Assert.IsType<List<Customer>>(result);
                result.Should().HaveCount(2);
              
            }
        }
    }
}