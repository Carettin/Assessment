using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Assessment.Entity
{
    public class Person
    {
        public int UUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public DateTime CreateDatetime { get; set; }
        public DateTime? UpdateDatetime { get; set; }
        public string IpAdres { get; set; }
       
        public IList<Info> Bilgiler { get; set; }
    }

}
