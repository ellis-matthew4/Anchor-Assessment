using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor_Assessment.Models
{
    public class RecordModel: IEquatable<RecordModel>
    {
        public string type { get; set; }
        public string status { get; set; }
        public string quote_currency { get; set; }
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
