using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Response
{
    public class MRes_StudentMapsClass
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public int BehaviorScore { get; set; }

        public int AverageTestScore { get; set; }

    }
}
