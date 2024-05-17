﻿using System.ComponentModel.DataAnnotations;

namespace APIProject.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int Age { get; set; }

       
        public virtual ICollection<PersonInterest> PersonInterests { get; set; }
        public virtual ICollection<Link> Links { get; set; }

    }
}
