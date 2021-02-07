using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister
{
    class Program
    {
        static void Main(string[] args)
        {
        OMERFDEV:
            Console.WriteLine("1-Add New Student");
            Console.WriteLine("2-Update Student Info");
            Console.WriteLine("3-Delete Student Info");
            Console.WriteLine("4-Student For Change Classroom");
            Console.WriteLine("5-Exit");
            Console.Write("Choose number (1 2 3 4 5)");
            string choose = Console.ReadLine();
            string idno, classroom, class_way, student_way;

            switch (choose)
            {

                case "1":
                    Console.WriteLine("Please Enter Student Name:");
                    idno = Console.ReadLine();
                    Console.WriteLine("Please Enter Classroom Name:");
                    classroom = Console.ReadLine();
                    class_way = @"c:\SCHOOLBOOK\" + classroom;
                    student_way = @"c:\SCHOOLBOOK\" + classroom + "\\" + idno;

                    if (System.IO.Directory.Exists(class_way) == true && System.IO.Directory.Exists(student_way) == false)
                    {
                        System.IO.Directory.CreateDirectory(student_way);
                        string file_name = idno + ".txt";
                        string target_file_name = System.IO.Path.Combine(student_way, file_name);
                        System.IO.File.Create(target_file_name).Close();
                        Console.WriteLine("{0} Number Student Add {1} classroom.", idno, classroom);
                        string name_, surname_, gender_, telephone_, adress_;
                        Console.Write("Name:");
                        name_ = Console.ReadLine();
                        Console.Write("Surname:");
                        surname_ = Console.ReadLine();
                        Console.Write("Gender:");
                        gender_ = Console.ReadLine();
                        Console.Write("Telephone:");
                        telephone_ = Console.ReadLine();
                        Console.Write("Adress:");
                        adress_ = Console.ReadLine();
                        string[] student_ınfo = { "Öğrenci no:" + idno, "Name:" + name_, "Surname:" + surname_, "Gender:" + gender_, "Telephone:" + telephone_, "Adress:" + adress_ };
                        System.IO.File.WriteAllLines(@"c:\SCHOOLBOOK\" + classroom + "\\" + idno + "\\" + idno + ".txt", student_ınfo);
                        Console.WriteLine("All Info Completed.");
                        goto OMERFDEV;

                    }
                    {
                        if (System.IO.Directory.Exists(class_way) == false)
                        {
                            Console.Clear();
                            Console.WriteLine("There is no exist {0} classroom.", classroom);
                            goto OMERFDEV;
                        }
                        if (System.IO.Directory.Exists(student_way) == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Already {0} classroom has {1} student.", classroom, idno);
                            goto OMERFDEV;
                        }
                    }
                    break;

                //test
                case "2":
                    Console.WriteLine("Please Enter Student number:");
                    idno = Console.ReadLine();
                    System.IO.DirectoryInfo classroom_info = new System.IO.DirectoryInfo("c:\\SCHOOLBOOK");
                    System.IO.FileInfo[] files_ = classroom_info.GetFiles(idno + ".txt", System.IO.SearchOption.AllDirectories);
                    int sample = files_.Count();
                    if (sample > 0)
                    {
                        string studentfile_way = files_[0].DirectoryName;
                        string studentfile_name = idno + ".txt";
                        string studenttarget_way = System.IO.Path.Combine(studentfile_way, studentfile_name);
                        string[] student_ınfo = System.IO.File.ReadAllLines(studenttarget_way);
                        foreach (string line_ in student_ınfo)
                        {
                            Console.WriteLine(line_);
                        }
                        Console.ReadKey();


                    UPDATES:
                        Console.WriteLine("1-Telephone:");
                        Console.WriteLine("2-Adress:");
                        Console.WriteLine("Update information 1 or 2");
                        string update_menu = Console.ReadLine();
                        if (update_menu == "1")
                        {
                            Console.WriteLine("Please Enter Telephone Number:");
                            student_ınfo[4] = "Telephone:" + Console.ReadLine();
                            System.IO.File.WriteAllLines(studenttarget_way, student_ınfo);
                            Console.Write("Update Succesfull.");
                            foreach (string line_ in student_ınfo)
                            {
                                Console.WriteLine(line_);
                            }
                            Console.Write("Other Update Process: (yes or no) ");
                            string update_keep = Console.ReadLine();
                            if (update_keep == "yes")
                            {
                                goto UPDATES;
                            }

                            else if (update_keep == "no")
                            {
                                Console.Clear();
                                goto OMERFDEV;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Wrong Choose.");
                            }

                        }
                    }

                    break;

            }
        }
    }
}