using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReactAngularPracticeApi.Data.Entities
{
    [Table("Orders", Schema = "dbo")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        public int ProductQty { get; set; }
        public Decimal Price { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryManName { get; set; }
    }
}
