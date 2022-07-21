using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using Manage.Controllers;
using System;
namespace Manage
{
    class Program
    {
        static void Main()
        {
            StudentController _studentController = new StudentController();
            StudentRepository _studentRepository = new StudentRepository();
            GroupController _groupController = new GroupController();
            GroupRepository _groupRepository = new GroupRepository();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Welcome");
            Console.WriteLine();

            while (true)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "1-Create a group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "2-Update a group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "3-Delete a group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "4-All groups");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "5-Get Group by name");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "6-Create Student");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "7-Update Student");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "8-Delete Student");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "9-GetAll Students By Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "10-Get Studdent By Group");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-Exit");
                Console.WriteLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select option");
                string number = Console.ReadLine();
                int selectedNumber;
                bool result = int.TryParse(number, out selectedNumber);
                if (result)
                {
                    if (selectedNumber >= 0 && selectedNumber <= 10)
                    {
                        switch (selectedNumber)
                        {
                            case (int)Options.CreateGroup:
                                _groupController.CreateGroup();
                                break;

                            case (int)Options.DeleteGroup:
                                _groupController.DeleteGroup();
                                break;
                            case (int)Options.UpdateGroup:
                                _groupController.UpdateGroup();
                                break;
                            case (int)Options.AllGroups:
                                _groupController.AllGroups();
                                break;
                            case (int)Options.GetGroupByName:
                                _groupController.GetGroupName();
                                break;
                            case (int)Options.CreateStudent:
                                _studentController.CreateStudent();
                                break;
                            case (int)Options.DeleteStudent:
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter the ID of the student you want to delete ");
                                string ID = Console.ReadLine();
                                int Id;

                                result = int.TryParse(ID, out Id);
                              
                                var student = _studentRepository.Get(s => s.ID==Id);

                                if (student != null)
                                {
                                    _studentRepository.Delete(student);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $" student with ID:{student.ID} is deleted");

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Student with this ID  doesn't exist");
                                }
                                break;


                            case (int)Options.Exit:
                                _groupController.Exit();
                                return;
                        }

                    }


                }


            }
        }
    }
}



