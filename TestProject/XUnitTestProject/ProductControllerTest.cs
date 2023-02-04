using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TestProject.Controllers;
using Xunit;

namespace XUnitTestProject
{

    public class AutoDomainDataAttribute : AutoDataAttribute
    {
        public AutoDomainDataAttribute() : base(
            () =>
            {
                var fixture = new Fixture();

                //fixture.Create<Pizzas>();

                fixture.Customize(new AutoMoqCustomization());


                return fixture;
            }
            )
        {

        }
    }

    public class ProductControllerTest
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [AutoDomainData]
        public void GetAllProducts_OkResult([CollectionSize(3)] IEnumerable<Product> products, [Frozen] Mock<IProductService> mockProductService, [Greedy] ProductController productController)
        {
            //Arrange
            mockProductService.Setup(x => x.GetAllProducts()).Returns(products);

            //Act
            var result = productController.Get();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(products.Count(), (expectedResult.Value as IEnumerable<Product>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetAllProducts_OkResultWithZeroCount([CollectionSize(0)] IEnumerable<Product> products, [Frozen] Mock<IProductService> mockProductService, [Greedy] ProductController productController)
        {
            //Arrange
            mockProductService.Setup(x => x.GetAllProducts()).Returns(products);

            //Act
            var result = productController.Get();

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result.Result;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(products.Count(), (expectedResult.Value as IEnumerable<Product>).Count());
        }

        [Theory]
        [AutoDomainData]
        public void GetSaveProduct_Created(Product product, [Frozen] Mock<IProductService> mockProductService, [Greedy] ProductController productController)
        {
            //Arrange
            int id = 5;
            product.Id = id;
            mockProductService.Setup(x => x.AddProduct(product)).Returns(product);

            //Act
            var result = productController.Post(product);

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result;
            Assert.IsType<CreatedAtActionResult>(expectedResult);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.Equal(product.Id, (expectedResult.Value as Product).Id);
            // Assert.Equal(product, (expectedResult.Value as Order).Id);
        }

        [Theory]
        [AutoDomainData]
        public void GetSaveProduct_NotCreated(Product product, [Frozen] Mock<IProductService> mockProductService, [Greedy] ProductController productController)
        {
            //Arrange
            mockProductService.Setup(x => x.AddProduct(null)).Returns(product);

            //Act
            var result = productController.Post(product);

            //Assert
            var expectedResult = (Microsoft.AspNetCore.Mvc.ObjectResult)result;
            Assert.IsType<CreatedAtActionResult>(expectedResult);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)(expectedResult).StatusCode);
            Assert.NotEqual(product.Id, (expectedResult.Value as Product).Id);
        }

        [Theory]
        [AutoDomainData]
        public void GetUpdateProduct_Ok(Product product, [Frozen] Mock<IProductService> mockProductService, [Greedy] ProductController productController)
        {
            //Arrange
            mockProductService.Setup(x => x.UpdateProduct(product)).Returns(true);

            //Act
            var result = productController.Put(product);

            //Assert

            Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
        }

        [Theory]
        [AutoDomainData]
        public void GetUpdateProduct_NoUpdated(Product product, [Frozen] Mock<IProductService> mockProductService, [Greedy] ProductController productController)
        {
            //Arrange

            mockProductService.Setup(x => x.UpdateProduct(product)).Returns(false);

            //Act
            var result = productController.Put(product);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
        }




        [Theory]
        [AutoDomainData]
        public void GetDeleteProduct_Ok(Product product, [Frozen] Mock<IProductService> mockProductService, [Greedy] ProductController productController)
        {
            //Arrange
            int id = 5;
            product.Id = id;
            mockProductService.Setup(x => x.DeleteProduct(product.Id)).Returns(true);

            //Act
            var result = productController.Delete(product.Id);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, (HttpStatusCode)((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
        }

        [Theory]
        [AutoDomainData]
        public void GetDeleteProduct_NotDeleted(Product product, [Frozen] Mock<IProductService> mockProductService, [Greedy] ProductController productController)
        {
            //Arrange
            int id = 5;
            product.Id = id;
            mockProductService.Setup(x => x.DeleteProduct(id)).Returns(false);

            //Act
            var result = productController.Delete(id);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode);
        }
    }
}
