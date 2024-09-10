using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Response
{
    public class MRes_Grade
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsSeniorGrade { get; set; }
    }
}
