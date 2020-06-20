using System;
using Android.App;
using Android.OS;
using Android.Widget;
using SharedLibrary.Models;
using SharedLibrary.Services;

namespace MyUserManager.Activities
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

        private void AddUserOnClick(object sender, EventArgs eventArgs)
        {
            var username = FindViewById<EditText>(Resource.Id.edit_text_username);
            var password = FindViewById<EditText>(Resource.Id.edit_text_password);

            var fileHelper = new FileHelper();
            var dbFilePath = fileHelper.GetLocalFilePath(Resources.GetString(Resource.String.user_db_file));

            var userDataValidationService = new UserDataValidationService();
            var isPasswordValid =  userDataValidationService.ValidatePassword(password.Text);

            if (!isPasswordValid)
            {
                password.RequestFocus();
                password.SetError(Resources.GetString(Resource.String.invalid_password_text), null);
            }
            else
            {
                var userDataAccessService = new UserDataAccessService(dbFilePath);
                var addSuccessful = userDataAccessService.AddUser(new UserInfo(username.Text, password.Text));
                if(addSuccessful > 0)
                {
                    ShowToast(Resources.GetString(Resource.String.user_add_success));
                    Finish();
                }
                else
                {
                    ShowToast(Resources.GetString(Resource.String.oops_error_text));
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