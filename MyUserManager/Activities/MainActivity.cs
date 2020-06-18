using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using MyUserManager.Adapters;
using SharedLibrary.DataAccess;
using SharedLibrary.Services;

namespace MyUserManager.Activities
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

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;


            _userInfoRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView_users);

            var layoutManager = new LinearLayoutManager(this) { Orientation = LinearLayoutManager.Vertical };
            _userInfoRecyclerView.SetLayoutManager(layoutManager);
            _userInfoRecyclerView.HasFixedSize = true;

            DividerItemDecoration dividerItem = new DividerItemDecoration(_userInfoRecyclerView.Context, layoutManager.Orientation);
            _userInfoRecyclerView.AddItemDecoration(dividerItem);
            InitDatabase();

        }

        private void InitDatabase()
        {
            var applicationFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var databaseFileName = System.IO.Path.Combine(applicationFolderPath, Resources.GetString(Resource.String.user_db_file));

            DatabaseHelper.InitDb(databaseFileName);
        }

        protected override void OnResume()
        {
            base.OnResume();
            UserService userService = new UserService();
            var recyclerViewData = userService.GetUsers();
            _userInfoAdapter = new UserInfoAdapter(recyclerViewData);
            _userInfoRecyclerView.SetAdapter(_userInfoAdapter);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(AddUsersActivity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
