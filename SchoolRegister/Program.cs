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
                    Console.WriteLine("Please Enter Student Number:");
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
                        string[] student_info = System.IO.File.ReadAllLines(studenttarget_way);
                        foreach (string line_ in student_info)
                        {
                            Console.WriteLine(line_);
                        }



                    UPDATES:
                        Console.Clear();
                        Console.WriteLine("1-Telephone");
                        Console.WriteLine("2-Adress");
                        Console.WriteLine("Update information 1 or 2");
                        string update_menu = Console.ReadLine();
                        if (update_menu == "1")
                        {
                            Console.WriteLine("Please Enter Telephone Number:");
                            student_info[4] = "Telephone:" + Console.ReadLine();
                            System.IO.File.WriteAllLines(studenttarget_way, student_info);
                            Console.Write("Update Succesfull.");
                            foreach (string line_ in student_info)
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
                                goto UPDATES;
                            }
                            
                        }

                        else if (update_menu == "2")
                        {
                            Console.WriteLine("Please Enter Adress:");
                            student_info[5] = "Adress:" + Console.ReadLine();
                            System.IO.File.WriteAllLines(studenttarget_way, student_info);
                            Console.Write("Update Succesfull.");

                            foreach (string line_ in student_info)
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
                                Console.WriteLine("Wrong Choose.");
                                goto UPDATES;
                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong Choose.");
                            goto OMERFDEV;
                        }
                    }

                    break;
                case "3":
                    Console.WriteLine("Please Enter Student Number:");
                    idno = Console.ReadLine();
                    System.IO.DirectoryInfo delete_file = new System.IO.DirectoryInfo("c:\\SCHOOLBOOK");
                    System.IO.FileInfo[] file_ = delete_file.GetFiles(idno + ".txt", System.IO.SearchOption.AllDirectories);
                    int find_file = file_.Count();
                    if (find_file>0)
                    {
                        String delete_file_way = file_[0].DirectoryName;
                        string[] file_section = delete_file_way.Split('\\');
                        DELETE_:
                        Console.WriteLine("Do you want to delete {0} student in {1} class.", idno, file_section[2]);
                        Console.WriteLine("yes or no");
                        string delete_comfirm = Console.ReadLine();
                        if (delete_comfirm=="yes")
                        {
                            System.IO.Directory.Delete(delete_file_way, true);
                            Console.WriteLine("Deleted {0} student in {1} classroom.", idno, file_section[2]);
                            goto OMERFDEV;
                        }
                        else if (delete_comfirm=="no")
                        {
                            Console.Clear();
                            Console.WriteLine("Cancelled Delete.");
                            goto OMERFDEV;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong Choose");
                            goto DELETE_;
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("{0} Student Doesnt Exist Any Classroom.", idno);
                        goto OMERFDEV;
                    }
                    
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("Please Enter Student:");
                    idno = Console.ReadLine();
                    System.IO.DirectoryInfo movefile_ = new System.IO.DirectoryInfo("c:\\SCHOOLBOOK");
                    System.IO.FileInfo[] findfile_= movefile_.GetFiles(idno+".txt",SearchOption.AllDirectories);
                    int file_s = findfile_.Count();
                    if (file_s>0)
                    {
                        string move_file_way = findfile_[0].DirectoryName;
                        string[] files = move_file_way.Split('\\');
                        Console.WriteLine(" Which Class Should You Move From Classroom {0}.", files);
                        string move_file_name = Console.ReadLine();
                        if (System.IO.Directory.Exists("c:\\SCHOOLBOOK"+"\\"+move_file_name)==true)
                        {
                            string target_file_way = @"c:\SCHOOLBOOK" + "\\" + move_file_name + "\\" + idno;
                            System.IO.Directory.Move(move_file_way,target_file_way);
                            Console.Clear();
                            Console.WriteLine("Student Number {0} in classroom {1} moved To Classroom {2}." ,idno,files,move_file_name);
                            goto OMERFDEV;

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("{0} Classrom Doesnt Exist.", move_file_name);
                            goto OMERFDEV;

                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("{0} Student Doesnt Exist.",idno);
                        goto OMERFDEV;
                    }
                    break;
               
                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Wrong Command.");
                    goto OMERFDEV;
                    break;
            } 
           
          
        }
    }
}