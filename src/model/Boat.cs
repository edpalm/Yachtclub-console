using System;

namespace yachtclub.model 
{   
    /// <summary>
    /// Represents a Boat.
    /// </summary>
     public class Boat 
    {   
        private string _type;
        private string _length;
        private int _id;
        
        /// <summary>
        /// A boat's type.
        /// /// </summary>
        public string Type
        {
            get 
            {
                return _type; 
            }
            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// A boat's length.
        /// </summary>
        public string Length
        {
            get 
            {
                return _length; 
            }
            set
            {
                _length = value;
            }
        }

        /// <summary>
        /// A boat's id
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
        /// Constructor.
        /// </summary>
        /// <param name="type"> type of boat.
        /// <param name="length"> length of boat.
        public Boat(string type, string length, int id)
        {
            Type = type;
            Length = length;
            Id = id;           
        } 
    }
}
