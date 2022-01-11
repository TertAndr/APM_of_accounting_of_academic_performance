using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APM_of_accounting_of_academic_performance.Models;

namespace APM_of_accounting_of_academic_performance.Controllers
{
    public class RolesController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных о ролях
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о ролях
        /// </returns>
        public List<Roles> GetRoles()
        {
            return db.context.Roles.ToList();
        }
    }
}

