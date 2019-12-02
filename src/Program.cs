using System;

namespace yachtclub
{
    class Program
    {   
        static void Main(string[] args)
        {
            /// <summary>
            /// The starting point of the application.
            /// </summary>
            model.YachtClub ycm = new model.YachtClub();
            view.UI v = new view.UI();
            controller.User c = new controller.User(ycm, v);            
            c.StartApp();
        }
    }
}
