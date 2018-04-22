using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApiProductService.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
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
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
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
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
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
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
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
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
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
                    ProductTypeId = table.Column<int>(nullable: true),
                    Sales = table.Column<int>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImg",
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
                    table.PrimaryKey("PK_ProductImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImg_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sku",
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
                    table.PrimaryKey("PK_Sku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sku_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sku_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImg_ProductId",
                table: "ProductImg",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sku_ColorId",
                table: "Sku",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sku_ProductId",
                table: "Sku",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "ProductImg");

            migrationBuilder.DropTable(
                name: "Sku");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
