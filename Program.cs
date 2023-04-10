using System.Linq.Expressions;
using System.Reflection;
using TurkcellHighSchoolManagerSystem.Database;
using TurkcellHighSchoolManagerSystem.Database.Abstract;
using TurkcellHighSchoolManagerSystem.Database.Concrete;
using TurkcellHighSchoolManagerSystem.Manager.Abstract;
using TurkcellHighSchoolManagerSystem.Manager.Concrete;
using TurkcellHighSchoolManagerSystem.Manager.Rules;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Details;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem
{
    internal class Program
    {
        static IClassManager classManager;
        static IStudentManager studentManager;
        static ITeacherManager teacherManager;
    
        static void Main(string[] args)
        {
            IStudentDal studentDal = new StudentDal(Data.students);
            ITeacherDal teacherDal = new TeacherDal(Data.teachers);
            IClassroomDal classroomDal = new ClassroomDal(Data.Classrooms);
    
            studentManager = new StudentManager(studentDal);
            teacherManager = new TeacherManager(teacherDal);
             
            Console.WriteLine("demo veri eklensin mi??");
            Console.WriteLine("2 sınıf, 2 öğretmen, 8 öğrenci");
            Console.WriteLine("lütfen rakam giriniz");
            Console.WriteLine("1) evet ");
            Console.WriteLine("2) hayır ");
            int demo = Convert.ToInt16(Console.ReadLine());
            if (demo == 1)
            {
                Data.DemoDataAdd();
                classManager = new ClassRoomManager(classroomDal);
                var result = classManager.GetDetails(1);
                if (result.IsSuccess)
                {
                    var item = result.Data;
                    Console.WriteLine($"sınıf {item.Name}\töğretmen {item.Teacher?.FirstName} {item.Teacher?.LastName}\t öğrenci sayısı {item.Students?.Count}");
                    item.Students.ForEach(s => Console.WriteLine($"{s.Number} {s.FirstName} {s.LastName}"));
                }
            }
            else
            {
                classManager = new ClassRoomManager(classroomDal);
            }

            int i;
            while (true)
            {
                Console.WriteLine("işlem seçiniz (sayı ile)");
                Console.WriteLine("sınıf işlemleri ");
                Console.WriteLine("1) sınıf ekle");
                Console.WriteLine("2) sınıfları listele");
                Console.WriteLine("3) id ile sınıf bilgisi getir");
                Console.WriteLine("4) Sınıf detayları");
                Console.WriteLine("5) Sınıf adını güncelle");
                Console.WriteLine("6) Sınıf sil");
                Console.WriteLine("=============================================================================================================");
                Console.WriteLine("öğretmen işlemleri");
                Console.WriteLine("7) id ile öğretmen ara");
                Console.WriteLine("8) öğretmen ekle");
                Console.WriteLine("9) öğretmenleri listele");
                Console.WriteLine("10) öğretmen güncelle");
                Console.WriteLine("11) Öğretmen sil");
                Console.WriteLine("12) 2 sınıfın öğretmenlerini değiştir");
                Console.WriteLine("13) sınıfındaki öğrencilere ödev gönder");
                Console.WriteLine("=============================================================================================================");
                Console.WriteLine("öğrenci işlemleri");
                Console.WriteLine("14) id ile öğrenci ara");
                Console.WriteLine("15) bütün öğrencileri listele");
                Console.WriteLine("16) öğrenci ekle");
                Console.WriteLine("17) öğrenci güncelle");
                Console.WriteLine("18) öğrenci sil");
                Console.WriteLine("19) ödev yap");
                Console.WriteLine("20) öğrenci arama");
                Console.WriteLine("=============================================================================================================");
                i = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (i)
                {
                    case 1:
                        AddClass();
                        break;
                    case 2:
                        GetAllClass(); break;

                    case 3:
                        GetClassId();
                        break;
                    case 4:
                        GetClassDetails();
                        break;
                    case 5:
                        UpdateClass();
                        break;
                    case 6:
                        DeleteClass();
                        break;
                    case 7:
                        GetTeacher();
                        break;
                    case 8:
                        AddTeacher();
                        break;
                    case 9:
                        GetAllTeacher();
                        break;
                    case 10:
                        UpdateTeacher();
                        break;
                    case 11:
                        TeacherDelete();
                        break;
                    case 12:
                        ReplaceTeacher();
                        break;
                    case 13:
                        AddHomework();
                        break;
                    case 14:
                        GetStudent();
                        break;
                    case 15:
                        GetAllStudent();
                        break;
                    case 16:
                        AddStudent();
                        break;
                    case 17:
                        UpdateStudent();
                        break;
                    case 18:
                        StudentDelete();
                        break;
                    case 19:
                        DoHomework();
                        break;
                    case 20:
                        StudentDetails();
                        break;
                    default:
                        continue;
                }
            }
        }

        static void AddClass()
        {
            Console.Write("sınıf ismi giriniz ");
            string name = Console.ReadLine();
            ClassRoom classRoom = new ClassRoom(name);
            var result = classManager.Add(classRoom);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }

        static void GetAllClass()
        {
            var data = classManager.GetAll();
            if (data.IsSuccess)
            {
                var items = data.Data;
                items.ForEach(item => { Console.WriteLine($"{item.ClassId} => {item.Name}"); });
            }
            else
            {
                Console.WriteLine("veri yok");
            }
            Console.WriteLine();
        }
        static void GetClassId()
        {
            Console.Write("id giriniz ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = classManager.GetById(id);
            if (result.IsSuccess)
            {
                var item = result.Data;
                Console.WriteLine(item.Name);
                Console.WriteLine(item.ClassId);
            }
        }
        static void GetClassDetails()
        {
            Console.Write("id giriniz ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = classManager.GetDetails(id);
            if (result.IsSuccess)
            {
                var item = result.Data;
                Console.WriteLine($"sınıf {item.Name}\töğretmen {item.Teacher?.FirstName} {item.Teacher?.LastName}\t öğrenci sayısı {item.Students?.Count}");
                item.Students.ForEach(s => Console.WriteLine($"{s.Number} {s.FirstName} {s.LastName}"));
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine();
        }

        static void UpdateClass()
        {
            Console.Write("id girin ");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.Write("yeni isim girin ");
            string name = Console.ReadLine();
            ClassRoom room = new ClassRoom(name);
            room.ClassId = i;
            var result = classManager.Update(room);
            Console.WriteLine($"{result.Message} \n\r");
        }
        static void DeleteClass()
        {
            GetAllClass();
            Console.Write("id girin ");
            int i = Convert.ToInt32(Console.ReadLine());
            var result = classManager.Delete(i);
            Console.WriteLine($"{result.Message} \n\r");

        }

        static void GetTeacher()
        {
            Console.Write("id girin ");
            int i = Convert.ToInt32(Console.ReadLine());
            var result = teacherManager.GetById(i);
            if (result.IsSuccess)
            {
                var item = result.Data;
                Console.WriteLine($"isim {item.FirstName}");
                Console.WriteLine($"soy isim {item.LastName}");
                Console.WriteLine($"numarası {item.Number}");
                Console.WriteLine($"sınıfı id'si {item.ClassId}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine();
        }
        static void AddTeacher()
        {
            Console.Write("isim girin ");
            string name = Console.ReadLine();
            Console.Write("soy isim girin ");
            string lastname = Console.ReadLine();
            Console.Write("öğretmen numarası girin ");
            short number = Convert.ToInt16(Console.ReadLine());
            Console.Write("sınıf idsi girin ");
            int classId = Convert.ToInt32(Console.ReadLine());
            Teacher teacher = new Teacher(name, lastname, number, classId);
            var result = teacherManager.Add(teacher);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }
        static void GetAllTeacher()
        {
            var data = teacherManager.GetAll();
            if (data.IsSuccess)
            {
                data.Data.ForEach(items => { Console.WriteLine($"{items.FirstName} {items.LastName}\n\rnumara {items.Number}\n\rsınıf {items.ClassId}\n\r--------------------"); });
            }
            else
            {
                Console.WriteLine(data.Message);
            }
            Console.WriteLine();
        }

        static void UpdateTeacher()
        {
            Console.Write("isim girin ");
            string name = Console.ReadLine();
            Console.Write("soy isim girin ");
            string lastname = Console.ReadLine();
            Console.Write("verileri güncellenecek öğretmenin numarasını giriniz (öğretmen idsi geçersiz ise işlem yapılmaz, hata alınmaz) ");
            short number = Convert.ToInt16(Console.ReadLine());
            Console.Write("sınıf idsi girin (sınıfda öğretmen olmamalı. sınıfta öğretmen var ise Öğretmenleri değiştir sekmesine gidin) ");
            int classId = Convert.ToInt32(Console.ReadLine());
            Teacher teacher = new Teacher(name, lastname, number, classId);
            var result = teacherManager.Update(teacher);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }
        static void TeacherDelete()
        {
            Console.Write("id girin ");
            int i = Convert.ToInt32(Console.ReadLine());
            var result = teacherManager.Delete(i);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }

        static void ReplaceTeacher()
        {
            Console.WriteLine("1. öğretmenin idsi ");
            int i = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("2. öğretmenin idsi ");
            int j = Convert.ToInt16(Console.ReadLine());

            var result = teacherManager.ReplaceTeacher(i, j);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }

        static void AddHomework()
        {
            Console.Write("sınıf idsi girin ");
            int i = Convert.ToInt16(Console.ReadLine());
            var result = studentManager.AddHomework(i);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }

        static void GetStudent()
        {
            Console.Write("öğrenci id ");
            int i = Convert.ToInt32(Console.ReadLine());
            var result = studentManager.GetById(i);
            if (result.IsSuccess)
            {
                var item = result.Data;
                Console.WriteLine(item.FirstName);
                Console.WriteLine(item.LastName);
                Console.WriteLine($"sınıf idsi {item.ClassId}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine();

        }

        static void GetAllStudent()
        {
            var data = studentManager.GetAll();
            if (data.IsSuccess)
            {
                var items = data.Data;
                items.ForEach(i => { Console.WriteLine($"{i.FirstName} {i.LastName}\t numara {i.Number} sınıf idsi {i.ClassId}"); });
            }
            else
            {
                Console.WriteLine(data.Message);
            }
            Console.WriteLine();
        }

        static void AddStudent()
        {
            Console.Write("isim girin ");
            string name = Console.ReadLine();
            Console.Write("soy isim girin ");
            string lastname = Console.ReadLine();
            Console.Write("öğrenci numarası girin ");
            short number = Convert.ToInt16(Console.ReadLine());
            Console.Write("sınıf idsi girin ");
            int classId = Convert.ToInt32(Console.ReadLine());
            Student teacher = new Student(name, lastname, number, classId);
            var result = studentManager.Add(teacher);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }
        static void UpdateStudent()
        {
            Console.Write("öğrenci numarası girin ");
            short number = Convert.ToInt16(Console.ReadLine());

            Console.Write("isim girin ");
            string name = Console.ReadLine();
            Console.Write("soy isim girin ");
            string lastname = Console.ReadLine();

            Console.Write("sınıf idsi girin ");
            int classId = Convert.ToInt32(Console.ReadLine());
            Student student = new Student(name, lastname, number, classId);
            var result = studentManager.Update(student);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }

        static void StudentDelete()
        {
            GetAllStudent();
            Console.Write("id girin ");
            int i = Convert.ToInt32(Console.ReadLine());
            var result = studentManager.Delete(i);
            Console.WriteLine($"{result.Message} \n\r");
        }

        static void DoHomework()
        {
            Console.Write("öğrenci numaranızı girin ");
            int i = Convert.ToInt16(Console.ReadLine());
            var result = studentManager.DoHomework(i);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }


        static void StudentDetails()
        {
            Console.Write("detaylarını görmek istediiniz öğrencinin (numarasını || ismini || soy ismini) giriniz ");
            
            string filter = Console.ReadLine();
            IDataResult<List<StudentDetails>> data;
            if (int.TryParse(filter, out int i))
            {
                data = studentManager.StudentDetailsSearch(i);
            }
            else
            {

                data = studentManager.StudentDetailsSearch(filter);  
            }

            if (data.IsSuccess)
            {
                var items = data.Data;
                foreach (var item in items)
                {
                    Console.WriteLine($"numara {item.Number} isim {item.Name} soy isim {item.lastName}\n\röğretmeni {item.Teacher?.FirstName} {item.Teacher?.LastName}\n\rsınıf {item.ClassId} => {item.ClassRoom.Name} ");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("-----------------------------------------------");
                }
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("-----------------------------------------------");

            }
        }

    }
}