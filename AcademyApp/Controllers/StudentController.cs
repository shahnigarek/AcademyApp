using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public  class StudentController
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;


        public StudentController()
        {
            _studentRepository = new StudentRepository();
            _groupRepository= new GroupRepository();
        }

        public void CreateStudent()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter student name");
                string name = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter student surname");
                string surname = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter student age");
                string age = Console.ReadLine();
                byte studentAge;
               bool  result = byte.TryParse(age, out studentAge);

            AllGroupsList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All groups");

                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, group.Name);
                }

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter group name");
                string groupName = Console.ReadLine();

                var dbgroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
                if (dbgroup != null)
                {
                    if (dbgroup.MaxSize > dbgroup.CurrentSize)
                    {
                        var student = new Student
                        {
                           Name = name,
                            Age = studentAge,
                            Surname = surname,
                            Group = dbgroup
                        };
                        dbgroup.CurrentSize++;

                        _studentRepository.Create(student);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{student.ID},Surname:{student.Surname},Age:{student.Age}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Group is full,group's maxsize:{dbgroup.MaxSize}");

                    }




                }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including group doesnm't exist");
                goto AllGroupsList;

            }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please create group before inputing info about student");
            }


        }

    }
}







