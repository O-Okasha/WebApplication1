using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class record
    {
        public record()
        {
        }

        public record(int id, int patientID, string diagnosis, string birthday)
        {
            Id = id;
            this.patientID = patientID;
            this.diagnosis = diagnosis;
            this.birthday = DateTime.Parse(birthday);
        }

        public int Id { get; set; }
        public int patientID  { get; set; }
        public string diagnosis { get; set; }
        public DateTime birthday { get; set; }

    }
}