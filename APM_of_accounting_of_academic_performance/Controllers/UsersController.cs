using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APM_of_accounting_of_academic_performance.Models;

namespace APM_of_accounting_of_academic_performance.Controllers
{
   public class UsersController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных всех пользователей из БД
        /// </summary>
        /// <returns>
        /// Возвращает массив с данными пользователей
        /// </returns>
        public List<Users> GetUsers()
        {
            List<Users> userList = db.context.Users.ToList();
            return userList;
        }
        /// <summary>
        /// Авторизация пользователя в приложении
        /// </summary>
        /// <param name="userLogin"> Входная строка содержащая логин пользователя </param>
        /// <param name="userPassword"> Входная строка содержащая пароль пользователя </param>
        /// <returns>
        /// Возвращает роль авторизуемого пользователя
        /// </returns>
        public int UserAuth(string userLogin, string userPassword)
        {
            List<Users> currentUser = GetUsers().Where(x => x.user_login == userLogin && x.user_password == userPassword).ToList();
            if (currentUser.Count() != 0)
            {
                ProfileClass.Id_Profile = currentUser.First().id_user;
                return currentUser.First().id_role;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="userLogin">Логин пользователя</param>
        /// <param name="userPassword">Пароль пользователя</param>
        /// <param name="userRole">Роль пользователя</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении нового пользователя") - если произошла ошибка
        /// </returns>
        public int AddNewUser(string userLogin, string userPassword, int userRole )
        {
            try
            {
                if (userLogin != null && userPassword != null && userRole >-1)
                {
                    Users newUser = new Users
                {
                    user_login = userLogin,
                    user_password = userPassword,
                    id_role = userRole
                };
                
                db.context.Users.Add(newUser);
                db.context.SaveChanges();

                return newUser.id_user;
                }
                else
                {
                    throw new Exception("Поля не заполненны");
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении нового пользователя");
            }
        }
        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="userLogin">Логин пользователя</param>
        /// <param name="userPassword">Пароль пользователя</param>
        /// <param name="userRole">Роль пользователя</param>
        /// <param name="teacheer">Старая информация о пользователе</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при обновлении пользователя") - если произошла ошибка
        /// </returns>
        public bool UpdateUser(string userLogin, string userPassword, int userRole, Teachers teacheer)
        {
            try
            {
                Teachers editedTeasher = db.context.Teachers.Where(x => x.id_user == teacheer.id_user).FirstOrDefault();
                editedTeasher.Users.user_login = userLogin;
                editedTeasher.Users.user_password = userPassword;              
                editedTeasher.Users.id_role= userRole;
                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при обновлении пользователя");
            }
        }
        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="userLogin">Логин пользователя</param>
        /// <param name="userPassword">Пароль пользователя</param>
        /// <param name="teacheer">Старая информация о пользователе</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при обновлении пользователя") - если произошла ошибка
        /// </returns>
        public bool UpdateAutorizUser(string userLogin, string userPassword,  Teachers teacheer)
        {
            try
            {
                Teachers editedTeasher = db.context.Teachers.Where(x => x.id_user == teacheer.id_user).FirstOrDefault();
            editedTeasher.Users.user_login = userLogin;
            editedTeasher.Users.user_password = userPassword;
            db.context.SaveChanges();
            return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при обновлении пользователя");
            }
        }
      
        
    }
}
