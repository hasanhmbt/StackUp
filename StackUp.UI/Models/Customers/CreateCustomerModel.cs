﻿using System.ComponentModel.DataAnnotations;

namespace StackUp.UI.Models.Customers
{
    public class CreateCustomerModel
    {
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Customer name must not exceed 100 characters.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address must not exceed 200 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact information is required.")]
        public ContactInfoModel ContactInfo { get; set; }
    }

    public class ContactInfoModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }
    }
}