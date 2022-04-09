using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public static class GeneralController
    {
        public static List<patient> patients = new List<patient>();
        public static List<patient> newpatients = new List<patient>();
        public static List<record> records = new List<record>();
        public static List<record> newrecords = new List<record>();

        public static void done()
        {
            newpatients = patients;
        }
        public static void doneRecords()
        {
            newrecords = records;
        }

    }
}