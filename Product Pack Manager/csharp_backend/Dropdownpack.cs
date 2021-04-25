using System;

namespace Product_Pack_Manager
{
    public class Dropdownpack
    {
        public string IdandName { get; set; }
        public int Id { get; set; }

        public Dropdownpack(int id, int typeprestation, DateTime validfrom, DateTime validuntil, string nom, string label, int typepack) 
        {
            //si result 1 et 2 sont a 1 alors le pack n'est pas expiré
            DateTime today = DateTime.Now;
            int result1 = DateTime.Compare(today, validfrom); // = 1 si today est après a validfrom
            int result2 = DateTime.Compare(validuntil, today);  // = 1 si today est avent validuntil
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