﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * STUDENT NAME: Yoonseop  Lee
 * STUDENT ID: 301037418
 * DESCRTIPTION : This is the character class used in character creation
 *                This is also the Data ontainer for the application
 */
namespace COMP123_2019_FinalTestB.Objects
{
    public class Character
    {
        // Names
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Character Abilities

        public string Strength { get; set; }
        public string Dexterity { get; set; }
        public string Constitution { get; set; } 
        public string Intelligence { get; set; }
        public string Wisdom { get; set; }
        public string Charisma { get; set; }

        // Secondary Abilities
        public int ArmourClass { get; set; }
        public int HitPoints { get; set; }

        // Character Class
        public CharacterClass Class { get; set; }
        public int Level { get; set; }

        // Equipment
        public List<string> Inventory;

        // Constructor
        public Character()
        {
            Inventory = new List<string>();
        }
    }
}
