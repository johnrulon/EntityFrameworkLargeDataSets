namespace Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    using Data.Models;

    public class ProductRepository2
    {
        private readonly AdventureWorksDbContext context = new AdventureWorksDbContext();

        // Returns a Product with Reviews, Vendors, Inventories, Materials, and OrderDetails
        public Product GetProduct(int productId)
        {
            this.context.Configuration.ProxyCreationEnabled = false;

            var foundProduct = this.context
                .Products
                .FirstOrDefault(product => product.ProductID == productId);

            if (foundProduct != null)
            {
                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductReviews)
                    .Query()
                    .Load();

                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductVendors)
                    .Query()
                    .Load();

                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductInventories)
                    .Query()
                    .Load();

                this.context.Entry(foundProduct)
                    .Collection(product => product.BillOfMaterials)
                    .Query()
                    .Load();

                this.context.Entry(foundProduct)
                    .Collection(product => product.PurchaseOrderDetails)
                    .Query()
                    .Load();
            }

            this.context.Configuration.ProxyCreationEnabled = true;

            return foundProduct;
        }
        
        // Returns a Product with Reviews, Vendors, Inventories, Materials, and OrderDetails
        public Product GetProductWithStandardInformation(int productId)
        {
            this.context.Configuration.ProxyCreationEnabled = false;

            var foundProduct = this.context
                .Products
                .FirstOrDefault(product => product.ProductID == productId);

            if (foundProduct != null)
            {
                // no data
                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductReviews)
                    .Query()
                    .Load();

                // no data
                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductVendors)
                    .Query()
                    .Include(productVendor => productVendor.Vendor)
                    .Include(productVendor => productVendor.UnitMeasure)
                    .Load();

                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductInventories)
                    .Query()
                    .Include(inventory => inventory.Location)
                    .Load();

                this.context.Entry(foundProduct)
                    .Collection(product => product.BillOfMaterials)
                    .Query()
                    .Include(bom => bom.UnitMeasure)
                    .Load();

                // no data
                this.context.Entry(foundProduct)
                    .Collection(product => product.PurchaseOrderDetails)
                    .Query()
                    .Load();
                
                // no data
                this.context.Entry(foundProduct)
                    .Collection(product => product.ShoppingCartItems)
                    .Query()
                    .Load();
            }

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
                .FirstOrDefault(product => product.ProductID == productId);

            if (foundProduct != null)
            {
                // no data
                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductReviews)
                    .Query()
                    .Load();

                // no data
                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductVendors)
                    .Query()
                    .Include(productVendor => productVendor.Vendor)
                    .Include(productVendor => productVendor.UnitMeasure)
                    .Load();

                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductInventories)
                    .Query()
                    .Include(inventory => inventory.Location)
                    .Load();

                this.context.Entry(foundProduct)
                    .Collection(product => product.BillOfMaterials)
                    .Query()
                    .Include(bom => bom.UnitMeasure)
                    .Load();

                // no data
                this.context.Entry(foundProduct)
                    .Collection(product => product.PurchaseOrderDetails)
                    .Query()
                    .Load();

                // no data
                this.context.Entry(foundProduct)
                    .Collection(product => product.ShoppingCartItems)
                    .Query()
                    .Load();

                this.context.Entry(foundProduct)
                    .Collection(product => product.SpecialOfferProducts)
                    .Query()
                    .Include(sop => sop.SpecialOffer)
                    .Include(sop => sop.SalesOrderDetails)
                    .Load();
                
                this.context.Entry(foundProduct)
                    .Collection(product => product.WorkOrders)
                    .Query()
                    .Include(wo => wo.ScrapReason)
                    .Include(wo => wo.WorkOrderRoutings)
                    .Load();

                // History records
                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductCostHistories)
                    .Query();
                
                this.context.Entry(foundProduct)
                    .Collection(product => product.ProductListPriceHistories)
                    .Query();
                
                this.context.Entry(foundProduct)
                    .Collection(product => product.TransactionHistories)
                    .Query()
                    .Load();


            }

            this.context.Configuration.ProxyCreationEnabled = true;

            return foundProduct;
        }
    }
}
