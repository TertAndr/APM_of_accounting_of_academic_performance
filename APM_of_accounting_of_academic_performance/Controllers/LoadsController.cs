using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APM_of_accounting_of_academic_performance.Models;

namespace APM_of_accounting_of_academic_performance.Controllers
{
   public class LoadsController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных о нагрузках
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о нагрузках
        /// </returns>
        public List<Loads> GetLoads()
        {
            return db.context.Loads.ToList();
        }
        public List<Loads> GetLoadsAdmin(int Id_Teasher)
        {
            return db.context.Loads.Where(x => x.Teachers.id_teacher == Id_Teasher).ToList();
        }
        /// <summary>
        /// Получение данных о нагрузках
        /// </summary>
        /// <param name="Id_Profile"> id конкретного пользователя</param>
        /// <returns>
        /// Возвращает лист с данными о нагрузках
        /// </returns>
        public List<Loads> GetLoadsUser(int Id_Profile)
        {
            return db.context.Loads.Where(x => x.Teachers.Users.id_user == Id_Profile).ToList();
        }
        /// <summary>
        /// Получение данных о нагрузках
        /// </summary>
        /// <param name="selectedDate"> Дата</param>
        /// <returns>
        /// Возвращает лист с данными о нагрузках
        /// </returns>
        public List<Loads> GetLoadsDate(DateTime selectedDate)
        {
            return db.context.Loads.Where(x => x.date == selectedDate).ToList();
        }
        /// <summary>
        /// Получение данных о нагрузках
        /// </summary>
        /// <param name="Id_Profile"> id конкретного пользователя</param>
        /// <param name="selectedDate"> Дата</param>
        /// <returns>
        /// Возвращает лист с данными о нагрузках
        /// </returns>
        public List<Loads> GetLoadsDateUser(DateTime selectedDate, int Id_Profile)
        {
            return db.context.Loads.Where(x => x.date == selectedDate && x.Teachers.id_teacher == Id_Profile).ToList();
        }

        public List<Loads> GetLoadsDateAdmin(DateTime selectedDate, int Id_Teasher)
        {
            return db.context.Loads.Where(x => x.date == selectedDate && x.Teachers.id_teacher == Id_Teasher).ToList();
        }

        /// <summary>
        /// Добавление новой нагрузки
        /// </summary>
        /// <param name="teasherId"> id преподавателя</param>
        /// <param name="groupId"> id группы</param>
        /// <param name="specialityId">id специальности</param>
        /// <param name="dateLoud"> Дата</param>
        /// <param name="hours">Кол-во часов</param>
        /// <param name="clockType">Тип часов</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении новой нагрузки") - если произошла ошибка
        /// </returns>
        public bool AddNewLouds(int teasherId, int groupId, int specialityId,DateTime dateLoud, int hours ,int clockType)
        {
            try
            {
                Loads newLouds = new Loads
                {
                    id_teacher = teasherId,
                    id_group = groupId,
                    id_curriculum_in_the_specialty = specialityId,
                    date = dateLoud,
                    loud_hours = hours,
                    id_type_of_clock = clockType
                };           
                db.context.Loads.Add(newLouds);
                db.context.SaveChanges();

                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении новой нагрузки");
            }
        }
        /// <summary>
        /// Обновление нагрузки
        /// </summary>
        /// <param name="teasherId"> id преподавателя</param>
        /// <param name="groupId"> id группы</param>
        /// <param name="specialityId">id специальности</param>
        /// <param name="dateLoud"> Дата</param>
        /// <param name="hours">Кол-во часов</param>
        /// <param name="clockType">Тип часов</param>
        /// <param name="loaads">Старые данные нагрузки</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при обновлении нагрузки") - если произошла ошибка
        /// </returns>
        public bool UpdateLouds(int teasherId, int groupId, int specialityId, DateTime dateLoud, int hours, int clockType, Loads loaads)
        {
           

            Loads editedLouds = db.context.Loads.Where(x => x.id_load == loaads.id_load).FirstOrDefault();
            editedLouds.id_teacher = teasherId;
            editedLouds.id_group = groupId;
            editedLouds.id_curriculum_in_the_specialty = specialityId;
            editedLouds.date = dateLoud;
            editedLouds.loud_hours = hours;
            editedLouds.id_type_of_clock = clockType;
            db.context.SaveChanges();
            return true;
        
        }
        public bool DropLoud(Loads item)
        {

            Loads curentLouds = db.context.Loads.Where(x => x.id_load == item.id_load).FirstOrDefault();
            db.context.Loads.Remove(curentLouds);
            db.context.SaveChanges();
            return true;
        }


        public int AllLoudsHours(int teashId) 
        { 
                int hoursSumm = 0;
                foreach (Loads item in GetLoadsAdmin(teashId))
                {
                    hoursSumm += item.loud_hours;
                }

                return hoursSumm;
        }

        public int BudjLoudsHours(int teashId)
        {
            int hoursSumm = 0;
            foreach (Loads item in GetLoadsAdmin(teashId))
            {
                if(item.id_type_of_clock == 1)
                {
                    hoursSumm += item.loud_hours;
                }
                else
                {

                }
            }

            return hoursSumm;
        }

        public int DonLoudsHours(int teashId)
        {
            int hoursSumm = 0;
            foreach (Loads item in GetLoadsAdmin(teashId))
            {
                if (item.id_type_of_clock == 2)
                {
                    hoursSumm += item.loud_hours;
                }
                else
                {

                }              
            }
            return hoursSumm;
        }

    }
}

