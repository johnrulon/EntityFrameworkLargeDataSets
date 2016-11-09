namespace DataIntegrationTests.Repositories
{
	using Data.Models;
	using Data.Repositories;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class ProductRepository2IntegrationTests
	{
		[TestMethod]
		public void GetProduct()
		{
			// arrange
			int productId = 316; // blade
			var productRepo = new ProductRepository2();

			// act
			Product result = productRepo.GetProduct(productId);

			// assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetProductWithStandardInformation()
		{
			// arrange
			int productId = 316; // blade
			var productRepo = new ProductRepository2();

			// act
			Product result = productRepo.GetProductWithStandardInformation(productId);

			// assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetProductWithDetailedInformation()
		{
			// arrange
			int productId = 316; // blade
			var productRepo = new ProductRepository2();

			// act
			Product result = productRepo.GetProductWithDetailedInformation(productId);

			// assert
	//		Assert.IsNotNull(result);
		}
	}
}
