using Caliburn.Micro;
using ContactListUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ContactListUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName;
        private string _lastName;
        private BindableCollection<ContactModel> _contacts = new BindableCollection<ContactModel>();
        private ContactModel _selectedContact;

        static HttpClient client = new HttpClient();

        public ShellViewModel()
        {
            //Contacts.Add(new ContactModel { FirstName = "Arno", LastName = "Stas" });
            GetContacts();
        }

        public async void GetContacts()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44305/api/contacts/");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                
                ContactModel[] contactModels = JsonConvert.DeserializeObject<ContactModel[]>(responseBody);
                foreach(ContactModel contactModel in contactModels)
                {
                    Contacts.Add(contactModel);
                }

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public BindableCollection<ContactModel> Contacts
        {
            get { return _contacts; }
            set { _contacts = value; }
        }

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set 
            { 
                _selectedContact = value;
                NotifyOfPropertyChange(() => SelectedContact);
            }
        }

        public bool CanClearText(string firstName, string lastName) => !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new AddressViewModel());
        }
        public void LoadPageTwo()
        {
            ActivateItem(new PhoneNumberViewModel());
        }
    }
}
