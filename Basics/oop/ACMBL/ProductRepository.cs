namespace ACMBL
{
    public class ProductRepository
    {
        public Product Retrieve(int productId)
        {
            var product = new Product(productId);
            
            //TODO retrieve the data
            
            
            //hardcoded
            if (productId == 2)
            {
                product.ProductName = "Chupa";
                product.ProductDescription = "Chups";
                product.CurrentPrice = 15.6M;
            }
            
            return product;
        }

        public bool Save(Product product)
        {
            var success = true;

            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
    }
}