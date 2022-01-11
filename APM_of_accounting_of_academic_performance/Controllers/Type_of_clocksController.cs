using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APM_of_accounting_of_academic_performance.Models;

namespace APM_of_accounting_of_academic_performance.Controllers
{
   public class Type_of_clocksController
    {

        Core db = new Core();
        /// <summary>
        /// Получение данных о типе часов
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о типе часов
        /// </returns>
        public List<Type_of_clocks> GetType_of_clocks()
        {
            return db.context.Type_of_clocks.ToList();
        }


    }
}