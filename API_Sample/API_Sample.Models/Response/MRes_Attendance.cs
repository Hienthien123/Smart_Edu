using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Response
{
    public class MRes_Attendance
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public DateTime ClassDate { get; set; }

        public int Status { get; set; }

        public string Note { get; set; }
    }
}
