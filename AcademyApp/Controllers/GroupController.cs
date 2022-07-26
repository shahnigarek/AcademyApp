﻿using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class GroupController
    {

        private GroupRepository _groupRepository;

        public GroupController()
        {
            _groupRepository = new GroupRepository();
        }

        #region CreateGroup
        public void CreateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please enter group name:");
            string name = Console.ReadLine();
        MaxSize: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please enter group maxsize");
            string size = Console.ReadLine();
            int maxsize;
            bool result = int.TryParse(size, out maxsize);
            if (result)
            {

                Group group = new Group
                {
                    Name = name,
                    MaxSize = maxsize


                };
                var createdGroup = _groupRepository.Create(group);
                _groupRepository.Create(group);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name} with maxsize-{createdGroup.MaxSize} was successufully created");

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please,enter right number!!");
                goto MaxSize;
            }
        }
        #endregion CreateGroup
        #region AllGroups
        public void AllGroups()
        {
            var groups = _groupRepository.GetAll();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All groups");
            foreach (var group in groups)
            {
                Console.WriteLine($"Name:{group.Name},maxSize:{group.MaxSize}");
            }
        }
        #endregion AllGroups
        #region Exit
        public void Exit()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Thanks for using application");
            
        } 
        #endregion Exit
        #region GetGroupName
        public void GetGroupName()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group name");
            string name = Console.ReadLine();

            var group = _groupRepository.Get((g => g.Name.ToLower() == name.ToLower()));
            if (group != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name;{group.Name},maxSize:{group.MaxSize}");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }

        }
        #endregion GetGroupName
        #region UpdateGroup
        public void UpdateGroup()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter group name:");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                int OldSize = group.MaxSize;
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new group name:");
                string newname = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Enter new group maxSize:");
                string newsize = Console.ReadLine();

                int maxSize;
              bool  result = int.TryParse(newsize, out maxSize);

                if (result)
                {
                    var newGroup = new Group
                    {
                        ID = group.ID,
                        Name = group.Name,
                        MaxSize = maxSize
                    };
                    _groupRepository.Update(newGroup);

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{name},maxSize:{maxSize} is updated");


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right maxSize");
                }

            }

        }
        #endregion UpdateGroup
        #region DeleteGroup
        public void DeleteGroup()
        {
             ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group name");
             string name = Console.ReadLine();
        var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
             if(group != null)
            {
                _groupRepository.Delete(group);
             ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");

            }
              else  
              {
                     ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
              }

        }
        #endregion DeleteGroup
    }
}




