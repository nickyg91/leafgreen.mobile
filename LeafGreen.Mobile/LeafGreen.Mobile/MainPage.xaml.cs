using System;
using System.Linq;
using LeafGreen.Mobile.ViewModels;
using Xamarin.Forms;

namespace LeafGreen.Mobile
{
	public partial class MainPage : ContentPage
	{
	    private readonly MainPageViewModel _viewModel;
		public MainPage()
		{
		    _viewModel = new MainPageViewModel();
            InitializeComponent();
		}

	    protected override async void OnAppearing()
	    {
	        try
	        {
	            _viewModel.Gardens = await _viewModel.GetGardensByDeviceIdAsync();
	            var hasGardens = _viewModel.Gardens.Any();
	            GardensScrollView.IsVisible = hasGardens;
	            NoGardensStackLayout.IsVisible = !hasGardens;
	        }
	        catch (Exception e)
	        {
	            await DisplayAlert("Error", e.Message, "Ok");
	        }
	    }
	}
}
