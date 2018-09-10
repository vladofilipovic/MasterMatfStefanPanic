using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Transitions;
using Android.Util;
using Android.Views;
using Android.Widget;
using Master.Adapters;

namespace Master.Fragments
{
    public class ReadingAndWritingFragment : Fragment
    {
        private RecyclerView mRecyclerView;
        private RecyclerViewAdapter mAdapter;
        private LinearLayoutManager mLayoutManager;
        LinearLayout rootView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Activity.Title = GetString(Resource.String.citanje_i_pisanje);
            //PostponeEnterTransition();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            rootView = (LinearLayout)inflater.Inflate(Resource.Layout.reading_and_writing_fragment, container, false);
            mRecyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            mRecyclerView.HasFixedSize = true;

            mLayoutManager = new LinearLayoutManager(Activity);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            mAdapter = new RecyclerViewAdapter(App.db.GetAllImages(), Activity);
            mRecyclerView.SetAdapter(mAdapter);

            if (App.CurrentImagePossition != -1)
            {
                if (!(mLayoutManager.FindFirstVisibleItemPosition() <= App.CurrentImagePossition && mLayoutManager.FindLastVisibleItemPosition() >= App.CurrentImagePossition))
                {
                    Activity.RunOnUiThread(() =>
                    {
                        mLayoutManager.ScrollToPositionWithOffset(App.CurrentImagePossition, 20);
                    }); ;
                }
                //StartPostponedEnterTransition();
            }
            else
            {
                //StartPostponedEnterTransition();
            }

            mAdapter.ItemClick += delegate
            {
                var view = mRecyclerView.FindViewHolderForAdapterPosition(mAdapter.ClickedPosition) as RecyclerViewHolder;

                var tmp = view.Slika.TransitionName;
                GuessingImageFragment gif = new GuessingImageFragment(mAdapter.clickedImage.Id);
                //gif.SharedElementEnterTransition = new AutoTransition();
                //gif.EnterTransition = new Fade();
                //setExitTransition(new Fade());
                Activity.FragmentManager.BeginTransaction()
                .Replace(App.fragmentContainer.Id, gif, "guessing")
                .AddSharedElement(view.Slika, mAdapter.clickedImage.Name)
                .AddToBackStack(null)
                .Commit();
                App.CurrentFragment = gif;
            };

            return rootView;
        }
    }
}