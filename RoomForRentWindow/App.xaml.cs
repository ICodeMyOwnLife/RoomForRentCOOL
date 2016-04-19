using System;
using System.Data.Entity;
using RoomForRentEntityDataAccess;


namespace RoomForRentWindow
{
    public partial class App
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }


}