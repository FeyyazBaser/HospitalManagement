﻿
namespace HospitalManagement.Core.Entities
{
    public class User:BaseEntity 
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
