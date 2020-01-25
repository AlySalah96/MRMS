using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MRMS.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter a valid name")]
        [MaxLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
       
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Member shipType")]
        public byte MembershipTypeId  { get; set; }

        [Display(Name="Date of birth")]
        [Min18IfAMember]
        public DateTime? Birthdate { get; set; }

    }
}