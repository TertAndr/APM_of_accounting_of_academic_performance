using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APM_of_accounting_of_academic_performance.Models;

namespace APM_of_accounting_of_academic_performance.Controllers
{
   public class SpecialtysController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных всех специальностей из БД
        /// </summary>
        /// <returns>
        /// Возвращает массив с данными специальностей         
        ///  </returns>
        public List<Specialtys> GetSpecialtys()
        {
            List<Specialtys> specialtysList = db.context.Specialtys.ToList();

            return specialtysList;
        }
        /// <summary>
        /// Добавление новой специальности
        /// </summary>
        /// <param name="specialtysCode">Код специальности</param>
        /// <param name="specialtysName">Название специальности</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении!") - если произошла ошибка
        /// </returns
        public bool AddNewSpecialtys(string specialtysName, string specialtysCode)
        {
            try
            {
                if (specialtysName != null && specialtysCode != null)
                {
                    Specialtys newSpecialtys = new Specialtys
                {
                    specialty_code = specialtysCode,
                    specialty_name = specialtysName

                };
                db.context.Specialtys.Add(newSpecialtys);
                db.context.SaveChanges();
                return true;
                }
                else
                {
                    throw new Exception("Поля не заполненны");
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении!");
            }
        }

        /// <summary>
        /// Обновление специальности
        /// </summary>
        /// <param name="specialtysCode">Код специальности</param>
        /// <param name="specialtysName">Название специальности</param>
        /// <param name="specialtyssss">Старые данные специальности</param>
        /// <returns>
        /// true - если обновление прошло успешно
        /// Exception("Произошла ошибка при обновлении!") - если произошла ошибка
        /// </returns
        public bool UpdateSpecialtys(string specialtysName, string specialtysCode, Specialtys specialtyssss)
        {
            try
            {
                if (specialtysName != null && specialtysCode != null)
                {

                    Specialtys editSpecialty = db.context.Specialtys.Where(x => x.id_specialty == specialtyssss.id_specialty).FirstOrDefault();
            editSpecialty.specialty_name = specialtysName;
            editSpecialty.specialty_code = specialtysCode;

            db.context.SaveChanges();
            return true;
                }
                else
                {
                    throw new Exception("Поля не заполненны");
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка при обновлении!");
            }
        }
        public bool DropSpecialtys(Specialtys item)
        {
            try
            {

                Specialtys curentsSpecialtys = db.context.Specialtys.Where(x => x.id_specialty == item.id_specialty).FirstOrDefault();
            db.context.Specialtys.Remove(curentsSpecialtys);
            db.context.SaveChanges();
            return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при обновлении!");
            }
        }

    }
}
