using API_Sample.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Sample.Models.Response
{
    public class MRes_Subject : BaseModel.History
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }

        public string SubjectCode { get; set; }
    }
}
