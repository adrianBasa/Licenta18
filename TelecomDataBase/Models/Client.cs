//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelecomDataBase.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public Client()
        {
            this.Comandas = new HashSet<Comanda>();
        }
    
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP_CIF { get; set; }
        public string Judet { get; set; }
        public string Oras { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    
        public virtual ICollection<Comanda> Comandas { get; set; }
    }
}
