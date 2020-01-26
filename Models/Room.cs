using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rezervigo.Models
{
    public enum RoomType
    {
        SingleRoom,
        DoubleRoom,
        Triple,
        Queen,
        King
    }
    public class Room
    {
        
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public RoomType Type { get; set; }
    }
}