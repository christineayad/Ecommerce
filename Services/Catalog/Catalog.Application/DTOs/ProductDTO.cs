using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
//Entity / Business Object → غالبًا class

//DTO / مجرد بيانات للنقل → غالبًا record
namespace Catalog.Application.DTOs
{
    // transfer data ,value equality,immutable data(not change after bulid object)
    //Display products to the user
    public record ProductDto(
    string Id,
    string Name,
    string Summary,
    string Description,
    string ImageFile,
    BrandDto Brand,
    TypeDto Type,
    decimal Price,
    DateTimeOffset CreatedDate
);

    public record BrandDto(string Id, string Name);
    public record TypeDto(string Id, string Name);
    //send requst to create product 
    //CreateProductDto هو الكائن اللي هيستقبل البيانات دي
    public record class CreateProductDto
    {
        [Required]
        public string Name { get; init; }  //inint يسمح بتحديد القيمة وقت إنشاء الـ  object فقط.

        [Required]
        public string Summary { get; init; }

        [Required]
        public string Description { get; init; }

        [Required]
        public string ImageFile { get; init; }

        [Required]
        public string BrandId { get; init; }

        [Required]
        public string TypeId { get; init; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public string Price { get; init; }
    }

    public record class UpdateProductDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public string Summary { get; init; }

        [Required]
        public string Description { get; init; }

        [Required]
        public string ImageFile { get; init; }

        [Required]
        public string BrandId { get; init; }

        [Required]
        public string TypeId { get; init; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public string Price { get; init; }
    }
}
