namespace Data.Repositories
{
	using System.Data.Entity;
	using System.Linq;

	using Data.Models;

	public class ProductRepository
	{
		private readonly AdventureWorksDbContext context = new AdventureWorksDbContext();

		/// <summary>
		/// Returns a Product with Reviews, Vendors, Inventories, Materials, and OrderDetails
		/// </summary>
		public Product GetProduct(int productId)
		{
			this.context.Configuration.ProxyCreationEnabled = false;

			var foundProduct = this.context
				.Products	

				.Include(product => product.ProductReviews)
				.Include(product => product.ProductVendors)
				.Include(product => product.ProductInventories)
				.Include(product => product.BillOfMaterials)
				.Include(product => product.PurchaseOrderDetails)

				.FirstOrDefault(product => product.ProductID == productId);

			this.context.Configuration.ProxyCreationEnabled = true;

			return foundProduct;
		}

		/// <summary>
		/// Everything except for SpecialOfferProducts, WorkOrders, and Histories
		/// </summary>
		public Product GetProductWithStandardInformation(int productId)
		{
			this.context.Configuration.ProxyCreationEnabled = false;

			var foundProduct = this.context
				.Products
				
				.Include(product => product.ProductReviews)

				.Include(product => product.ProductVendors)
				.Include(product => product.ProductVendors.Select(pv => pv.Vendor))
				.Include(product => product.ProductVendors.Select(pv => pv.UnitMeasure))

				.Include(product => product.ProductInventories)
				.Include(product => product.ProductInventories.Select(pi => pi.Location))

				.Include(product => product.BillOfMaterials)
				.Include(product => product.BillOfMaterials.Select(bom => bom.UnitMeasure))

				.Include(product => product.PurchaseOrderDetails)
				.Include(product => product.ShoppingCartItems)

				.FirstOrDefault(product => product.ProductID == productId);

			this.context.Configuration.ProxyCreationEnabled = true;

			return foundProduct;
		}

		/// <summary>
		/// Includes histories
		/// </summary>
		public Product GetProductWithDetailedInformation(int productId)
		{
			this.context.Configuration.ProxyCreationEnabled = false;

			var foundProduct = this.context
				.Products

				.Include(product => product.ProductReviews)

				.Include(product => product.ProductVendors)
				.Include(product => product.ProductVendors.Select(pv => pv.Vendor))
				.Include(product => product.ProductVendors.Select(pv => pv.UnitMeasure))

				.Include(product => product.ProductInventories)
				.Include(product => product.ProductInventories.Select(pi => pi.Location))

				.Include(product => product.BillOfMaterials)
				.Include(product => product.BillOfMaterials.Select(bom => bom.UnitMeasure))

				.Include(product => product.SpecialOfferProducts)
					.Include(product => product.SpecialOfferProducts.Select(sop => sop.SpecialOffer))
					.Include(product => product.SpecialOfferProducts.Select(sop => sop.SalesOrderDetails))

				.Include(product => product.WorkOrders)
					.Include(product => product.WorkOrders.Select(wo => wo.ScrapReason))
					.Include(product => product.WorkOrders.Select(wo => wo.WorkOrderRoutings))

				.Include(product => product.PurchaseOrderDetails)
				.Include(product => product.ShoppingCartItems)

				// History records
				.Include(product => product.ProductCostHistories)
				.Include(product => product.ProductListPriceHistories)
				.Include(product => product.TransactionHistories)

				.FirstOrDefault(product => product.ProductID == productId);

			this.context.Configuration.ProxyCreationEnabled = true;

			return foundProduct;
		}
	}
}
