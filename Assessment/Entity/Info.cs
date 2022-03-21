using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Entity
{
    public class Info
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int PersonId { get; set; }
        public Person Personeller { get; set; }

    }
}
