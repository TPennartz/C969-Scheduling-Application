using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace C969Tpennartz
{
    class Appt_Validate

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

        [Required]

        public DateTime Start { get; set; }

        [Required]

        public DateTime End { get; set; }

    }

}