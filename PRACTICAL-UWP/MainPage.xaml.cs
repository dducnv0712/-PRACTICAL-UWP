using PRACTICAL_UWP.Entities;
using PRACTICAL_UWP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PRACTICAL_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ContactServices contactServices = new ContactServices();
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += LoadedList;


        }

        private void LoadedList(object sender, RoutedEventArgs e)
        {
            ListContact.ItemsSource = contactServices.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var student = new Contact()
            {
                name =txtName.Text,
                phone_number = txtPhone.Text
            };
            contactServices.Save(student);
        }
    }
}
