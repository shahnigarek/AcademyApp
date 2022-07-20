using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
namespace Manage
{
    class Program
    {
       static void Main()
        {
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "0-Exit");
                Console.WriteLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Select option");
                string number = Console.ReadLine();
                int selectedNumber;
                bool result = int.TryParse(number,out  selectedNumber);
                if (result)
                {
                    if(selectedNumber >= 0 && selectedNumber <= 5)
                    {
                        switch (selectedNumber)
                        {
                            #region CreateGroup
                            case (int)Options.CreateGroup:
                                 ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please enter group name:");
                                string name=Console.ReadLine();
                                MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please enter group maxsize");
                                string size = Console.ReadLine();
                                int maxsize;
                                result=int.TryParse(size,out maxsize);
                                if (result)
                                {
                                    
                                    Group group = new Group
                                    {
                                        Name = name,
                                        MaxSize=maxsize


                                    };
                                    var createdGroup = _groupRepository.Create(group);
                                    _groupRepository.Create(group);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green,$"{createdGroup.Name} with maxsize-{createdGroup.MaxSize} was successufully created");

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please,enter right number!!");
                                    goto MaxSize;
                                }
                                 break;

                                #endregion CreateGroup

                            case (int)Options.DeleteGroup   :
                                break;
                            case (int)Options.UpdateGroup:
                                break;
                            case (int)Options.AllGroups:
                                var groups=_groupRepository .GetAll();
                                 ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All groups");
                                foreach(var group in groups)
                                {
                                    Console.WriteLine($"Name:{group.Name},maxSize:{group.MaxSize}");
                                }
                                break;
                                    case (int)Options.GetGroupByName:
                                break;
                            case (int)Options.Exit:
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Thanks for using application");
                                return;
                                
                        }


                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please,enter right number!!");

                    }
                }


            }
        }
    }
}
