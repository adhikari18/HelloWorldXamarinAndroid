using System;
using Android.App;
using Android.OS;
using Android.Widget;
using SharedLibrary;

namespace HelloWorldXamarinAndroid.Activities
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
            var username = FindViewById<EditText>(Resource.Id.edit_text_username);
            var password = FindViewById<EditText>(Resource.Id.edit_text_password);
            var userService = new UserService();
            var isPasswordValid =  userService.ValidatePassword(password.Text);

            if (!isPasswordValid)
            {
                password.SetError("Invalid Password", null);
            }
            else
            {
                var addSuccessful = userService.AddUser(new UserInfo(username.Text, password.Text));
                if(addSuccessful > 0)
                {
                    ShowToast("Successfully added user information!");
                    Finish();
                }
                else
                {
                    ShowToast("Oops, something went wrong!");
                }
            }
        }

        private void ShowToast(string text)
        {
            var toast = Toast.MakeText(Application.Context, text, ToastLength.Short);
            toast.Show();
        }
    }
}