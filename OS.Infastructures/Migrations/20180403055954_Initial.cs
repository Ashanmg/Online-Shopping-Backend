using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OS.Infastructures.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quentity = table.Column<int>(nullable: false),
                    SubTotalPrice = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderNote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    DisplayToCustomer = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeCombination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeXml = table.Column<string>(nullable: true),
                    AvailableQuentity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeCombination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountUserId = table.Column<int>(nullable: false),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    IsApproved = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    ReviewText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<int>(nullable: false),
                    FreeShipping = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SystemName = table.Column<string>(nullable: true),
                    TaxEnabled = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountUserId = table.Column<int>(nullable: false),
                    AttributeXml = table.Column<string>(nullable: true),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    Quentity = table.Column<int>(nullable: false),
                    ShoppingCartItemId = table.Column<int>(nullable: true),
                    ShoppingCartTypeId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCartItem_ShoppingCartItemId",
                        column: x => x.ShoppingCartItemId,
                        principalTable: "ShoppingCartItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountUserCurrencyCode = table.Column<string>(nullable: true),
                    AccountUserId = table.Column<int>(nullable: false),
                    AllowStoringCreditCardNumber = table.Column<int>(nullable: false),
                    AuthenticationTransactionCode = table.Column<string>(nullable: true),
                    AuthenticationTransactionId = table.Column<string>(nullable: true),
                    AuthenticationTransactionResult = table.Column<string>(nullable: true),
                    BillingAddressId = table.Column<int>(nullable: false),
                    CaptureTransactionId = table.Column<string>(nullable: true),
                    CaptureTransactionResult = table.Column<string>(nullable: true),
                    CardCvv2 = table.Column<int>(nullable: false),
                    CardExpirationMonth = table.Column<string>(nullable: true),
                    CardExpirationYear = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    CardNumber = table.Column<int>(nullable: false),
                    CardType = table.Column<string>(nullable: true),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    CurrencyRate = table.Column<decimal>(nullable: false),
                    MaskedCreditCardNumber = table.Column<int>(nullable: false),
                    OrderDiscount = table.Column<decimal>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: true),
                    OrderNoteId = table.Column<int>(nullable: true),
                    OrderStatus = table.Column<string>(nullable: true),
                    OrderSubTotal = table.Column<decimal>(nullable: false),
                    OrderSubTotalDiscount = table.Column<decimal>(nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    PaidDateUTC = table.Column<DateTime>(nullable: false),
                    PaymentMethodAdditionalFee = table.Column<decimal>(nullable: false),
                    PaymentMethodSystemName = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    PickupInStore = table.Column<int>(nullable: false),
                    RefundableAmmount = table.Column<decimal>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    SubscriptionTransactionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_OrderNote_OrderNoteId",
                        column: x => x.OrderNoteId,
                        principalTable: "OrderNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PerentProductTypeId = table.Column<int>(nullable: false),
                    PictureId = table.Column<int>(nullable: true),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductType_Picture_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountUserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountUserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowCustomerReview = table.Column<int>(nullable: false),
                    ApprovedRatingSum = table.Column<decimal>(nullable: false),
                    ApprovedTotalReview = table.Column<int>(nullable: false),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OrderItemId = table.Column<int>(nullable: true),
                    PictureId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ProductAttributeCombinationId = table.Column<int>(nullable: true),
                    ProductReviewId = table.Column<int>(nullable: true),
                    ProductTypeId = table.Column<int>(nullable: false),
                    ShoppingCartItemId = table.Column<int>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    ShowOnCategoryPage = table.Column<int>(nullable: false),
                    TaxIncluded = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Picture_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductAttributeCombination_ProductAttributeCombinationId",
                        column: x => x.ProductAttributeCombinationId,
                        principalTable: "ProductAttributeCombination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductReview_ProductReviewId",
                        column: x => x.ProductReviewId,
                        principalTable: "ProductReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ShoppingCartItem_ShoppingCartItemId",
                        column: x => x.ShoppingCartItemId,
                        principalTable: "ShoppingCartItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<int>(nullable: false),
                    BillingAddressId = table.Column<int>(nullable: false),
                    ContactNumber = table.Column<int>(nullable: false),
                    CreatedByUTC = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastLoginUTC = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordSult = table.Column<string>(nullable: true),
                    ProductReviewId = table.Column<int>(nullable: true),
                    ShoppingCartItemId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUser_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountUser_ProductReview_ProductReviewId",
                        column: x => x.ProductReviewId,
                        principalTable: "ProductReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountUser_ShoppingCartItem_ShoppingCartItemId",
                        column: x => x.ShoppingCartItemId,
                        principalTable: "ShoppingCartItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: true),
                    ShoppingCartItemId = table.Column<int>(nullable: true),
                    StoreAddress = table.Column<string>(nullable: true),
                    StoreContactNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_ShoppingCartItem_ShoppingCartItemId",
                        column: x => x.ShoppingCartItemId,
                        principalTable: "ShoppingCartItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_ProductAttributeMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsRequired = table.Column<int>(nullable: false),
                    ProductAttributeId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_ProductAttributeMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductAttributeMapping_ProductAttribute_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductAttributeMapping_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountUserId = table.Column<int>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    ModifiedOnUTC = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: true),
                    ZipPostalCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AccountUser_AccountUserId",
                        column: x => x.AccountUserId,
                        principalTable: "AccountUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockItemMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCombinationId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItemMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockItemMapping_ProductAttributeCombination_AttributeCombinationId",
                        column: x => x.AttributeCombinationId,
                        principalTable: "ProductAttributeCombination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockItemMapping_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_OrderId",
                table: "AccountUser",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_ProductReviewId",
                table: "AccountUser",
                column: "ProductReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_ShoppingCartItemId",
                table: "AccountUser",
                column: "ShoppingCartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUserRole_RoleId",
                table: "AccountUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AccountUserId",
                table: "Address",
                column: "AccountUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_OrderId",
                table: "Address",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_ProductId",
                table: "Manufacturer",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderItemId",
                table: "Order",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderNoteId",
                table: "Order",
                column: "OrderNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderItemId",
                table: "Product",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PictureId",
                table: "Product",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductAttributeCombinationId",
                table: "Product",
                column: "ProductAttributeCombinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductReviewId",
                table: "Product",
                column: "ProductReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShoppingCartItemId",
                table: "Product",
                column: "ShoppingCartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductAttributeMapping_ProductAttributeId",
                table: "Product_ProductAttributeMapping",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductAttributeMapping_ProductId",
                table: "Product_ProductAttributeMapping",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_PictureId",
                table: "ProductType",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartItemId",
                table: "ShoppingCartItem",
                column: "ShoppingCartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItemMapping_AttributeCombinationId",
                table: "StockItemMapping",
                column: "AttributeCombinationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItemMapping_StoreId",
                table: "StockItemMapping",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_OrderId",
                table: "Store",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ShoppingCartItemId",
                table: "Store",
                column: "ShoppingCartItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUserRole");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Product_ProductAttributeMapping");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "StockItemMapping");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "AccountUser");

            migrationBuilder.DropTable(
                name: "ProductAttribute");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "ProductAttributeCombination");

            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderNote");
        }
    }
}
