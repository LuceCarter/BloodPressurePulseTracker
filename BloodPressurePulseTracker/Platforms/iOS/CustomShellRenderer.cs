
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using UIKit;
using CoreGraphics;

namespace BloodPressurePulseTracker.iOS
{
    public class CustomShellRenderer : ShellRenderer
    {
        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection) { var renderer = base.CreateShellSectionRenderer(shellSection); if (renderer != null) { } return renderer; }

        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new TabbarIconsAppearance();
        }
    }

    public class TabbarIconsAppearance : IShellTabBarAppearanceTracker
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void ResetAppearance(UITabBarController controller)
        {
            DisplayColorIcons(controller);

        }


        public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
            DisplayColorIcons(controller);
            UITabBar tabBar = controller.TabBar;
            UIColor tabBarColor = UIColor.FromRGB(15, 39, 69);

            if (tabBar != null)
            {
                tabBar.BackgroundColor = tabBarColor;
                tabBar.TintColor = UIColor.FromRGB(255, 160, 58);
                tabBar.UnselectedItemTintColor = UIColor.White;
            }
        }

        public void UpdateLayout(UITabBarController controller)
        {
            DisplayColorIcons(controller);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        private void DisplayColorIcons(UITabBarController controller)
        {
            if (controller.TabBar.Items != null)
            {
                foreach (UITabBarItem tabbaritem in controller.TabBar.Items)
                {
                    tabbaritem.Image = ScalingImageToSize(tabbaritem.Image, new CGSize(30, 30));
                    tabbaritem.Image = tabbaritem.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    tabbaritem.SelectedImage = tabbaritem.SelectedImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                }
            }
        }

        public UIImage ScalingImageToSize(UIImage sourceImage, CGSize newSize)
        {

            if (UIScreen.MainScreen.Scale == 2.0) //@2x iPhone 6 7 8 
            {
                UIGraphics.BeginImageContextWithOptions(newSize, false, 2.0f);
            }


            else if (UIScreen.MainScreen.Scale == 3.0) //@3x iPhone 6p 7p 8p...
            {
                UIGraphics.BeginImageContextWithOptions(newSize, false, 3.0f);
            }

            else
            {
                UIGraphics.BeginImageContext(newSize);
            }

            sourceImage.Draw(new CGRect(0, 0, newSize.Width, newSize.Height));

            UIImage newImage = UIGraphics.GetImageFromCurrentImageContext();

            UIGraphics.EndImageContext();

            return newImage;

        }

    }
}

