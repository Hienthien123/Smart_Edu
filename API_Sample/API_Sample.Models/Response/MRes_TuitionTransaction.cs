using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Response
{
    public class MRes_TuitionTransaction
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public int ClassMonth { get; set; }

        public int ClassYear { get; set; }

        public string Note { get; set; }

        public double AmountOfMoney { get; set; }

        public string TransactionType { get; set; }

        public string TransactionCardNumber { get; set; }

        public string TransactionCardBrand { get; set; }

        public string TransactionBankCustomer { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
