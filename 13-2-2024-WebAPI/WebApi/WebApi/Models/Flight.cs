using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models {
    public enum PERSON_TYPE {
        MALE,FEMALE,KID
    }
    public class Flight {
        [Key]
        public int flightId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters.")]
        public string description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime startTime;
        [Required]
        [Column("Duration")]
        public int duration;
        [Required]
        [DataType(DataType.Date)]
        public DateTime createdAt;
        public PERSON_TYPE type { get; set; }

        public override String ToString() {
            return $"Flight( {flightId}, {name}, {description}, {startTime}, {duration}, {type} )";
        }
    }
}