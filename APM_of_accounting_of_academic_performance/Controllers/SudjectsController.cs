using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APM_of_accounting_of_academic_performance.Models;

namespace APM_of_accounting_of_academic_performance.Controllers
{
   public class SudjectsController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных всех предметов из БД
        /// </summary>
        /// <returns>
        /// Возвращает массив с данными предметов         
        ///  </returns>
        public List<Sudjects> GetSudjects()
        {
            List<Sudjects> subjList = db.context.Sudjects.ToList();

            return subjList;
        }
        /// <summary>
        /// Добавление нового предмета
        /// </summary>
        /// <param name="subjectsCode">Код предмета</param>
        /// <param name="subjectsName">Название предмета</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении!") - если произошла ошибка
        /// </returns
        public bool AddNewSubjects(string subjectsName, string subjectsCode)
        {
            try
            {
                if (subjectsName != null && subjectsCode != null)
                {
                    Sudjects newSudjects = new Sudjects
                {
                    sudject_code = subjectsCode,
                    sudject_name = subjectsName

                };
                db.context.Sudjects.Add(newSudjects);
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
        /// Обновление предмета
        /// </summary>
        /// <param name="subjectsCode">Код предмета</param>
        /// <param name="subjectsName">Название предмета</param>
        /// <param name="sudjectss">Старые данные предмета</param>
        /// <returns>
        /// true - если обновление прошло успешно
        /// Exception("Произошла ошибка при обновлении!") - если произошла ошибка
        /// </returns
        public bool UpdateSubjects(string subjectsName, string subjectsCode, Sudjects sudjectss)
        {
            try
            {
                if (subjectsName != null && subjectsCode != null)
                {
                    Sudjects editSudjects = db.context.Sudjects.Where(x => x.id_sudject == sudjectss.id_sudject).FirstOrDefault();
            editSudjects.sudject_name = subjectsName;
            editSudjects.sudject_code = subjectsCode;

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
        public bool DropSudjects(Sudjects item)
        {
            try
            {

            Sudjects curentsSudjects = db.context.Sudjects.Where(x => x.id_sudject == item.id_sudject).FirstOrDefault();
            db.context.Sudjects.Remove(curentsSudjects);
            db.context.SaveChanges();
            return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при Удалении!");
            }
        }



    }
}
