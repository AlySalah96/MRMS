using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BRMS.Models;

namespace BRMS.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
       
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18IfAMember]
        public DateTime? Birthdate { get; set; }
    }
}