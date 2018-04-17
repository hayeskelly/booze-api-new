using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BuckIBooze.API.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Products",
                newName: "supertype");

            migrationBuilder.AddColumn<string>(
                name: "subtype",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fname",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lname",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pickupNum",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productID",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "total",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subtype",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "fname",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "lname",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "pickupNum",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "productID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "total",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "supertype",
                table: "Products",
                newName: "type");
        }
    }
}
