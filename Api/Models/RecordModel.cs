using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor_Assessment.Models
{
    public class RecordModel: IEquatable<RecordModel>
    {
        // Not sure what schema I'm supposed to be validating against, nothing was provided other than the column names...
        // As such, I'm just checking that each input is given a value.
        [Required]
        public string type { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public string quote_currency { get; set; }
        [Required]
        public double quote_currency_amount { get; set; }

        public bool Equals(RecordModel other)
        {
            return (
                this.type == other.type &&
                this.status == other.status &&
                this.quote_currency == other.quote_currency &&
                this.quote_currency_amount == other.quote_currency_amount
                );
        }
    }
}
