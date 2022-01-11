using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APMClassLibrary
{
  public  class StringCheckClass
    {
        Regex regex;
        Match match;


        /// <summary>
        /// Проверка правильности имени
        /// </summary>
        /// <param name="nameString">Имя</param>
        /// <returns>
        /// true - если имя верное
        /// false - если имя неверное
        /// </returns>
        public bool NameCheck(string nameString)
        {
            regex = new Regex(@"^[а-яА-Я\sa-zA-Z]{3,}$");
            match = regex.Match(nameString);
            if (match.Success)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Проверка правильности логина
        /// </summary>
        /// <param name="loginString">Логин</param>
        /// <returns>
        /// true - если логин верный
        /// false - если логин неверный
        /// </returns>
        public bool LoginCheck(string loginString)
        {
            regex = new Regex(@"^[^0-9]+[a-zA-Zа-яА-Я\W']{2,24}");
            match = regex.Match(loginString);
            if (match.Success)
                return true;
            else
                return false;
        }
       
        /// <summary>
        /// Проверка правильности пароля
        /// </summary>
        /// <param name="passwordString">Пароль</param>
        /// <returns>
        /// true - если пароль верный
        /// false - если пароль неверный
        /// </returns>
        public bool PasswordCheck(string passwordString)
        {
            regex = new Regex(@"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}");
            match = regex.Match(passwordString);
            if (match.Success)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Проверка правильности кодов
        /// </summary>
        /// <param name="codeString">Имя</param>
        /// <returns>
        /// true - если имя верное
        /// false - если имя неверное
        /// </returns>

    }
}
