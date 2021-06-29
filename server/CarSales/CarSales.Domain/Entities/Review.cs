using System;
using System.ComponentModel.DataAnnotations.Schema;
using CarSales.Domain.Common;

namespace CarSales.Domain.Entities
{
    public class Review: BaseEntity
    {
        public Guid UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        
        public string Comment { get; set; }
    }
}