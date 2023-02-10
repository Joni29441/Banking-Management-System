using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class login
    {
        //All the square bracket functions or DataAnnotations can be used for Validations on Form submit

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "SSN")]
        public string SSN { get; set; }


        [Required]
        [Display(Name = "Date Of Birth :")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DOB { get; set; }



        [Required(ErrorMessage = "Phone Number is Required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }



        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        [Display(Name = "Username")]
        public string username { get; set; }



        [Required(ErrorMessage = "Passoword is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }


        [Required(ErrorMessage = "PIN number is Required")]
        [Display(Name = "PIN Number")]
        public int PIN { get; set; }


        [Required(ErrorMessage = "Branch Location is Required")]
        public string Branch { get; set; }

        public List<Branches> Branchs { get; set; }

        [Required]
        public string AccountType { get; set; }
    }

    public class Branches
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CUSIP { get; set; }
        [Required]
        public string Contact { get; set; }
    }
}