using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Master.Database;

namespace Master.Adapters
{
    class RecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        List<CImage> items;
        Activity activity;
        public CImage clickedImage;
        public ImageView sharedImageVIew;
        public int ClickedPosition;

        public RecyclerViewAdapter(List<CImage> pItems, Activity pActivity)
        {
            items = pItems;
            activity = pActivity;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            CImage item = null;
            string layout = "";
            if (items != null)
            {
                item = items[0];
            }
            View view = null;
            if (item != null)
            {
                    view = activity.LayoutInflater.Inflate(Resource.Layout.image_view_holder, null);
                LinearLayout.LayoutParams LLParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,
                                                                                   LinearLayout.LayoutParams.WrapContent);
                view.LayoutParameters = LLParams;
            }

            RecyclerViewHolder vh = new RecyclerViewHolder(view, activity, OnClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = items[position];
            RecyclerViewHolder vh = holder as RecyclerViewHolder;

            vh.Naslov.Text = "";
            if (App.preferences.language == LangEnum.Latinica)
            {
                if (item.SolvedLatin)
                {
                    vh.Naslov.Text = item.SolutionLatin.ToUpper();
                    vh.grayLayer.Visibility = ViewStates.Gone;
                }
                else
                {
                    for (int i = 0; i < item.SolutionLatin.Length; i++)
                    {
                        vh.Naslov.Text += "__ ";
                    }
                    vh.grayLayer.Visibility = ViewStates.Visible;
                }
            }
            else
            {
                if (item.SolvedCyrilic)
                {
                    vh.Naslov.Text = item.SolutionCyrilic.ToUpper();
                    vh.grayLayer.Visibility = ViewStates.Gone;
                }
                else
                {
                    for (int i = 0; i < item.SolutionCyrilic.Length; i++)
                    {
                        vh.Naslov.Text += "__ ";
                        vh.grayLayer.Visibility = ViewStates.Visible;
                    }
                }
            }

            vh.Slika.SetImageResource(activity.Resources.GetIdentifier(item.Name, "drawable", activity.PackageName));
            vh.Slika.TransitionName = item.Name;

            if (item.Id < 70)
            {
                vh.Star1.SetImageResource(Resource.Drawable.ic_star_g);
                vh.Star2.SetImageResource(Resource.Drawable.ic_star);
                vh.Star3.SetImageResource(Resource.Drawable.ic_star);
            }
            else if (item.Id < 150)
            {
                vh.Star1.SetImageResource(Resource.Drawable.ic_star_g);
                vh.Star2.SetImageResource(Resource.Drawable.ic_star_g);
                vh.Star3.SetImageResource(Resource.Drawable.ic_star);
            }
            else
            {
                vh.Star1.SetImageResource(Resource.Drawable.ic_star_g);
                vh.Star2.SetImageResource(Resource.Drawable.ic_star_g);
                vh.Star3.SetImageResource(Resource.Drawable.ic_star_g);
            }

            
        }

        public override int ItemCount
        {
            get
            {
                if (items != null)
                {
                    return items.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void OnClick(int position)
        {
            clickedImage = items[position];
            ClickedPosition = position;
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }

    public class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public LinearLayout grayLayer { get; private set; }
        public TextView Naslov { get; private set; }
        public ImageView Slika { get; private set; }
        public ImageView Star1 { get; private set; }
        public ImageView Star2 { get; private set; }
        public ImageView Star3 { get; private set; }

        public RecyclerViewHolder(View itemView, Activity activity, Action<int> listener) : base(itemView)
        {
            grayLayer = ItemView.FindViewById<LinearLayout>(Resource.Id.grayLayer);
            Naslov = ItemView.FindViewById<TextView>(Resource.Id.nazivSlike);
            Slika = ItemView.FindViewById<ImageView>(Resource.Id.slika);
            Star1 = ItemView.FindViewById<ImageView>(Resource.Id.star1);
            Star2 = ItemView.FindViewById<ImageView>(Resource.Id.star2);
            Star3 = ItemView.FindViewById<ImageView>(Resource.Id.star3);

            itemView.Click += delegate
            {
               
               listener(base.Position);
            };
        }
    }

    //public class SimpleDividerItemDecoration : RecyclerView.ItemDecoration
    //{

    //    private Drawable mDivider;

    //    public SimpleDividerItemDecoration(Context context)
    //    {
    //        mDivider = context.Resources.GetDrawable(Resource.Drawable.line_divider);
    //    }

    //    public override void OnDrawOver(Android.Graphics.Canvas cValue, RecyclerView parent)
    //    {
    //        int left = parent.PaddingLeft;
    //        int right = parent.Width - parent.PaddingRight;

    //        int childCount = parent.ChildCount;
    //        for (int i = 0; i < childCount; i++)
    //        {
    //            View child = parent.GetChildAt(i);

    //            RecyclerView.LayoutParams param = (RecyclerView.LayoutParams)child.LayoutParameters;

    //            int top = child.Bottom + param.BottomMargin;
    //            int bottom = top + mDivider.IntrinsicHeight;

    //            mDivider.SetBounds(left, top, right, bottom);
    //            mDivider.Draw(cValue);
    //        }
    //    }

    //}
}