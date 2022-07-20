﻿using Core.Constants;
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
