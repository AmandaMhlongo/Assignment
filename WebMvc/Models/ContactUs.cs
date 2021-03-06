﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactUsID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Mobile is Required")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is Required")]
        public string Subject { get; set; }
    }
}