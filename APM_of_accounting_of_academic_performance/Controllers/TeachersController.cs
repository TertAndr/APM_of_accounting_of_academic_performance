using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APM_of_accounting_of_academic_performance.Models;
using APM_of_accounting_of_academic_performance.Controllers;

namespace APM_of_accounting_of_academic_performance.Controllers
{
    public class TeachersController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных о преподавателях
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о преподавателях
        /// </returns>
        public List<Teachers> GetTeachers()
        {
            return db.context.Teachers.ToList();
        }
        /// <summary>
        /// Получение данных о конкретных назначенных преподавателях
        /// </summary>
        /// <param name="Id_Profile"> id конкретного пользователя</param>
        /// <returns>
        /// Возвращает лист с данными о конкретных назначенных преподавателях
        /// </returns>
        public Teachers GetTeachersIdProfile(int Id_Profile)
        {
            return GetTeachers().Where(x => x.id_user == Id_Profile).FirstOrDefault();
        }



        /// <summary>
        /// Добавление нового преподавателя
        /// </summary>
        /// <param name="teacherFname">Фамилия преподавателя</param>
        /// <param name="teacherName">Имя преподавателя</param>
        /// <param name="teacherPatronomic">Отчество преподавателя</param>
        /// <param name="avatarImage">Фотография преподавателя</param>
        /// <param name="idUser"> id пользователя</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении нового преподавателя") - если произошла ошибка
        /// </returns>
        public bool AddNewTeasher(string teacherFname, string teacherName, string teacherPatronomic, byte[] avatarImage, int idUser)
        {
            try
            {
                if (teacherFname != null && teacherName != null && teacherPatronomic != null && idUser >-1)
                {
                    Teachers newTeacher = new Teachers
                {
                    teacher_fname = teacherFname,
                    teacher_name = teacherName,
                    teacher_patronomic = teacherPatronomic,
                    id_user = idUser,
                };
                if (avatarImage != null)
                {
                    newTeacher.teacher_photo = avatarImage;
                }
                db.context.Teachers.Add(newTeacher);
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
                throw new Exception("Произошла ошибка при добавлении нового преподавателя");
            }
        }
        /// <summary>
        /// Обновление преподавателя
        /// </summary>
        /// <param name="teacherFname">Фамилия преподавателя</param>
        /// <param name="teacherName">Имя преподавателя</param>
        /// <param name="teacherPatronomic">Отчество преподавателя</param>
        /// <param name="avatarImage">Фотография преподавателя</param>
        /// <param name="teacheer"> Старые данные преподавателя</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при обновлении преподавателя") - если произошла ошибка
        /// </returns>
        public bool UpdateTeasher(string teacherFname, string teacherName, string teacherPatronomic, byte[] avatarImage,  Teachers teacheer)
        {
            try
            {

                if (teacherFname != null && teacherName != null && teacherPatronomic != null)
                {
                    Teachers editedTeasher = db.context.Teachers.Where(x => x.id_teacher == teacheer.id_teacher).FirstOrDefault();
                editedTeasher.teacher_fname = teacherFname;
                editedTeasher.teacher_name = teacherName;
                editedTeasher.teacher_patronomic = teacherPatronomic;
                if (avatarImage != null)
                {
                    editedTeasher.teacher_photo = avatarImage;
                }

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
                throw new Exception("Произошла ошибка при обновлении преподавателя");
            }
        }
        public bool DropTeachers(Teachers item)
        {
            try
            {
                Teachers curentTeasher = db.context.Teachers.Where(x => x.id_teacher == item.id_teacher).FirstOrDefault();
            Users currentUsers = db.context.Users.Where(x => x.id_user == item.id_user).FirstOrDefault();
            db.context.Teachers.Remove(curentTeasher);         
            db.context.Users.Remove(currentUsers);
            db.context.SaveChanges();
            return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при обновлении преподавателя");
            }
        }
    }
}