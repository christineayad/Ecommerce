using Discount.Application.Commands;
using Discount.Application.DTOs;
using Discount.Core.Entities;
using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.Mappers
{
    public static  class CouponMapper
    {
        public static CouponDto ToDto(this Coupon coupon)
        {
            if (coupon == null) return null;
            return new CouponDto(coupon.Id, coupon.ProductName, coupon.Description, coupon.Amount);
        }
        public static Coupon ToEntity(this CreateDiscoundCommand command)
        {
            return new Coupon
            {
                ProductName = command.ProductName,
                Description = command.Description,
                Amount = command.Amount
            };
        }
        public static Coupon ToEntity(this UpdateDiscoundCommand command)
        {
            return new Coupon
            {
                ProductName = command.ProductName,
                Description = command.Description,
                Amount = command.Amount
            };
        }
        public static CouponModel ToModel(this CouponDto dto)
        {
            return new CouponModel
            {
                Id = dto.Id,
                ProductName = dto.ProductName,
                Description = dto.Description,
                Amount = dto.Amount
            };
        }
        public static CreateDiscoundCommand ToCreateCommand(this CouponModel model)
        {
            return new CreateDiscoundCommand(
                model.ProductName,
                model.Description,
                model.Amount);
        }
        public static UpdateDiscoundCommand ToUpdateCommand(this CouponModel model)
        {
            return new UpdateDiscoundCommand(
                model.Id,
                model.ProductName,
                model.Description,
                model.Amount);
        }
    }
}
