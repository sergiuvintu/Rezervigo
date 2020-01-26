using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rezervigo.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime checkin { get; set; }
        public string FormattedCheckinDate
        {
            get
            {
                return string.Format("{0:yyyy-MM-dd}", checkin);
            }
        }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Checkout { get; set; }
        public string FormattedCheckoutDate
        {
            get
            {
                return string.Format("{0:yyyy-MM-dd}", Checkout);
            }
        }
        [Required]
        [ForeignKey("User")]
        public int User_Id { get; set; }
        [Required]
        [ForeignKey("Room")]

        public int Room_Id { get; set; }
        public virtual User User { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        
    }
}