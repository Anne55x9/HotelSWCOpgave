namespace RESTWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoOfBookingsGuest")]
    public partial class NoOfBookingsGuest
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Guest_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Name { get; set; }

        public int? BookingCount { get; set; }
    }
}
