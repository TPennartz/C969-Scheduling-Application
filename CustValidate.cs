using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using C969Tpennartz.Database;

namespace C969Tpennartz
{
    class ValidateCustomer

    {

        [Required, StringLength(45, ErrorMessage = "Customer Name cannot exceed 45 characters", ErrorMessageResourceName = "Customer Name", MinimumLength = 1)]

        public string CustomerName { get; set; }

        [Required, Phone(ErrorMessage = "Phone number must be in a valid format")]

        public string PhoneNumber { get; set; }

        [Required, StringLength(50, ErrorMessage = "Address Line 1 cannot exceed 50 characters", MinimumLength = 1)]

        public string CustAddress { get; set; }

        [StringLength(50, ErrorMessage = "Address Line 2 cannot exceed 50 characters", MinimumLength = 1)]

        public string CustAddress2 { get; set; }

        [Required, RegularExpression("([0-9]{1,20})", ErrorMessage = "Postal Code must be numeric and cannot exceed 20 digits")]

        public string CustZip { get; set; }

        [Required, StringLength(50, ErrorMessage = "City cannot exceed 50 characters", MinimumLength = 1)]

        public string CustCity { get; set; }

        [Required, StringLength(50, ErrorMessage = "Address Line 1 cannot exceed 50 characters", MinimumLength = 1)]

        public string CustCountry { get; set; }

    }

    class ApptValidate

    {



        public string ApptTitle { get; set; }

        [Required]

        public string ApptDescription { get; set; }

        [Required]

        public string ApptType { get; set; }

        [Required]

        public string ApptLocation { get; set; }

        [Required]

        public string ApptContact { get; set; }
        public DateTime Start { get; set; }

        [Required]

        public DateTime End { get; set; }


    }

}