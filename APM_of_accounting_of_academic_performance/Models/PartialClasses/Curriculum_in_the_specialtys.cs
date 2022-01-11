using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APM_of_accounting_of_academic_performance.Models
{
   public partial class Curriculum_in_the_specialtys
    {
        public string specialtystInfo => $"{code }  /  {Specialtys.specialty_name}  /  {Sudjects.sudject_name}   /   {year_of_study} год";
    }
}
