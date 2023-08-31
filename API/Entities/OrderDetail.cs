﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class OrderDetail : BaseEntity<Guid>
    {
        [ForeignKey("Bill")]
        [Required]
        public Guid?  BillId { get; set; }
        [ForeignKey("Product")]
        [Required]
        public Guid? ProductId { get; set; }
        [Required]
        public int? Quantity { get; set; }
        public bool isSave { get; set; }
        [Required]
        public int? TotalMoney { get; set; }
    }
}
