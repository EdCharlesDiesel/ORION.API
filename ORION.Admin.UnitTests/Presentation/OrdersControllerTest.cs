using System;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ORION.Admin.Commands;
using ORION.Admin.Controllers;
using ORION.Admin.Models.Orders;
using ORION.Admin.UnitTests.Util;
using ORION.DataAccess.Models;
using Xunit;

namespace ORION.Admin.UnitTests.Presentation
{
    public class OrdersControllerTest
    {
        public OrdersControllerTest()
        {
            _SystemUnderTest = null;
            _IOrdersListQuery = null;
        }
        private OrdersController? _SystemUnderTest;
        public OrdersController SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new OrdersController();
                }
                return _SystemUnderTest;
            }
        }
        private MockIOrdersListQuery? _IOrdersListQuery;
        public MockIOrdersListQuery IOrdersListQuery
        {
            get
            {
                if (_IOrdersListQuery == null)
                {
                    _IOrdersListQuery = new MockIOrdersListQuery();
                }
                return _IOrdersListQuery;
            }
        }

        private MockIOrderRepository _IOrderRepository;
        public MockIOrderRepository IOrderRepository
        {
            get
            {
                if (_IOrderRepository == null)
                {
                    _IOrderRepository = new MockIOrderRepository();
                }

                return _IOrderRepository;
            }
        }

        [Fact]
        public async Task OrderController_Index_ModelIsNotNull()
        {
            //arrange
            var result = await SystemUnderTest.Index(IOrdersListQuery);

            // act
            var vm = UnitTestUtility.GetModel<OrdersListViewModel>(result);
            var viewResult = Assert.IsType<ViewResult>(result);

            // assert
            Assert.Equal(vm, viewResult.Model);
        }

        [Fact]
        public async Task OrderController_IndexModel_IsValidAndInitialized()
        {
            //  arrange
            var resultSet = await SystemUnderTest.Index(IOrdersListQuery);
            var model = UnitTestUtility.GetModelIAction<OrdersListViewModel>(resultSet);

            // act
            var actual = true;
            var result = SystemUnderTest.ModelState.IsValid;

            // assert
            Assert.Equal(result, actual);
        }

        [Fact]
        public async Task OrderController_CreatePost_SuccessTest()
        {
            // arrange
            var commandDependency =
                new Mock<ICommandHandler<CreateOrderCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<CreateOrderCommand>()))
                .Returns(Task.CompletedTask);
            var fakeOrder = new Order();
            var vm = new OrderFullEditViewModel(fakeOrder)
            {
                Id = 1,
                CustomerId = 1,
                EmployeeId = 1,
                Freight = 336.26M,
                OrderDate = new DateTime(2022 / 06 / 27),
                RequiredDate = new DateTime(2022 / 06 / 27),
                ShipAddress = "258 City Place",
                ShipCity = "Pretoria",
                ShipCountry = "Botswana",
                ShipName = "The Flying Dutchman",
                ShippedDate = new DateTime(2022 / 06 / 27),
                ShipPostalCode = "1852",
                ShipRegion = "Ekuruleni",
                ShipVia = 2
            };

            // act
            var result = await SystemUnderTest.Create(vm, commandDependency.Object);
            commandDependency.Verify(m => m.HandleAsync(
                It.IsAny<CreateOrderCommand>()),
                Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);

            // assert
            Assert.Equal(nameof(OrdersController.Index), redirectResult.ActionName);
        }

        [Fact]
        public async Task OrderController_EditPost_SuccessTest()
        {
            // arrange
            var commandDependency = new Mock<ICommandHandler<UpdateOrderCommand>>();
            commandDependency.Setup(p => p.HandleAsync(It.IsAny<UpdateOrderCommand>()))
                            .Returns(Task.CompletedTask);
            var fakeOrder = new Order();
            var vm = new OrderFullEditViewModel(fakeOrder)
            {
                Id = 1,
                CustomerId = 1,
                EmployeeId = 1,
                Freight = 336.26M,
                OrderDate = new DateTime(2022 / 06 / 27),
                RequiredDate = new DateTime(2022 / 06 / 27),
                ShipAddress = "258 City Place",
                ShipCity = "Pretoria",
                ShipCountry = "Botswana",
                ShipName = "The Flying Dutchman",
                ShippedDate = new DateTime(2022 / 06 / 27),
                ShipPostalCode = "1852",
                ShipRegion = "Ekuruleni",
                ShipVia = 2
            };

            // act
            var result = await SystemUnderTest.Edit(vm, commandDependency.Object);

            commandDependency.Verify(m => m.HandleAsync(It.IsAny<UpdateOrderCommand>()),
            Times.Once);

            // assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(OrdersController.Index), redirectResult.ActionName);
        }

        [Fact]
        public async Task OrderController_CreatePost_FailedTest()
        {
            // arrange
            SystemUnderTest.ModelState
                .AddModelError("Name", "fake error");
            var fakeOrder = new Order();
            var vm = new OrderFullEditViewModel(fakeOrder);

            // act
            var result = await SystemUnderTest.Create(vm, null);
            var viewResult = Assert.IsType<ViewResult>(result);

            // assert
            Assert.Equal(vm, viewResult.Model);
        }

        [Fact]
        public async Task OrderController_DeletePost_SuccessTest()
        {
            // arrange
            var commandDependency =
                new Mock<ICommandHandler<DeleteOrderCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<DeleteOrderCommand>()))
                .Returns(Task.CompletedTask);
            var fakeOrder = new Order();
            var vm = new OrderFullEditViewModel(fakeOrder)
            {
                 Id = 1,
                CustomerId = 1,
                EmployeeId = 1,
                Freight = 336.26M,
                OrderDate = new DateTime(2022 / 06 / 27),
                RequiredDate = new DateTime(2022 / 06 / 27),
                ShipAddress = "258 City Place",
                ShipCity = "Pretoria",
                ShipCountry = "Botswana",
                ShipName = "The Flying Dutchman",
                ShippedDate = new DateTime(2022 / 06 / 27),
                ShipPostalCode = "1852",
                ShipRegion = "Ekuruleni",
                ShipVia = 2
            };

            // act
            var result = await SystemUnderTest.Delete(vm.Id,
                commandDependency.Object);
            commandDependency.Verify(m => m.HandleAsync(
            It.IsAny<DeleteOrderCommand>()),
            Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);

            // assert
            Assert.Equal(nameof(OrdersController.Index),
                redirectResult.ActionName);
            Assert.Null(redirectResult.ControllerName);
        }

        [Fact]
        public async Task OrderController_DeletePost_ValidationFailedTest()
        {
            // arrange
            var controller = new OrdersController();
            controller.ModelState
                .AddModelError("Name", "fake error");
            var fakeOrder = new Order();
            var vm = new OrderFullEditViewModel(fakeOrder);
            var result = await controller.Edit(vm, null);

            // act
            var viewResult = Assert.IsType<ViewResult>(result);

            // assert
            Assert.Equal(vm, viewResult.Model);
        }
    }
}