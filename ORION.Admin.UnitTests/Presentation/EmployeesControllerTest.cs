using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ORION.Admin.Commands;
using ORION.Admin.Controllers;
using ORION.Admin.Models.Employees;
using ORION.Admin.UnitTests.Util;
using ORION.DataAccess.Models;
using Xunit;

namespace ORION.Admin.UnitTests.Presentation
{
    public class EmployeeControllerTest
    {
        public EmployeeControllerTest()
        {
            _SystemUnderTest = null;
            _IEmployeesListQuery = null;
        }
        private EmployeesController? _SystemUnderTest;
        public EmployeesController SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new EmployeesController();
                }
                return _SystemUnderTest;
            }
        }
        private MockIEmployeesListQuery? _IEmployeesListQuery;
        public MockIEmployeesListQuery IEmployeesListQuery
        {
            get
            {
                if (_IEmployeesListQuery == null)
                {
                    _IEmployeesListQuery = new MockIEmployeesListQuery();
                }
                return _IEmployeesListQuery;
            }
        }

        private MockIEmployeeRepository _IEmployeeRepository;
        public MockIEmployeeRepository IEmployeeRepository
        {
            get
            {
                if (_IEmployeeRepository == null)
                {
                    _IEmployeeRepository = new MockIEmployeeRepository();
                }

                return _IEmployeeRepository;
            }

        }

        [Fact]
        public async Task EmployeeController_Index_ModelIsNotNull()
        {
           //arrange
           var result = await SystemUnderTest.Index(IEmployeesListQuery);

           // act
           var vm = UnitTestUtility.GetModel<EmployeesListViewModel>(result);
           var viewResult = Assert.IsType<ViewResult>(result);

           // assert
           Assert.Equal(vm, viewResult.Model);
        }

        
        [Fact]
        public async Task EmployeeController_IndexModel_IsValidAndInitialized()
        {
            //  arrange
            var resultSet = await SystemUnderTest.Index(IEmployeesListQuery);
            var model = UnitTestUtility.GetModelIAction<EmployeesListViewModel>(resultSet);

            // act
            var actual = true;
            var result = SystemUnderTest.ModelState.IsValid;

            // assert
            Assert.Equal(result, actual);
        }

        [Fact]
        public async Task EmployeeController_CreatePost_SuccessTest()
        {
            // arrange
            var commandDependency =
                new Mock<ICommandHandler<CreateEmployeeCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<CreateEmployeeCommand>()))
                .Returns(Task.CompletedTask);
            var fakeEmployee = new Employee();
            var vm = new EmployeeFullEditViewModel(fakeEmployee)
            {
                Id = 1,
                BirthDate = new DateTime(1988/08/05),
                EmployeeTerritoryId=1,
                Extension="27",
                FirstName ="Khotso",
                HireDate = new DateTime(2022/07/19),
                LastName = "Mokhethi",
                HomePhone ="0812302044",
                Notes="I am a Developer",
                Title ="Mr",
                TitleOfCourtesy ="Developer",
                ReportsTo =1,
                PhotoPath ="../../Default.html",
                Photo = null,
                City="Meadowlands",
                Address = "2450 B",
                Country ="South Africa",
                OrderId =1,
                PostalCode="1852",
                Region ="Greater Johannesburg"
            };

            // act
            var result = await SystemUnderTest.Create(vm, commandDependency.Object);
            commandDependency.Verify(m => m.HandleAsync(
                It.IsAny<CreateEmployeeCommand>()),
                Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);

            // assert
            Assert.Equal(nameof(EmployeesController.Index), redirectResult.ActionName);
        }
  

       

        [Fact]
        public async Task EmployeeController_EditPost_SuccessTest()
        {
            // arrange
            var commandDependency = new Mock<ICommandHandler<UpdateEmployeeCommand>>();
            commandDependency.Setup(p => p.HandleAsync(It.IsAny<UpdateEmployeeCommand>()))
                            .Returns(Task.CompletedTask);

            var fakeEmployee = new Employee();
            var viewModel = new EmployeeFullEditViewModel(fakeEmployee)
            {
                 Id = 1,
                BirthDate = new DateTime(1988/08/05),
                EmployeeTerritoryId=1,
                Extension="27",
                FirstName ="Khotso",
                HireDate = new DateTime(2022/07/19),
                LastName = "Mokhethi",
                HomePhone ="0812302044",
                Notes="I am a Developer",
                Title ="Mr",
                TitleOfCourtesy ="Developer",
                ReportsTo =1,
                PhotoPath ="../../Default.html",
                Photo = null,
                City="Meadowlands",
                Address = "2450 B",
                Country ="South Africa",
                OrderId =1,
                PostalCode="1852",
                Region ="Greater Johannesburg"
            };

            // act
            var result = await SystemUnderTest.Edit(viewModel, commandDependency.Object);
            
            commandDependency.Verify(m=>m.HandleAsync(It.IsAny<UpdateEmployeeCommand>()),
            Times.Once);
                            
            // assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(EmployeesController.Index),redirectResult.ActionName);
        }

        [Fact]
        public async Task EmployeeController_CreatePost_FailedTest()
        {
            // arrange
            SystemUnderTest.ModelState
                .AddModelError("Name", "fake error");
            var fakeEmployee = new Employee();

            var vm = new EmployeeFullEditViewModel(fakeEmployee);

            // act
            var result = await SystemUnderTest.Create(vm, null);
            var viewResult = Assert.IsType<ViewResult>(result);

            // assert
            Assert.Equal(vm, viewResult.Model);
        }

        [Fact]
        public async Task EmployeeController_DeletePost_SuccessTest()
        {
            // arrange
            var commandDependency =
                new Mock<ICommandHandler<DeleteEmployeeCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<DeleteEmployeeCommand>()))
                .Returns(Task.CompletedTask);
            var fakeEmployee = new Employee();

            var vm = new EmployeeFullEditViewModel(fakeEmployee)
            {
                 Id = 1,
                BirthDate = new DateTime(1988/08/05),
                EmployeeTerritoryId=1,
                Extension="27",
                FirstName ="Khotso",
                HireDate = new DateTime(2022/07/19),
                LastName = "Mokhethi",
                HomePhone ="0812302044",
                Notes="I am a Developer",
                Title ="Mr",
                TitleOfCourtesy ="Developer",
                ReportsTo =1,
                PhotoPath ="../../Default.html",
                Photo = null,
                City="Meadowlands",
                Address = "2450 B",
                Country ="South Africa",
                OrderId =1,
                PostalCode="1852",
                Region ="Greater Johannesburg"
            };

            // act
            var result = await SystemUnderTest.Delete(vm.Id,
                commandDependency.Object);
            commandDependency.Verify(m => m.HandleAsync(
            It.IsAny<DeleteEmployeeCommand>()),
            Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);

            // assert
            Assert.Equal(nameof(EmployeesController.Index),
                redirectResult.ActionName);
            Assert.Null(redirectResult.ControllerName);
        }

        [Fact]
        public async Task EmployeeController_DeletePost_ValidationFailedTest()
        {
            // arrange
            var controller = new EmployeesController();
            controller.ModelState
                .AddModelError("Name", "fake error");
                var fakeEmployee = new Employee();
            var vm = new EmployeeFullEditViewModel(fakeEmployee);
            var result = await controller.Edit(vm, null);
            
            // act
            var viewResult = Assert.IsType<ViewResult>(result);
            
            // assert
            Assert.Equal(vm, viewResult.Model);
        }
    }
}