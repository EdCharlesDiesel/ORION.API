using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ORION.Admin.Commands;
using ORION.Admin.Controllers;
using ORION.Admin.Models.Customers;
using ORION.Admin.UnitTests.Util;
using ORION.DataAccess.Models;
using Xunit;

namespace ORION.Admin.UnitTests.Presentation
{
    public class CustomerControllerTest
    {
        public CustomerControllerTest()
        {
            _SystemUnderTest = null;
            _ICustomersListQuery = null;
        }
        private CustomersController? _SystemUnderTest;
        public CustomersController SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new CustomersController();
                }
                return _SystemUnderTest;
            }
        }
        private MockICustomersListQuery? _ICustomersListQuery;
        public MockICustomersListQuery ICustomersListQuery
        {
            get
            {
                if (_ICustomersListQuery == null)
                {
                    _ICustomersListQuery = new MockICustomersListQuery();
                }
                return _ICustomersListQuery;
            }
        }

        private MockICustomerRepository _ICustomerRepository;
        public MockICustomerRepository ICustomerRepository
        {
            get
            {
                if (_ICustomerRepository == null)
                {
                    _ICustomerRepository = new MockICustomerRepository();
                }

                return _ICustomerRepository;
            }

        }

        [Fact]
        public async Task CustomerController_Index_ModelIsNotNull()
        {
           //arrange
           var result = await SystemUnderTest.Index(ICustomersListQuery);

           // act
           var vm = UnitTestUtility.GetModel<CustomersListViewModel>(result);
           var viewResult = Assert.IsType<ViewResult>(result);

           // assert
           Assert.Equal(vm, viewResult.Model);
        }

        
        [Fact]
        public async Task CustomerController_IndexModel_IsValidAndInitialized()
        {
            //  arrange
            var resultSet = await SystemUnderTest.Index(ICustomersListQuery);
            var model = UnitTestUtility.GetModelIAction<CustomersListViewModel>(resultSet);

            // act
            var actual = true;
            var result = SystemUnderTest.ModelState.IsValid;

            // assert
            Assert.Equal(result, actual);
        }

        [Fact]
        public async Task CustomerController_CreatePost_SuccessTest()
        {
            // arrange
            var commandDependency =
                new Mock<ICommandHandler<CreateCustomerCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<CreateCustomerCommand>()))
                .Returns(Task.CompletedTask);
            var fakeCustomer = new Customer();
            var vm = new CustomerFullEditViewModel(fakeCustomer)
            {
                Id = 1,
                CompanyName = "StarPeace",
                ContactName = "Mr Khotso Mokhethi",
                ContactTitle= "Developer",
                CustomerDemographicId =1,
                City="Meadowlands",
                Address = "2450 B",
                Country ="South Africa",
                Fax ="2781230204",
                OrderId =1,
                Phone ="6208122022",
                PostalCode="1852",
                Region ="Greater Johannesburg"
            };

            // act
            var result = await SystemUnderTest.Create(vm, commandDependency.Object);
            commandDependency.Verify(m => m.HandleAsync(
                It.IsAny<CreateCustomerCommand>()),
                Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);

            // assert
            Assert.Equal(nameof(CustomersController.Index), redirectResult.ActionName);
        }
  

       

        [Fact]
        public async Task CustomerController_EditPost_SuccessTest()
        {
            // arrange
            var commandDependency = new Mock<ICommandHandler<UpdateCustomerCommand>>();
            commandDependency.Setup(p => p.HandleAsync(It.IsAny<UpdateCustomerCommand>()))
                            .Returns(Task.CompletedTask);

            var fakeCustomer = new Customer();
            var viewModel = new CustomerFullEditViewModel(fakeCustomer)
            {
                Id = 1,
                CompanyName = "StarPeace",
                ContactName = "Mr Khotso Mokhethi",
                ContactTitle= "Developer",
                CustomerDemographicId =1,
                City="Meadowlands",
                Address = "2450 B",
                Country ="South Africa",
                Fax ="2781230204",
                OrderId =1,
                Phone ="6208122022",
                PostalCode="1852",
                Region ="Greater Johannesburg"
            };

            // act
            var result = await SystemUnderTest.Edit(viewModel, commandDependency.Object);
            
            commandDependency.Verify(m=>m.HandleAsync(It.IsAny<UpdateCustomerCommand>()),
            Times.Once);
                            
            // assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(CustomersController.Index),redirectResult.ActionName);
        }

        [Fact]
        public async Task CustomerController_CreatePost_FailedTest()
        {
            // arrange
            SystemUnderTest.ModelState
                .AddModelError("Name", "fake error");
            var fakeCustomer = new Customer();

            var vm = new CustomerFullEditViewModel(fakeCustomer);

            // act
            var result = await SystemUnderTest.Create(vm, null);
            var viewResult = Assert.IsType<ViewResult>(result);

            // assert
            Assert.Equal(vm, viewResult.Model);
        }

        [Fact]
        public async Task CustomerController_DeletePost_SuccessTest()
        {
            // arrange
            var commandDependency =
                new Mock<ICommandHandler<DeleteCustomerCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<DeleteCustomerCommand>()))
                .Returns(Task.CompletedTask);
            var fakeCustomer = new Customer();

            var vm = new CustomerFullEditViewModel(fakeCustomer)
            {
                Id = 1,
                CompanyName = "StarPeace",
                ContactName = "Mr Khotso Mokhethi",
                ContactTitle= "Developer",
                CustomerDemographicId =1,
                City="Meadowlands",
                Address = "2450 B",
                Country ="South Africa",
                Fax ="2781230204",
                OrderId =1,
                Phone ="6208122022",
                PostalCode="1852",
                Region ="Greater Johannesburg"
            };

            // act
            var result = await SystemUnderTest.Delete(vm.Id,
                commandDependency.Object);
            commandDependency.Verify(m => m.HandleAsync(
            It.IsAny<DeleteCustomerCommand>()),
            Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);

            // assert
            Assert.Equal(nameof(CustomersController.Index),
                redirectResult.ActionName);
            Assert.Null(redirectResult.ControllerName);
        }

        [Fact]
        public async Task CustomerController_DeletePost_ValidationFailedTest()
        {
            // arrange
            var controller = new CustomersController();
            controller.ModelState
                .AddModelError("Name", "fake error");
                var fakeCustomer = new Customer();
            var vm = new CustomerFullEditViewModel(fakeCustomer);
            var result = await controller.Edit(vm, null);
            
            // act
            var viewResult = Assert.IsType<ViewResult>(result);
            
            // assert
            Assert.Equal(vm, viewResult.Model);
        }
    }
}