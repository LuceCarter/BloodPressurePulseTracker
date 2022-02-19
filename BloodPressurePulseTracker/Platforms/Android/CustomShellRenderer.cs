using Android.Content;
using Android.Content.Res;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

namespace BloodPressureTracker.Droid.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new CustomBottomNavAppearanceTracker(this);
        }

        internal class CustomBottomNavAppearanceTracker : IShellBottomNavViewAppearanceTracker
        {

            private CustomShellRenderer customShellRenderer = null;

            public CustomBottomNavAppearanceTracker(CustomShellRenderer customShellRenderer)
            {
                this.customShellRenderer = customShellRenderer;
            }

            public void Dispose()
            {
                //throw new System.NotImplementedException();
            }

            public void ResetAppearance(BottomNavigationView bottomView)
            {
                bottomView.ItemIconTintList = null;

                // Manage state for text dependent on focus
                int[][] states = new int[][]
                {
                    new int[] { Android.Resource.Attribute.StateEnabled }, // Enabled
                    new int[] { -Android.Resource.Attribute.StateEnabled }, // Disabled
                    new int[] { -Android.Resource.Attribute.StateChecked }, // Unchecked
                    new int[] { Android.Resource.Attribute.StatePressed} // Pressed
                };

                int[] colors = new int[]
                {
                    Color.FromArgb("#FFA03A").ToInt(),
                    Colors.White.ToInt(),
                    Colors.White.ToInt(),
                    Color.FromArgb("#FFA03A").ToInt()
                };

                ColorStateList tabColorStateList = new ColorStateList(states, colors);
                bottomView.ItemTextColor = tabColorStateList;


                bottomView.SetBackgroundColor(Android.Graphics.Color.ParseColor("#0F2745"));               

            }

            public void SetAppearance(BottomNavigationView bottomView, ShellAppearance appearance)
            {
                bottomView.ItemIconTintList = null;                
                bottomView.SetBackgroundColor(Android.Graphics.Color.ParseColor("#0F2745"));
            }

            public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
            {
                bottomView.ItemIconTintList = null;               
                bottomView.SetBackgroundColor(Android.Graphics.Color.ParseColor("#0F2745"));
            }
        }
    }
}