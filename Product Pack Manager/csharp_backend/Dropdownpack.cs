using System;

namespace Product_Pack_Manager
{
    public class Dropdownpack
    {
        public string IdandName { get; set; }
        public int Id { get; set; }

        public Dropdownpack(int id, int typeprestation, DateTime validfrom, DateTime validuntil, string nom, string label, int typepack) 
        {
            //if result 1 and 2 == 1 then the pack isn't expire
            DateTime today = DateTime.Now;
            int result1 = DateTime.Compare(today, validfrom); // = 1 if today is after validfrom
            int result2 = DateTime.Compare(validuntil, today);  // = 1 if today is before validuntil
            if (result1 == 1 && result2 == 1)
            {
                IdandName = nom + " (" + id + ") " + validfrom.Date.ToString("dd.MM.yyyy");
            }
            else 
            {
                IdandName = "⚠" + nom + " (id: " + id + ") " + validuntil.Date.ToString("dd.MM.yyyy");
            }
            Id = id;
        }
    }
}