using System.Collections.Generic;
using System.Windows;

namespace ContactApp
{
    public partial class MainWindow : Window
    {
        private List<Contact> contacts = new List<Contact>();

        public MainWindow()
        {
            InitializeComponent();
            ContactsListBox.ItemsSource = contacts;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                var contact = new Contact { Name = NameTextBox.Text, PhoneNumber = PhoneTextBox.Text };
                contacts.Add(contact);
                RefreshList();
                NameTextBox.Clear();
                PhoneTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter both name and phone number.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContactsListBox.SelectedItem is Contact selected)
            {
                contacts.Remove(selected);
                RefreshList();
            }
        }

        private void RefreshList()
        {
            ContactsListBox.ItemsSource = null;
            ContactsListBox.ItemsSource = contacts;
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString() => $"{Name} ({PhoneNumber})";
    }
}
