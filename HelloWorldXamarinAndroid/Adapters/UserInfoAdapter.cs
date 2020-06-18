using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using SharedLibrary;

namespace HelloWorldXamarinAndroid
{
    internal class UserInfoAdapter : RecyclerView.Adapter
    {
        private readonly UserInfo[] items;

        public UserInfoAdapter(UserInfo[] data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            var id = Resource.Layout.user_info_list_item;
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(id, parent, false);

            var vh = new UserInfoAdapterViewHolder(itemView);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            // Replace the contents of the view with that element
            var holder = viewHolder as UserInfoAdapterViewHolder;
            holder.UserNameTextView.Text = items[position].User;
            holder.PasswordTextView.Text = items[position].Password;
        }

        public override int ItemCount => items.Length;

    }

    public class UserInfoAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView UserNameTextView { get; set; }
        public TextView PasswordTextView { get; set; }

        public UserInfoAdapterViewHolder(View itemView): base(itemView)
        {
            UserNameTextView = itemView.FindViewById<TextView>(Resource.Id.text_view_user_name);
            PasswordTextView = itemView.FindViewById<TextView>(Resource.Id.text_view_password);
        }
    }
}