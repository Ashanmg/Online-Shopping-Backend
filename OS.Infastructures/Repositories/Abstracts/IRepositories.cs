using OS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Infastructures.Repositories.Abstracts
{
    public interface IAccountUserRepository : IEntityBaseRepository<AccountUser>
    {
        AccountUser GetSingleByUsername(string username);
        IEnumerable<Role> GetUserRoles(string username);
    }
    public interface IAccountUserRoleRepository : IEntityBaseRepository<AccountUserRole> { }
    public interface IAddressRepository : IEntityBaseRepository<Address>
    {
        Address GetInsertedAddress();
    }
    public interface IManufacturerRepository : IEntityBaseRepository<Manufacturer> { }
    public interface IOrderRepository : IEntityBaseRepository<Order> { }
    public interface IOrderItemRepository : IEntityBaseRepository<OrderItem> { }
    public interface IOrderNoteRepository : IEntityBaseRepository<OrderNote> { }
    public interface IPictureRepository : IEntityBaseRepository<Picture> { }
    public interface IProductRepository : IEntityBaseRepository<Product>
    {
        List<Product> GetProductListForCategoryPage();
    }
    public interface IProduct_ProductAttributeMappingRepository : IEntityBaseRepository<Product_ProductAttributeMapping> { }
    public interface IProductAttributeRepository : IEntityBaseRepository<ProductAttribute> { }
    public interface IProductAttributeCombinationRepository : IEntityBaseRepository<ProductAttributeCombination> { }
    public interface IProductReviewRepository : IEntityBaseRepository<ProductReview> { }
    public interface IProductTypeRepository : IEntityBaseRepository<ProductType> { }
    public interface IRoleRepository : IEntityBaseRepository<Role> { }
    public interface IShoppingCartItemRepository : IEntityBaseRepository<ShoppingCartItem> { }
    public interface IStockItemMappingRepository : IEntityBaseRepository<StockItemMapping> { }
    public interface IStoreRepository : IEntityBaseRepository<Store> { }
}
