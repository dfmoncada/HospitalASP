using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doctosCrud.Models
{
    public class Doctor
    {
        private int id;
        private string name;
        private string specialization;
        private string resume;

        public Doctor(int i, string n, string s, string r)
        {
            id = i;
            name = n;
            specialization = s;
            resume = r;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Specialization { get => specialization; set => specialization = value; }
        public string Resume { get => resume; set => resume = value; }
    }
}