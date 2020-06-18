using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SharedLibrary;

namespace HelloWorldXamarinAndroid
{
    [Activity(Label = "AddUsersActivity")]
    public class AddUsersActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.add_users);

            var addUserButton = FindViewById<Button>(Resource.Id.button_add_user);
            addUserButton.Click += AddUserOnClick;

        }

        private async void AddUserOnClick(object sender, EventArgs eventArgs)
        {
            string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "CanFindLocation");

            System.IO.Directory.CreateDirectory(applicationFolderPath);
            string databaseFileName = System.IO.Path.Combine(applicationFolderPath, "CanFindLocation.db");

            var userService = new UserService(databaseFileName);
            var username = FindViewById<EditText>(Resource.Id.edit_text_username);
            var password = FindViewById<EditText>(Resource.Id.edit_text_password);

            var isPasswordValid = await userService.ValidatePassword(password.Text);

            if (!isPasswordValid)
            {
                password.SetError("Invalid Password", null);
            }
            else
            {
                DatabaseHelper.AddUser(new UserInfo(username.Text, password.Text));
                //await userService.AddUserAsync(new UserInfo(username.Text, password.Text));
                Finish();
            }
        }
    }
}