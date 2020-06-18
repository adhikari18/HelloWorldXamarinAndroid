using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;

using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using SharedLibrary;
using System.Threading.Tasks;

namespace HelloWorldXamarinAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView _userInfoRecyclerView;
        private UserInfoAdapter _userInfoAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;


            _userInfoRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView_users);

            var layoutManager = new LinearLayoutManager(this) { Orientation = LinearLayoutManager.Vertical };
            _userInfoRecyclerView.SetLayoutManager(layoutManager);
            _userInfoRecyclerView.HasFixedSize = true;

            InitDatabase();

        }

        private void InitDatabase()
        {
            string applicationFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string databaseFileName = System.IO.Path.Combine(applicationFolderPath, "users.db");

            DatabaseHelper.InitDb(databaseFileName);
        }

        protected override void OnResume()
        {
            base.OnResume();

            var recyclerViewData = GetData();
            // Plug in my adapter:
            _userInfoAdapter = new UserInfoAdapter(recyclerViewData);
            _userInfoRecyclerView.SetAdapter(_userInfoAdapter);
        }

        private UserInfo[] GetData()
        {
            return DatabaseHelper.GetUsers().ToArray();
            //var userService = new UserService(databaseFileName);
            //var result = userService.GetUsersAsync().Result;
            //return result;
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(AddUsersActivity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
