using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OS.Infastructures.Migrations
{
    public partial class PictureIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Product_ProductId",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_Picture_ProductType_ProductTypeId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_ProductId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_ProductTypeId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "Picture");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_PictureId",
                table: "Product",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Picture_PictureId",
                table: "Product",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Picture_PictureId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_PictureId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Picture",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "Picture",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ProductId",
                table: "Picture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ProductTypeId",
                table: "Picture",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Product_ProductId",
                table: "Picture",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_ProductType_ProductTypeId",
                table: "Picture",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
