using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GetzSampleApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string btnColor = string.Empty;
        string btnColorRed = string.Empty;

        string placeholderid = string.Empty;
        string placeholderfn = string.Empty;
        string placeholderln = string.Empty;
        string lbldob = string.Empty;
        string lblgender = string.Empty;

        public string PlaceholderId
        {
            get { return placeholderid; }
            set { SetProperty(ref placeholderid, value); }
        }
        public string PlaceholderFirstName
        {
            get { return placeholderfn; }
            set { SetProperty(ref placeholderfn, value); }
        }
        public string PlaceholderLastName
        {
            get { return placeholderln; }
            set { SetProperty(ref placeholderln, value); }
        }
        public string LblDob
        {
            get { return lbldob; }
            set { SetProperty(ref lbldob, value); }
        }
        public string LblGender
        {
            get { return lblgender; }
            set { SetProperty(ref lblgender, value); }
        }

        public string BtnAddPatientColor
        {
            get { return btnColor; }
            set { SetProperty(ref btnColor, value); }
        }
        public string BtnDelete
        {
            get { return btnColorRed; }
            set { SetProperty(ref btnColorRed, value); }
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName] string propertyName = "",
        Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
