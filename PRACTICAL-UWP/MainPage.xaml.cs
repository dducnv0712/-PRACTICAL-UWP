using PRACTICAL_UWP.Entities;
using PRACTICAL_UWP.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListContact.ItemsSource = contactServices.GetAll();
/*            List<Contact> contact = new List<Contact>();
*/           /* ListContact.ItemsSource = contact;
            contact.Add(new Contact
            {
                name = "Đức",
                phone_number = "02154646565"
            });
*/
            
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var student = new Contact()
            {
                name = txtName.Text,
                phone_number = txtPhone.Text
            };
            var contactList = contactServices.Search(student);
            if(contactList.Count != 0 )
            {
                ListContact.ItemsSource = contactList;
            }
            else
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Notify?";
                dialog.Content = "No results!";
                dialog.CloseButtonText = "Cancel";
                await dialog.ShowAsync();
            }


        }
    }
}
