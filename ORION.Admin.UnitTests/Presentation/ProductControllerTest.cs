using System;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ORION.Admin.Commands;
using ORION.Admin.Controllers;
using ORION.Admin.Models.Products;
using ORION.Admin.UnitTests.Util;
using Xunit;

namespace ORION.Admin.UnitTests.Presentation
{
    public class ProductControllerTest
    {
        public ProductControllerTest()
        {
            _SystemUnderTest = null;
            _IProductsListQuery = null;
        }
        private ProductController? _SystemUnderTest;
        public ProductController SystemUnderTest
        {
            get
            {
                if (_SystemUnderTest == null)
                {
                    _SystemUnderTest = new ProductController();
                }
                return _SystemUnderTest;
            }
        }
        private MockIProductsListQuery? _IProductsListQuery;
        public MockIProductsListQuery IProductsListQuery
        {
            get
            {
                if (_IProductsListQuery == null)
                {
                    _IProductsListQuery = new MockIProductsListQuery();
                }
                return _IProductsListQuery;
            }
        }

        private MockIProductRepository _IProductRepository;
        public MockIProductRepository IProductRepository
        {
            get
            {
                if (_IProductRepository == null)
                {
                    _IProductRepository = new MockIProductRepository();
                }

                return _IProductRepository;
            }

        }

        [Fact]
        public async Task ProductController_Index_ModelIsNotNull()
        {
           //arrange
           var result = await SystemUnderTest.Index(IProductsListQuery);

           // act
           var vm = UnitTestUtility.GetModel<ProductsListViewModel>(result);
           var viewResult = Assert.IsType<ViewResult>(result);

           // assert
           Assert.Equal(vm, viewResult.Model);
        }
        
        [Fact]
        public async Task ProductController_IndexModel_IsValidAndInitialized()
        {
            //  arrange
            var resultSet = await SystemUnderTest.Index(IProductsListQuery);
            var model = UnitTestUtility.GetModelIAction<ProductsListViewModel>(resultSet);

            // act
            var actual = true;
            var result = SystemUnderTest.ModelState.IsValid;

            // assert
            Assert.Equal(result, actual);
        }

        [Fact]
        public async Task ProductController_CreatePost_SuccessTest()
        {
            // arrange
            var commandDependency =
                new Mock<ICommandHandler<CreateProductCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<CreateProductCommand>()))
                .Returns(Task.CompletedTask);
            var vm = new ProductFullEditViewModel()
            {
                Id = 1,
                ProductName = "MacBook Pro",
                Image = "Default.aspx",
                Description = "Silver Grey",                
                UnitPrice = 27000.00M,
                DurationInDays = 3,
                StartValidityDate = new DateTime(2022 / 06 / 27),
                EndValidityDate = new DateTime(2022 / 06 / 30),
                CategoryId = 1
            };

            // act
            var result = await SystemUnderTest.Create(vm, commandDependency.Object);
            commandDependency.Verify(m => m.HandleAsync(
                It.IsAny<CreateProductCommand>()),
                Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);

            // assert
            Assert.Equal(nameof(ProductController.Index), redirectResult.ActionName);
        }
  

       

        [Fact]
        public async Task ProductController_EditPost_SuccessTest()
        {
            // arrange
            var commandDependency = new Mock<ICommandHandler<UpdateProductCommand>>();
            commandDependency.Setup(p => p.HandleAsync(It.IsAny<UpdateProductCommand>()))
                            .Returns(Task.CompletedTask);
            var viewModel = new ProductFullEditViewModel()
            {
                Id = 1,
                ProductName = "MacBook Pro",
                Description = "Silver Grey",
                UnitPrice = 28000.00M,
                DurationInDays = 3,
                StartValidityDate = new DateTime(2022 / 06 / 27),
                EndValidityDate = new DateTime(2022 / 06 / 30),
                CategoryId = 1
            };

            // act
            var result = await SystemUnderTest.Edit(viewModel, commandDependency.Object);
            
            commandDependency.Verify(m=>m.HandleAsync(It.IsAny<UpdateProductCommand>()),
            Times.Once);
                            
            // assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(ProductController.Index),redirectResult.ActionName);
        }

        [Fact]
        public async Task ProductController_CreatePost_FailedTest()
        {
            // arrange
            SystemUnderTest.ModelState
                .AddModelError("Name", "fake error");
            var vm = new ProductFullEditViewModel();

            // act
            var result = await SystemUnderTest.Create(vm, null);
            var viewResult = Assert.IsType<ViewResult>(result);

            // assert
            Assert.Equal(vm, viewResult.Model);
        }

        [Fact]
        public async Task ProductController_DeletePost_SuccessTest()
        {
            // arrange
            var commandDependency =
                new Mock<ICommandHandler<DeleteProductCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<DeleteProductCommand>()))
                .Returns(Task.CompletedTask);
            var vm = new ProductFullEditViewModel()
            {
                Id = 1,
                ProductName = "MacBook Pro",
                Description = "Silver Grey",
                UnitPrice = 28000.00M,
                DurationInDays = 3,
                StartValidityDate = new DateTime(2022 / 06 / 27),
                EndValidityDate = new DateTime(2022 / 06 / 30),
                CategoryId = 1
            };

            // act
            var result = await SystemUnderTest.Delete(vm.Id,
                commandDependency.Object);
            commandDependency.Verify(m => m.HandleAsync(
            It.IsAny<DeleteProductCommand>()),
            Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);

            // assert
            Assert.Equal(nameof(ProductController.Index),
                redirectResult.ActionName);
            Assert.Null(redirectResult.ControllerName);
        }

        [Fact]
        public async Task ProductController_DeletePost_ValidationFailedTest()
        {
            // arrange
            var controller = new ProductController();
            controller.ModelState
                .AddModelError("Name", "fake error");
            var vm = new ProductFullEditViewModel();
            var result = await controller.Edit(vm, null);
            
            // act
            var viewResult = Assert.IsType<ViewResult>(result);
            
            // assert
            Assert.Equal(vm, viewResult.Model);
        }

      

        // [Fact]
        // public void _ProductController_Index_ModelIsNotNull()
        // {
        //     var actual =
        //         UnitTestUtility.GetModel<ProductViewModel>(
        //             SystemUnderTest.Index());

        //    Assert.IsNotNull(actual, "Model was null.");
        // }

        // [Fact]
        // public void ProductController_Index_Model_Value1IsInitialized()
        // {
        //     var model =
        //         UnitTestUtility.GetModel<ProductViewModel>(
        //             SystemUnderTest.Index());

        //     var actual = model.Value1;

        //     var expected = 0d;

        //     Assert.AreEqual<double>(expected, actual, "Value1 field value was wrong.");
        // }


        // [Fact]
        // public void ProductController_Index_Model_Value2IsInitialized()
        // {
        //     var model =
        //         UnitTestUtility.GetModel<ProductViewModel>(
        //             SystemUnderTest.Index());

        //     var actual = model.Value2;

        //     var expected = 0d;

        //     Assert.AreEqual<double>(expected, actual, "Value2 field value was wrong.");
        // }

        // [Fact]
        // public void ProductController_Index_Model_OperatorIsInitialized()
        // {
        //     var model =
        //         UnitTestUtility.GetModel<ProductViewModel>(
        //             SystemUnderTest.Index());

        //     var actual = model.Operator;

        //     var expected = ProductConstants.Message_ChooseAnOperator;

        //     Assert.AreEqual<string>(expected, actual, "Operator field value was wrong.");
        // }

        // [Fact]
        // public void ProductController_Index_Model_MessageIsInitialized()
        // {
        //     var model =
        //         UnitTestUtility.GetModel<ProductViewModel>(
        //             SystemUnderTest.Index());

        //     var actual = model.Message;

        //     var expected = String.Empty;

        //     Assert.AreEqual<string>(expected, actual, "Message field value was wrong.");
        // }

        // [Fact]
        // public void ProductController_Index_Model_IsResultValidShouldBeFalse()
        // {
        //     var model =
        //         UnitTestUtility.GetModel<ProductViewModel>(
        //             SystemUnderTest.Index());

        //     var actual = model.IsResultValid;

        //     var expected = false;

        //     Assert.AreEqual<bool>(expected, actual, "IsResultValid field value was wrong.");
        // }

        // [Fact]
        // public void ProductController_Index_Model_OperatorsCollectionIsPopulated()
        // {
        //     var model =
        //         UnitTestUtility.GetModel<ProductViewModel>(
        //             SystemUnderTest.Index());

        //     Assert.IsNotNull(model.Operators,
        //         "Operators collection was null.");

        //     var actual = model.Operators.Select(x => x.Text).ToList();

        //     var expected = new List<string>();

        //     expected.Add(ProductConstants.Message_ChooseAnOperator);
        //     expected.Add(ProductConstants.OperatorAdd);
        //     expected.Add(ProductConstants.OperatorSubtract);
        //     expected.Add(ProductConstants.OperatorMultiply);
        //     expected.Add(ProductConstants.OperatorDivide);

        //     CollectionAssert.AreEqual(expected, actual,
        //         "Wrong values in operators collection.");
        // }

        // [Fact]
        // public void ProductController_Calculate_Add()
        // {
        //     arrange
        //     var model =
        //         UnitTestUtility.GetModel<ProductViewModel>(
        //             SystemUnderTest.Index());

        //     double value1 = 2;
        //     double value2 = 3;
        //     double expected = DEFAULT_RETURN_VALUE;

        //     model.Value1 = value1;
        //     model.Value2 = value2;
        //     model.Operator = ProductConstants.OperatorAdd;

        //     // act
        //     var actual =
        //         UnitTestUtility.GetModel<ProductViewModel>(
        //             SystemUnderTest.Calculate(model));


        //     // assert
        //     Assert.IsTrue(actual.IsResultValid, "Result should be valid.");
        //     Assert.AreEqual<double>(expected, actual.ResultValue, "Result was wrong.");
        //     Assert.AreEqual<string>(ProductConstants.Message_Success,
        //         actual.Message, "Message was wrong.");

        //     Assert.IsTrue(ProductServiceInstance.AddWasCalled,
        //         "Add should have been called.");

        //     AssertOperatorsAndSelectedOperator(model,
        //         ProductConstants.OperatorAdd);
        // }


       
      
        // private void AssertOperatorsAndSelectedOperator(
        //     ProductInfosViewModel model, string expectedSelectedOperator)
        // {
        //     Assert.IsNotNull(model.Operators, "Operators collection was null.");

        //     var actual = model.Operators.Select(x => x.Text).ToList();

        //     var expected = new List<string>();

        //     expected.Add(ProductConstants.Message_ChooseAnOperator);
        //     expected.Add(ProductConstants.OperatorAdd);
        //     expected.Add(ProductConstants.OperatorSubtract);
        //     expected.Add(ProductConstants.OperatorMultiply);
        //     expected.Add(ProductConstants.OperatorDivide);

        //     CollectionAssert.AreEqual(expected, actual,
        //         "Operators in collection were wrong.");

        //     AssertSelectedOperator(model, expectedSelectedOperator);
        // }

        // private void AssertSelectedOperator(
        //     ProductInfosViewModel model, string expectedSelectedOperator)
        // {
        //     Assert.IsNotNull(model.Operators, "Operators collection was null.");

        //     Assert.AreEqual<string>(expectedSelectedOperator, model.Operator,
        //         "Operator property was wrong.");

        //     var match = (from temp in model.Operators
        //                  where temp.Text == expectedSelectedOperator
        //                  select temp).FirstOrDefault();

        //     Assert.IsNotNull(match,
        //         "Could not find '{0}' in Operators.",
        //         expectedSelectedOperator);

        //     Assert.IsTrue(match.Selected,
        //         "Operator '{0}' should have been selected.",
        //         expectedSelectedOperator);
        // }

    }
}