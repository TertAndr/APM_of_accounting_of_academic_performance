using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APM_of_accounting_of_academic_performance.Models;

namespace APM_of_accounting_of_academic_performance.Controllers
{
    public class Curriculum_in_the_specialtysController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных всех планов специальностей из БД
        /// </summary>
        /// <returns>
        /// Возвращает массив с планами специальностей
        /// </returns>
        public List<Curriculum_in_the_specialtys> GetCurriculum_in_the_specialtys()
        {
            return db.context.Curriculum_in_the_specialtys.ToList();
        }
        /// <summary>
        /// Получение данных о определенных планах специальностей 
        /// </summary>
        /// <param name="selectedYears">Выбранный год </param>
        /// <returns>
        /// Возвращает лист с данными о определенных планах специальностей 
        /// </returns>
        public List<Curriculum_in_the_specialtys> GetCurriculum_in_the_specialtysYears(int selectedYears)
        {
            try
            {
                if (selectedYears > -1)
                {
                    return db.context.Curriculum_in_the_specialtys.Where(x => x.year_of_study == selectedYears).ToList();
                }
                else
                {
                    throw new Exception("Произошла ошибка при выводе, год<0");
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка при выводе");
            }
        }
        /// <summary>
        /// Получение данных о определенных планах специальностей 
        /// </summary>
        /// <param name="selectedSpecial">Выбранная специальность </param>
        /// <returns>
        /// Возвращает лист с данными о определенных планах специальностей 
        /// </returns>
        public List<Curriculum_in_the_specialtys> GetCurriculum_in_the_specialtysSpecialtys(int selectedSpecial)
        {
            try
            {
                if (selectedSpecial > 0)
                {
                    return db.context.Curriculum_in_the_specialtys.Where(x => x.id_specialty == selectedSpecial).ToList();
                }
                else
                {
                    throw new Exception("Произошла ошибка при выводе, год<0");
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка при выводе");
            }
        } 
        
        /// <summary>
        /// Добавление новой специальности
        /// </summary>
        /// <param name="specialtysId"> id специальности</param>
        /// <param name="sudjectsId">id предмета</param>
        /// <param name="currentAllhours"> Всего выделенно часов</param>
        /// <param name="currentSudjectHoursTheory">Выделенно часов на теорию</param>
        ///  <param name="currentSudjectHoursPractice">Выделенно часов на практику</param>
        ///  <param name="currentSudjectHourscourseDesign">Выделенно часов на курсовой проект</param>
        ///  <param name="currentSemesterNumbers">Номер семестра</param>
        ///  <param name="currentYearOfStudy">Год обучения</param>
        ///  <param name="currentCode">Код учебного плана</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении!") - если произошла ошибка
        /// </returns>

        public bool AddNewCurriculums(int specialtysId, int sudjectsId, int currentAllhours, int currentSudjectHoursTheory, int currentSudjectHoursPractice,
            int currentSudjectHourscourseDesign, int currentSemesterNumbers, int currentYearOfStudy, string currentCode)
        {
            try
            {

                Curriculum_in_the_specialtys newCurriculums = new Curriculum_in_the_specialtys
                {
                    id_specialty = specialtysId,
                    id_sudject = sudjectsId,
                    all_hours = currentAllhours,
                    sudject_hours_theory = currentSudjectHoursTheory,
                    sudject_hours_practice = currentSudjectHoursPractice,
                    sudject_hours_course_design = currentSudjectHourscourseDesign,
                    semester_numbers = currentSemesterNumbers,
                    year_of_study = currentYearOfStudy,
                    code = currentCode,
    

                };
                db.context.Curriculum_in_the_specialtys.Add(newCurriculums);
                db.context.SaveChanges();

                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении!");
            }
        }
        /// <summary>
        /// Обновление специальности
        /// </summary>
        /// <param name="specialtysId"> id специальности</param>
        /// <param name="sudjectsId">id предмета</param>
        /// <param name="currentAllhours"> Всего выделенно часов</param>
        /// <param name="currentSudjectHoursTheory">Выделенно часов на теорию</param>
        ///  <param name="currentSudjectHoursPractice">Выделенно часов на практику</param>
        ///  <param name="currentSudjectHourscourseDesign">Выделенно часов на курсовой проект</param>
        ///  <param name="currentSemesterNumbers">Номер семестра</param>
        ///  <param name="currentYearOfStudy">Год обучения</param>
        ///  <param name="currentCode">Код учебного плана</param>
        ///  <param name="curriculum">Старые данные учебного плана</param>
        /// <returns>
        /// true - если обновление прошло успешно
        /// Exception("Произошла ошибка при обновлении!") - если произошла ошибка
        /// </returns>
        public bool UpdateCurriculums(int specialtysId, int sudjectsId, int currentAllhours, int currentSudjectHoursTheory, int currentSudjectHoursPractice,
            int currentSudjectHourscourseDesign, int currentSemesterNumbers, int currentYearOfStudy, string currentCode, Curriculum_in_the_specialtys curriculum)
        {
            try
            {

                Curriculum_in_the_specialtys editedCurriculums = db.context.Curriculum_in_the_specialtys.Where(x => x.id_curriculum_in_the_specialty == curriculum.id_curriculum_in_the_specialty).FirstOrDefault();
            editedCurriculums.id_specialty = specialtysId;
            editedCurriculums.id_sudject = sudjectsId;
            editedCurriculums.all_hours = currentAllhours;
            editedCurriculums.sudject_hours_theory = currentSudjectHoursTheory;
            editedCurriculums.sudject_hours_practice = currentSudjectHoursPractice;
            editedCurriculums.sudject_hours_course_design = currentSudjectHourscourseDesign;
            editedCurriculums.semester_numbers = currentSemesterNumbers;
            editedCurriculums.year_of_study = currentYearOfStudy;
            editedCurriculums.code = currentCode;
            db.context.SaveChanges();
            return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при обновлении!");
            }
        }

        public bool DropCurriculum_in_the_specialtys(Curriculum_in_the_specialtys item)
        {
            try
            {
                Curriculum_in_the_specialtys curentCurriculum = db.context.Curriculum_in_the_specialtys.Where(x => x.id_curriculum_in_the_specialty == item.id_curriculum_in_the_specialty).FirstOrDefault();
            db.context.Curriculum_in_the_specialtys.Remove(curentCurriculum);
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
