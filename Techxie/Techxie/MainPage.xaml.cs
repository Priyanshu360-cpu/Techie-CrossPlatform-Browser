using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Techxie
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            URL.Text = "https://www.google.com";
            LoadPage();
        }

        private void EntryURL_Completed(object sender, EventArgs e)
        {
            LoadPage();
        }

        private void MyWebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            Progress(true);
            URL.Text = e.Url.ToString();
        }

        private void Go(object sender, EventArgs e)
        {
            LoadPage();
        }

        public void LoadPage()
        {
            Progress(true);
            if (URL.Text != null && !URL.Text.ToString().Trim().Equals(""))
                myWebView.Source = new UriBuilder(URL.Text.ToString()).Uri;
        }

        private void MyWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            URL.Text = e.Url.ToString();
            Progress(false);
        }

        public void Progress(Boolean show)
        {
            activityIndicator.IsVisible = show;
            activityIndicator.IsRunning = show;
            btnLoad.IsVisible = !show;
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            Progress(true);
            if (myWebView.CanGoBack)
                myWebView.GoBack();
            else
            {
                URL.Text = "https://www.google.com";
                LoadPage();

            }
        }
    }
}