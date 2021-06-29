using System;
using System.ComponentModel.DataAnnotations.Schema;
using CarSales.Domain.Common;

namespace CarSales.Domain.Entities
{
    public class Image: BaseEntity
    {
        public Guid OfferId { get; set; }
        
        [ForeignKey((nameof(OfferId)))]
        public Offer Offer { get; set; }
        
        public byte[] OfferImage { get; set; }
    }
}