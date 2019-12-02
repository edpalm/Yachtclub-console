using System;
using System.Text;
using System.Collections.Generic;
using menuhelper;
using yachtclub.model;

namespace yachtclub.view 
{
    /// <summary>
    /// Represents the user interface.
    /// </summary>
    public class UI 
    { 
        ///<summary>
        /// Displays the initial options menu.
        ///</summary>
        public Choice Menu ()
        {    
            Choice choice;
            // Displaying options
            string menu = "\nMain menu\n\n1. Register member \n2. Manage member \n3. View Lists";
            Console.WriteLine(menu);    
            // Handling user input
            ConsoleKeyInfo input = Console.ReadKey(true);       
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                {
                Console.WriteLine("\nRegister member.");
                // Show register options.
                choice = Choice.Register;
                break;
                }
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                {
                Console.WriteLine("\nManage member");                    
                // Show edit options.
                choice = Choice.Manage;
                break;
                } 
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                {
                Console.WriteLine("\nView list");
                choice = Choice.ViewLists;
                break;
                }  
                default:
                {
                Console.WriteLine("\nTry again\n");
                Choice faultFixed = Menu();
                choice = faultFixed;
                break;
                }
            }
            return choice;
        }

        /// <summary>
        /// Asks for a valid id.
        /// </summary>
        /// <returns>an id.</returns>
        public int EnterID()
        {
            Console.Write("\nEnter member id number: ");
            string enteredID = Console.ReadLine();
            int id;
            try 
            {
            id = int.Parse(enteredID);
            return id;
            } 
            catch
            {
                Console.WriteLine("Invalid ID, try again:");
                return EnterID();
            }
        }

        /// <summary>
        /// asks for name.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            Console.Write("Enter name: ");
            string n = Console.ReadLine();
            return n;
        }

        public string GetPersonalNumber()
        {
            Console.Write("Enter your personal number: ");
            string n = Console.ReadLine();
            return n;                            
        }  

        public Choice ShowManageUserOptions(string name, string personalNumber, int id)
        {
            Console.WriteLine("Currently managing: " + name + "\nPersonal number: " + personalNumber);
            Console.WriteLine("Options\n1. Change name \n2. Change Personal Number \n3. Delete Member \n4. Manage Boats");
            ConsoleKeyInfo input = Console.ReadKey(true);
            Choice choice;
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                {
                 Console.WriteLine("\nChange name.");
                // Show register options.
                choice = Choice.ChangeName;
                break;
                }
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                {
                Console.WriteLine("\nChange Personal Number");                    
                // Show edit options.
                choice = Choice.ChangePersonalNumber;
                break;
                } 
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                {
                Console.WriteLine("\nDelete Member");
                choice = Choice.DeleteMember;     
                break;
                } 
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                {    
                Console.WriteLine("\nManage Boats");
                choice = Choice.ManageBoats;
                break;
                }    
                default:
                {
                Console.WriteLine("\nFelaktigt alternativ, försök igen\n");
                Choice faultFixed = ShowManageUserOptions(name, personalNumber, id);
                choice = faultFixed;
                break;
                }
            }
            return choice;
        }

        public Choice ShowManageBoatOptions()
        {
            Console.WriteLine("Options\n1. Add Boat \n2. Delete boat \n3. Change type \n4. Change Length");
            ConsoleKeyInfo input = Console.ReadKey(true);
            Choice choice;
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                {
                    Console.WriteLine("\nAdd boat");
                    choice = Choice.AddBoat;
                break;
                }
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                {
                    Console.WriteLine("\nRemove boat");
                    choice = Choice.DeleteBoat;
                break;
                } 
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                {
                    Console.WriteLine("\nChange type");
                    choice = Choice.ChangeBoatType;     
                break;
                }
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                {
                    Console.WriteLine("\nChange length");
                    choice = Choice.ChangeBoatLength;
                break;
                }    

                default:
                {
                    Console.WriteLine("\nFelaktigt alternativ, försök igen\n");
                    Choice faultFixed = ShowManageBoatOptions();
                    choice = faultFixed;                        
                break;
                }
            }
            return choice;
        }   
        public Choice ShowListOptions()
        {
            Console.WriteLine("1. Compact list \n2. Verbose list");
            ConsoleKeyInfo input = Console.ReadKey(true);
            Choice choice;
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                {
                    Console.WriteLine("\nCompact list.");
                    choice = Choice.CompactList;
                break;
                }
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                {
                    Console.WriteLine("\nVerbose list.");                    
                    choice = Choice.VerboseList;
                break;
                }   
                default:
                {
                    Console.WriteLine("\nFelaktigt alternativ, försök igen\n");
                    Choice faultFixed = ShowListOptions();
                    choice = faultFixed;                                        
                break;
                } 
            }   
            return choice;
        }
        public void UserDoesNotExist()
        {
            Console.WriteLine("User does not exist, try again");
        }     

        public string UpdateInfo()
        {
            return Console.ReadLine();
        }    

        public string GetBoatType()
        {
            Console.Write("Input boat type: ");
            return Console.ReadLine();
        }

        public string GetBoatLength()
        {
            Console.Write("Input boat length: ");
            return Console.ReadLine(); 
        }

        public int BoatToBeRemoved(List<Boat> boats)
        {
            int boatNumber = 1;
            foreach(Boat b in boats) 
            {
                Console.WriteLine(boatNumber + ". " + b.Type);
                boatNumber++;
            }
            int boatTobeRemoved = ReturnInt("remove", boats.Count, out int number);
            return boats[boatTobeRemoved].Id;
        }

        public int ReturnInt (string option, int length, out int number)
        {
            while (!(int.TryParse(Console.ReadLine(), out number)) || number > length || number < 1)
            {
             Console.WriteLine(option);
            }
            return number - 1;
        }

                
        public void CompactList(List<Member> members)
        {
            foreach(Member m in members)
            {
                Console.WriteLine("Name: " + m.Name);
                Console.WriteLine("Id: " + m.Id); 
                Console.WriteLine("Number of boats: " + m.Boats.Count + "\n");
            }
            
        }                
    
        public void VerboseList(List<Member> members)
        {     
            foreach(Member m in members)
            {
                List<Boat> boatList = m.Boats; 
                Console.WriteLine("Name: " + m.Name);
                Console.WriteLine("Id: " + m.Id);
                Console.WriteLine("Personal number: " + m.PersonalNumber);
                Console.WriteLine("\nBoats ");
                foreach(Boat b in boatList)
                {
                    Console.Write("Type: " + b.Type + "\nLength: " + b.Length);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
