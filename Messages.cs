using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellHighSchoolManagerSystem
{
    public static class Messages
    {
        #region Student
        public static readonly string AddStudentSuccess = "öğrenci eklendi.";
        public static readonly string AddStudentError = "öğrenci eklenemedi.";
        public static readonly string UpdateStudentSuccess = "öğrenci bilgileri güncellendi";
        
        public static readonly string UpdateStudentError = "öğrenci güncellenemedi";
        public static readonly string StudentHomeworkSuccess = "ödev teslim edildi";
        public static readonly string StudentHomeworkError = "ödev teslim eilemedi";



        public static readonly string StudentNotFound = "öğrenci bulunamadı";



        #endregion

        #region Teacher
        public static readonly string AddTeacherSuccess = "Öğretmen eklendi";
        public static readonly string UpdateTeacherSuccess = "Öğretmen bilgileri güncellendi";
        public static readonly string ReplaceTeacherSuccess = "Öğretmenlerin sınıfları değiştirildi";
        public static readonly string ReplaceTeacherError = "Öğretmenlerin sınıfları değiştirilemedi  öğretmen numaralarını kontrol ediniz";
        public static readonly string AddHomeworkSuccess = " öğrenciye ödev verildi";
        public static readonly string AddHomeworkError = "ödevler verilemedi";

        public static readonly string UpdateTeacherError = "Öğretmen güncellenemedi";
        public static readonly string AddTeacherError = "Öğretmen eklenemedi. öğretmen numarası ve sınıf numarasını kontrol ediniz. Boş sınıf yoksa öğretmen ekleyemezsiniz";

        public static readonly string TeacherDeleteError = "öğretmen silinemedi öğretmen numarasını kontrol ediniz";
        public static readonly string TeacherDeleteSuccess = "öğretmen silindi"; 
        #endregion
         

        #region ClassRoom
        public static readonly string AddClassSuccess = "sınıf eklendi";
        public static readonly string AddClassError = "sınıf eklenemedi";
        public static readonly string ClassDeleteError = "sınıfda öğrenci/öğretmen vardır";
        public static readonly string ClassDeleteSuccess = "sınıf silindi";
        public static readonly string UpdateClassSuccess = "sınıf bilgileri güncellendi";

        public static readonly string UpdateClassError = "sınıf bilgileri güncellenemedi";

        #endregion
    }
}
