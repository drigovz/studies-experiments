﻿namespace DapperExemple.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameAddress { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public virtual User User { get; set; }
    }
}
