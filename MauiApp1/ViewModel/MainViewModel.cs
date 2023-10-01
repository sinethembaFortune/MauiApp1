
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;


        [RelayCommand]
        async void add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;
            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Opps","No Internet Access","OK");
                return;
            }
            Items.Add(Text);
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s))
                Items.Remove(s);
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Text={s}");
        }
    }
}
