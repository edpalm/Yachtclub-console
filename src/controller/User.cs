using System;
using menuhelper;

namespace yachtclub.controller 
{ 
    public class User
    {
        /// <summary>
        /// Controller for yachtclub.
        /// </summary>
        model.YachtClub _ycm;
             
        view.UI _view;
        
        /// <summary>
        /// Shows the main menu.
        /// Responds to user input.
        /// </summary>
        public void StartApp() 
        {
            _ycm.GetMembers();
            Choice choice = _view.Menu();
            HandleChoice(choice);
        } 
        
        /// <summary>
        /// Responds to user menu choice.
        /// </summary>
        /// <param name="choice"></param>
        private void HandleChoice(Choice choice)
        {
            switch (choice)
            {
                case Choice.Register:
                {   
                    string name = _view.GetName();
                    string personalNumber = _view.GetPersonalNumber();
                    _ycm.RegisterMember(name, personalNumber);
                    StartApp();
                    break;
                }
                case Choice.Manage:
                {
                    ManageMember();   
                    break;
                }
                case Choice.ChangeName:
                {
                    _ycm.MemberToBeManaged.Name = _view.UpdateInfo();
                    _ycm.UpdateMember();
                    StartApp();
                    break;
                }
                case Choice.ChangePersonalNumber:
                {
                    _ycm.MemberToBeManaged.PersonalNumber = _view.UpdateInfo();
                    _ycm.UpdateMember();
                    StartApp();
                    break;
                }
                case Choice.DeleteMember:
                {
                    _ycm.DeleteMember();
                    StartApp();
                    break;
                }
                 case Choice.ManageBoats:
                {
                    ManageBoats();
                    break;
                }
                case Choice.AddBoat:
                {
                    string bType = _view.GetBoatType();
                    string bLength = _view.GetBoatLength();                    
                    _ycm.MemberToBeManaged.AddBoat(bType, bLength);
                    _ycm.UpdateMember();
                    StartApp();
                    break;
                }
                case Choice.DeleteBoat:
                {
                    if (_ycm.MemberToBeManaged.Boats.Count > 0) {
                        int boat = _view.BoatToBeRemoved(_ycm.MemberToBeManaged.Boats);
                        _ycm.MemberToBeManaged.RemoveBoat(boat);
                        _ycm.UpdateMember();
                        StartApp();
                    } else ManageMember();
                    break;
                }
                case Choice.ChangeBoatType:
                {
                    int boatToBeChanged = _view.BoatToBeRemoved(_ycm.MemberToBeManaged.Boats);
                    string type = _view.GetBoatType();
                    _ycm.MemberToBeManaged.ChangeBoatType(type, boatToBeChanged);
                    _ycm.UpdateMember();
                    StartApp();
                    break;
                }
                case Choice.ChangeBoatLength:
                {
                    int boatToBeChanged = _view.BoatToBeRemoved(_ycm.MemberToBeManaged.Boats);
                    string length = _view.GetBoatLength();
                    _ycm.MemberToBeManaged.ChangeBoatLength(length, boatToBeChanged);
                    _ycm.UpdateMember(); 
                    StartApp();                                       
                    break;
                }
                case Choice.ViewLists:
                {
                    ViewLists();
                    break;
                }
                case Choice.CompactList:
                {
                    _view.CompactList(_ycm.MemberList);
                    StartApp();
                    break;
                }
                case Choice.VerboseList:
                {
                    _view.VerboseList(_ycm.MemberList);
                    StartApp();
                    break;
                }
            }               
        }

  
        /// <summary>
        /// Sets which member to be managed.
        /// Checks if user exists.
        /// /// </summary>
        public void ManageMember() 
        {
            int id = _view.EnterID();
            if (_ycm.SetMemberToBeManaged(id)) 
            {   
                Choice choice = _view.ShowManageUserOptions(_ycm.MemberToBeManaged.Name, _ycm.MemberToBeManaged.PersonalNumber, _ycm.MemberToBeManaged.Id);
                HandleChoice(choice);
            }
            else
            {
                _view.UserDoesNotExist();
                ManageMember();
            }
        }

        /// <summary>
        /// Shows boat management options.
        /// Responds to user input.
        /// </summary>
        public void ManageBoats()
        {
            Choice choice = _view.ShowManageBoatOptions();
            HandleChoice(choice);
        }

        public void ViewLists()
        {
            Choice choice = _view.ShowListOptions();
            HandleChoice(choice);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="yachtClub"> model YachtClub. Rules for system. </param>
        /// <param name="view"> view UI. Presents options and data to user.</param>
        public User (model.YachtClub ycm, view.UI view)           
        {   
            _ycm = ycm;
            _view = view;
        }  
    }
}