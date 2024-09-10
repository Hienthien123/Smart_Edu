using System;
using System.Collections.Generic;

namespace API_Sample.Data.Model;

public partial class TuitionTransaction
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

    public virtual Class Class { get; set; }

    public virtual Student Student { get; set; }
}
