using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;


namespace yachtclub.model 
{   
    /// <summary>
    /// Represents the yachtclub.
    /// </summary>
    public class YachtClub 
    {
        Member _memberToBeManaged;
        List <Member> _memberList = new List<Member>();
        
        /// <summary>
        /// the member currently being managed.
        /// </summary>
        public Member MemberToBeManaged
        {
            get
            {
                return _memberToBeManaged;
            }
            set
            {
                _memberToBeManaged = value;
            }
        }
        public List<Member> MemberList
        {
            get
            {
                return _memberList;
            }
        }  

        /// <summary>
        /// Adds a member to the registry.
        /// Creates the registry if there are no registered members.
        /// </summary>
        /// <param name="name">the name of the member.</param>
        /// <param name="personalNumber">the personal number of the member.</param>
        public void RegisterMember(string name, string personalNumber)
        {   
            int id = GenerateId();      
            Member m = new Member(name, personalNumber, id);
            _memberList.Add(m); 
            WriteToFile();
        }

        /// <summary>
        /// Gets the list of members.
        /// </summary>
        /// <returns>a list of members.</returns>
        public void GetMembers()
        {
            if (fileExists())
            {
                _memberList = JsonConvert.DeserializeObject<List<Member>>(File.ReadAllText(@"./memberregistry.json"));  
            }
        }               
        
        /// <summary>
        /// Writes the list of members to the registry.
        /// </summary>
        /// <param name="mList">the list of members</param>
        private void WriteToFile()
        {
            File.WriteAllText(@"./memberregistry.json", JsonConvert.SerializeObject(_memberList, Formatting.Indented));   
        }

        /// <summary>
        /// Checks if the member registry exists in the system.
        /// </summary>
        /// <returns></returns>
        public bool fileExists()
        {
            return File.Exists(@"./memberregistry.json");            
        }

        /// <summary>
        ///  Generates a unique id for the member to be registered.
        /// </summary>
        /// <param name="memberList">List of Member objects</param>
        /// <returns></returns>
        private int GenerateId () 
        {
            _memberList = _memberList.OrderBy(x => x.Id).ToList();
            int currentId = 1; 
            foreach (Member member in _memberList) 
            {
                if (member.Id == currentId )
                {
                    currentId++;
                } 
                else 
                {
                    break;               
                }  
            }  
            return currentId;      
        }
   
        /// <summary>
        /// Sets which member is to be managed.
        /// </summary>
        /// <param name="id">the id of the member to be managed.</param>
        /// <returns></returns>
        public bool SetMemberToBeManaged(int id)
        {
            foreach(Member m in _memberList) 
            {
                if (m.Id == id) 
                {
                    MemberToBeManaged = m;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Updates the member currently being managed and writes it to registry file
        /// </summary>
        public void UpdateMember() 
        {
            // Hitta membertobemanaged i listan
            foreach (Member m in _memberList)
            {
                if (m.Id == MemberToBeManaged.Id)
                {
                    m.Name = MemberToBeManaged.Name;
                    m.PersonalNumber = MemberToBeManaged.PersonalNumber;
                    m.Boats = MemberToBeManaged.Boats;
                }
            } 
            WriteToFile();
        } 
        /// <summary>
        /// Deletes the member currently being managed and overwrites the registry file
        /// </summary>
        public void DeleteMember () 
        {
           foreach (Member m in _memberList)
            {
                if (m.Id == MemberToBeManaged.Id)
                {
                    _memberList.Remove(m);
                    break;
                }
            } 
            WriteToFile();   
        }
    }
}