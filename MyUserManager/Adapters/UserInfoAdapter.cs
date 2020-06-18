using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SharedLibrary.Models;

namespace MyUserManager.Adapters
{
    internal class UserInfoAdapter : RecyclerView.Adapter
    {
        private readonly UserInfo[] items;
        private const int HeaderItem = 0;
        private const int ListItem = 1;

        public UserInfoAdapter(UserInfo[] data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup your layout here
            var id = viewType == HeaderItem ? Resource.Layout.user_info_header_item : Resource.Layout.user_info_list_item;
            var itemView = LayoutInflater.From(parent.Context).
                Inflate(id, parent, false);

            if(viewType == HeaderItem)
            {
                return new UserInfoHeaderAdapterViewHolder(itemView);
            }
            return new UserInfoAdapterViewHolder(itemView);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            if(viewHolder is UserInfoAdapterViewHolder)
            {
                var holder = viewHolder as UserInfoAdapterViewHolder;
                holder.UserNameTextView.Text = items[position - 1].User;
                holder.PasswordTextView.Text = items[position - 1].Password;
            }
        }
        public override int GetItemViewType(int position)
        {
            if (position == 0)
                return HeaderItem;
            return ListItem;
        }

        public override int ItemCount => items.Length + 1;

    }

    public class UserInfoHeaderAdapterViewHolder : RecyclerView.ViewHolder
    {
        public UserInfoHeaderAdapterViewHolder(View itemView) : base(itemView)
        {            
        }
    }
    public class UserInfoAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView UserNameTextView { get; set; }
        public TextView PasswordTextView { get; set; }

        public UserInfoAdapterViewHolder(View itemView) : base(itemView)
        {
            UserNameTextView = itemView.FindViewById<TextView>(Resource.Id.text_view_user_name);
            PasswordTextView = itemView.FindViewById<TextView>(Resource.Id.text_view_password);
        }
    }
}