using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class patient
    {
        public patient(int id, string name, DateTime birthday, string nationalID, string city)
        {
            Id = id;
            Name = name;
            this.birthday = birthday;
            this.nationalID = nationalID;
            this.city = city;
        }
        public patient() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime birthday { get; set; }
        public string nationalID { get; set; }

        public string city { get; set; }
    }
}