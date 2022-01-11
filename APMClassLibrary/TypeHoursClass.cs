using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMClassLibrary
{
   public class TypeHoursClass
    {

        /// <summary>
        /// Определение является ли группа коммерческой
        /// </summary>
        /// <param name="groupName"> Название группы</param>
        /// <returns>
        /// 1-Если группа коммерческая
        /// 0-Если группа не коммерческая
        /// </returns>
        public static int TypeHours(string groupName)
        {
            string str = groupName;
            Console.WriteLine(groupName);
            if (str.EndsWith("К") || str.EndsWith("к"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
