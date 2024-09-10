using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Response
{
    public class MRes_Class
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int ClassSize { get; set; }

        public int Credits { get; set; }

        public int? GradeId { get; set; }

        public int? SubjectId { get; set; }
    }
}
