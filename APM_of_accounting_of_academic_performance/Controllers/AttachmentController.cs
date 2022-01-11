using APM_of_accounting_of_academic_performance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APM_of_accounting_of_academic_performance.Controllers
{
    public class AttachmentController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных о  всех назначенных предметах
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о всех назначенных предметах
        /// </returns>
        public List<Attachment> GetAttachment()
        {
            return db.context.Attachment.ToList();
        }
        /// <summary>
        /// Получение данных о конкретных назначенных предметах
        /// </summary>
        /// <param name="Id_Profile"> id конкретного пользователя</param>
        /// <returns>
        /// Возвращает лист с данными о конкретных назначенных предметах
        /// </returns>
        public List<Attachment> GetAttachmentUser( int Id_Profile)
        {
            try
            {
                if (Id_Profile>0)
                {
                    List<Attachment> currentAttachment = GetAttachment().Where(x => x.id_teacher == Id_Profile).ToList();
                    return currentAttachment.ToList();
                }
                else
                {
                    throw new Exception("Произошла ошибка при выводе, id<0");
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка при выводе");
            }
        }
        /// <summary>
        /// Добавление нового назначенного предмета
        /// </summary>
        /// <param name="teasherId"> id конкретного пользователя</param>
        /// <param name="sudjectId"> id добавляемого предмета</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении!") - если произошла ошибка
        /// </returns>
        public bool AddNewSubject(int teasherId, int sudjectId)
        {
            try
            {
                Attachment newAttachment = new Attachment
            {
                id_teacher = teasherId,
                id_sudject = sudjectId,
            };

            db.context.Attachment.Add(newAttachment);
            db.context.SaveChanges();

            return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении!");
            }

        }
        /// <summary>
        /// Удаление назначенного педмета
        /// </summary>
        /// <param name="item">Строка информации о предметах</param>
        /// <returns>
        /// true - если удаление прошло успешно
        /// Exception("Произошла ошибка при удалении!") - если произошла ошибка
        /// </returns>
        public bool DropAttachment(Attachment item)
        {
            try
            {
    
            Attachment curentAttachment = db.context.Attachment.Where(x => x.id_attachment == item.id_attachment).FirstOrDefault();
            db.context.Attachment.Remove(curentAttachment);
            db.context.SaveChanges();
            return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при удалении!");
            }
        }

        public bool CheckSubjectDuplication(int sudjId, int teasherId)
        {
            try
            {
                int teashersSubject = GetAttachmentUser(teasherId).Where(x => x.id_sudject == sudjId).Count();
                if (teashersSubject == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception("Произошла ошибка при удалении!");
            }
        }
        
    }
}
