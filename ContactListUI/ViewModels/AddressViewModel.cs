using Caliburn.Micro;
using ContactListUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactListUI.ViewModels
{
    public class AddressViewModel : Screen
    {
        private string _street;
        private string _number;
        private string _extension;
        private string _postalCode;
        private string _city;
        private AddressModel _selectedAddress;
        public AddressViewModel(AddressModel addressContact)
        {
            _selectedAddress = addressContact;
            _extension = addressContact.Extension;
            _number = addressContact.Number;
            _street = addressContact.Street;
            _postalCode = addressContact.PostalCode;
            _city = addressContact.City;
        }
        public string Street
        {
            get { return _street; }
            set 
            {
                _street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                NotifyOfPropertyChange(() => Number);
            }
        }

        public string Extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
                NotifyOfPropertyChange(() => Extension);
            }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                _postalCode = value;
                NotifyOfPropertyChange(() => PostalCode);
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }

    }
}
