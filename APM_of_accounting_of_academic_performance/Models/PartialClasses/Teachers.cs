using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APM_of_accounting_of_academic_performance.Models
{
    public partial class Teachers
    {
        public string TeacherFIO => $"{teacher_fname } {teacher_name} {teacher_patronomic}";
    }
}
