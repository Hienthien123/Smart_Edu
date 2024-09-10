using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Response
{
    public class MRes_Tuition
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double AmountOfMoney { get; set; }

        public string Note { get; set; }
    }
}
