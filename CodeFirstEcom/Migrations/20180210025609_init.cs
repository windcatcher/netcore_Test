using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CodeFirstEcom.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BbsBrand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    IsDisplay = table.Column<sbyte>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BbsBuyer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Addr = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    IsDel = table.Column<sbyte>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    RegisterTime = table.Column<DateTime>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsBuyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BbsCity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsCity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BbsColor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImgUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsColor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BbsEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Degree = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<sbyte>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    IsDel = table.Column<sbyte>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BbsFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDel = table.Column<sbyte>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BbsProvince",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsProvince", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BbsTown",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsTown", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BbsType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDisplay = table.Column<sbyte>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BbsAddr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Addr = table.Column<string>(nullable: true),
                    BuyerId = table.Column<string>(nullable: true),
                    BuyerId1 = table.Column<int>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    IsDef = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsAddr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BbsAddr_BbsBuyer_BuyerId1",
                        column: x => x.BuyerId1,
                        principalTable: "BbsBuyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BbsOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BuyerId = table.Column<string>(nullable: true),
                    BuyerId1 = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DeliverFee = table.Column<decimal>(nullable: false),
                    Delivery = table.Column<sbyte>(nullable: true),
                    IsConfirm = table.Column<sbyte>(nullable: true),
                    IsPaiy = table.Column<sbyte>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Oid = table.Column<string>(nullable: true),
                    PayableFee = table.Column<double>(nullable: false),
                    PaymentCash = table.Column<sbyte>(nullable: true),
                    PaymentWay = table.Column<sbyte>(nullable: false),
                    State = table.Column<sbyte>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BbsOrder_BbsBuyer_BuyerId1",
                        column: x => x.BuyerId1,
                        principalTable: "BbsBuyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BbsProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BrandId = table.Column<int>(nullable: true),
                    CheckTime = table.Column<DateTime>(nullable: true),
                    CheckUserId = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Feature = table.Column<string>(nullable: true),
                    IsCommend = table.Column<sbyte>(nullable: true),
                    IsDel = table.Column<sbyte>(nullable: true),
                    IsHot = table.Column<sbyte>(nullable: true),
                    IsNew = table.Column<sbyte>(nullable: true),
                    IsShow = table.Column<sbyte>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    No = table.Column<string>(nullable: true),
                    PackageList = table.Column<string>(nullable: true),
                    Sales = table.Column<int>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BbsProduct_BbsBrand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "BbsBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BbsProduct_BbsType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BbsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BbsDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    ProductNo = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    SkuPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BbsDetail_BbsOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "BbsOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BbsImg",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDef = table.Column<sbyte>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BbsImg_BbsProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "BbsProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BbsSku",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColorId = table.Column<int>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUserId = table.Column<string>(nullable: true),
                    DeliveFee = table.Column<double>(nullable: true),
                    LastStatus = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    MarketPrice = table.Column<double>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Sales = table.Column<int>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    SkuImg = table.Column<string>(nullable: true),
                    SkuName = table.Column<string>(nullable: true),
                    SkuPrice = table.Column<double>(nullable: false),
                    SkuSort = table.Column<int>(nullable: true),
                    SkuType = table.Column<int>(nullable: true),
                    SkuUpperLimit = table.Column<int>(nullable: true),
                    StockInventory = table.Column<int>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BbsSku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BbsSku_BbsColor_ColorId",
                        column: x => x.ColorId,
                        principalTable: "BbsColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BbsSku_BbsProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "BbsProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BbsAddr_BuyerId1",
                table: "BbsAddr",
                column: "BuyerId1");

            migrationBuilder.CreateIndex(
                name: "IX_BbsDetail_OrderId",
                table: "BbsDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BbsImg_ProductId",
                table: "BbsImg",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BbsOrder_BuyerId1",
                table: "BbsOrder",
                column: "BuyerId1");

            migrationBuilder.CreateIndex(
                name: "IX_BbsProduct_BrandId",
                table: "BbsProduct",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BbsProduct_TypeId",
                table: "BbsProduct",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BbsSku_ColorId",
                table: "BbsSku",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BbsSku_ProductId",
                table: "BbsSku",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BbsAddr");

            migrationBuilder.DropTable(
                name: "BbsCity");

            migrationBuilder.DropTable(
                name: "BbsDetail");

            migrationBuilder.DropTable(
                name: "BbsEmployee");

            migrationBuilder.DropTable(
                name: "BbsFeature");

            migrationBuilder.DropTable(
                name: "BbsImg");

            migrationBuilder.DropTable(
                name: "BbsProvince");

            migrationBuilder.DropTable(
                name: "BbsSku");

            migrationBuilder.DropTable(
                name: "BbsTown");

            migrationBuilder.DropTable(
                name: "BbsOrder");

            migrationBuilder.DropTable(
                name: "BbsColor");

            migrationBuilder.DropTable(
                name: "BbsProduct");

            migrationBuilder.DropTable(
                name: "BbsBuyer");

            migrationBuilder.DropTable(
                name: "BbsBrand");

            migrationBuilder.DropTable(
                name: "BbsType");
        }
    }
}
