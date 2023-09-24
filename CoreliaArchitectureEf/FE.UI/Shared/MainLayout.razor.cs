using System;
using System.Collections.Generic;
using System.Linq;
using FE.UI.Theme;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;
using MudBlazor.ThemeManager;

namespace FE.UI.Shared
{
    public partial class MainLayout
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        private ThemeManagerTheme _themeManager = new ThemeManagerTheme();
        private List<BreadcrumbItem> _items = new List<BreadcrumbItem> { new BreadcrumbItem("Home", href: "/") };

        public bool _drawerOpen = true;
        public bool _themeManagerOpen = false;
        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        void OpenThemeManager(bool value)
        {
            _themeManagerOpen = value;
        }

        void UpdateTheme(ThemeManagerTheme value)
        {
            _themeManager = value;
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            _themeManager.Theme = new MudBlazorAdminDashboard();
            _themeManager.DrawerClipMode = DrawerClipMode.Always;
            _themeManager.FontFamily = "Montserrat";
            _themeManager.DefaultBorderRadius = 3;
            NavigationManager.LocationChanged += LocationChanged;
        }
        void OnClickLogout()
        {
            NavigationManager.NavigateTo($"/logout", true);
        }
        private void LocationChanged(object sender, LocationChangedEventArgs e)
        { 
            // Get the current location without the base path          
            var location = NavigationManager.ToBaseRelativePath(e.Location);

            // Split the location by '/' and remove any empty segments
            var segments = location.Split('/').Where(s => !string.IsNullOrEmpty(s)).ToArray();

            // Clear the existing items
            _items.Clear();

            // Add a default item for the home page
            _items.Add(new BreadcrumbItem("Home", href: "/"));

            // Loop through the segments and add an item for each one
            for (int i = 0; i < segments.Length; i++)
            {
                _items.Clear();

                // Get the segment text and capitalize the first letter
                var text = segments[i];
                text = char.ToUpper(text[0]) + text.Substring(1);

                // Get the segment href by joining the previous segments
                var href = "/" + string.Join('/', segments.Take(i + 1));

                // Add a new item with the text and href

                _items.Add(new BreadcrumbItem(text, href: href));
            }

            // Refresh the UI
            StateHasChanged();
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= LocationChanged;
        }
    }
}