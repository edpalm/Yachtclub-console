using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
namespace yachtclub.model 
{
  /// <summary>
  /// Represents a Member of the Yachtclub.
  /// </summary>
  public class Member 
  {
    private string _name;
    private string _personalNumber;
    private int _id;
    private List<Boat> _boats;

    /// <summary>
    /// A members list of boats.
    /// </summary>
    public List<Boat> Boats
    {
      get
      {
        return _boats;
      }
      set
      {
        _boats = value;
      }
    }

    /// <summary>
    /// A members name.
    /// </summary>
    /// <value></value>
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
      }
    }

    /// <summary>
    /// A members personal number.
    /// </summary>
    /// <value></value>
    public string PersonalNumber
    {
      get
      {
        return _personalNumber;
      }
      set
      {
        _personalNumber = value;
      }
    }

    /// <summary>
    /// A members id.
    /// </summary>
    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        _id = value;
      }
    }

    /// <summary>
    /// Adds a boat to the list of boats.
    /// </summary>
    /// <param name="type">the type of the boat.</param>
    /// <param name="length">the length of the boat.</param>
    public void AddBoat (string type, string length)
    {                          
      try
      {
        List<Member> memberList = JsonConvert.DeserializeObject<List<Member>>(File.ReadAllText(@"./memberregistry.json"));    
        List<int> boatIds = new List<int>();
        foreach (Member member in memberList) {
          foreach (Boat boat in member.Boats) {
            boatIds.Add(boat.Id);
          }
        }
        boatIds.Sort();  

        int currentId = 1; 
        foreach (int id in boatIds) 
        {
            if (id == currentId )
            {
                currentId++;
            }  
            else break;
          }       

        _boats.Add(new Boat(type, length, currentId));
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex); //temp
      }   
    }

    /// <summary>
    /// Removes a boat from the list of boats.
    /// </summary>
    /// <param name="boat">Index location of boat to be removed.</param>
    public void RemoveBoat(int boatId)
    {
      try
      {
        foreach(Boat b in _boats)
        {
          if (b.Id == boatId)
          {
            _boats.Remove(b);
            break;
          }
        }
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex); //temp
      }
    }

    /// <summary>
    /// Changes the type of a boat
    /// </summary>
    /// <param name="type">New value of the type</param>
    /// <param name="id">The ID of the boat to be updated</param>
    public void ChangeBoatType(string type, int id)
    {
      try
      {
        foreach(Boat b in _boats)
        {
          if (b.Id == id)
          {
            b.Type = type;
          }
        }
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex); //temp
      }
    }

    /// <summary>
    /// Changes the length of a boat
    /// </summary>
    /// <param name="length">New value of type</param>
    /// <param name="id">The ID of the boat to be updated</param>
    public void ChangeBoatLength(string length, int id)
    {
      try
      {
        foreach(Boat b in _boats)
        {
          if (b.Id == id)
          {
            b.Length = length;
          }
        }
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex); //temp
        // errormessage.
      }
    }

    /// <summary>
    /// Gets the list of boats.
    /// </summary>
    /// <returns>the list of boats.</returns>            
    public List<Boat> GetBoatList () 
    {
      return Boats; 
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="name"> name of member.</param>
    /// <param name="personalNumber"> personal number of member.</param>
    /// <param name="id"> a members unique id.</param>
    public Member (string name, string personalNumber, int id)           
    {   
      Name = name;
      PersonalNumber = personalNumber;
      Id = id;
      Boats = new List<Boat>();
    }
  } 
}
