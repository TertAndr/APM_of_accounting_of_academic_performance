using APM_of_accounting_of_academic_performance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APM_of_accounting_of_academic_performance.Controllers
{
  public class GroupsController
 {   
       Core db = new Core();
        /// <summary>
        /// Получение данных всех групп из БД
        /// </summary>
        /// <returns> 
        /// Возвращает массив с данными групп        
        ///  </returns>
        public List<Groups> GetGroups()
        {
            List<Groups> groupsList = db.context.Groups.ToList();        
           
            return groupsList;
        }

        /// <summary>
        /// Добавление новой группы
        /// </summary>
        /// <param name="groupName">Называние группы</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении!") - если произошла ошибка
        /// </returns>
        public bool AddNewGroups(string groupName )
        {
            try
            {
                if(groupName != null)
                {
                    Groups newGroups = new Groups
                    {
                        groups_name = groupName,
                    };
                    db.context.Groups.Add(newGroups);
                    db.context.SaveChanges();

                    return true;
                }
                else
                {
                    throw new Exception("Поле не заполнено!");
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении!");
            }
        }

        /// <summary>
        /// Обновление информации о группе
        /// </summary>
        /// <param name="groupName">Называние группы</param>
        /// <param name="groupp">Старая информация о группе</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при обновлении!") - если произошла ошибка
        /// </returns>
        public bool UpdateGroups(string groupName, Groups groupp)
        {
            try
            {
                Groups editGroup = db.context.Groups.Where(x => x.id_group == groupp.id_group).FirstOrDefault();
                editGroup.groups_name = groupName;     

            db.context.SaveChanges();
            return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при обновлении!");
            }
        }

        public bool DropGroups(Groups item)
        {
            try
            {
                Groups curentsGroups = db.context.Groups.Where(x => x.id_group == item.id_group).FirstOrDefault();
            db.context.Groups.Remove(curentsGroups);
            db.context.SaveChanges();
            return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при удалении!");
            }
        }
    }
        
}
