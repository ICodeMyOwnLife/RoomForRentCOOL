using System.Linq;
using System.Windows.Input;
using CB.Model.Common;


namespace RoomForRentViewModel
{
    public abstract class NamedModelViewModel<TNamedModel>: ViewModelBase where TNamedModel: IdNameModelBase, new()
    {
        #region Fields
        private ICommand _addNewItemCommand;
        private bool _canEdit;
        private ICommand _deleteCommand;
        private TNamedModel[] _items;
        private string _name = typeof(TNamedModel).Name;
        private ICommand _saveCommand;
        private TNamedModel _selectedItem;
        #endregion


        #region Abstract
        protected abstract void DeleteItem(int id);

        protected abstract TNamedModel[] LoadItems();

        protected abstract TNamedModel SaveItem(TNamedModel item);
        #endregion


        #region  Properties & Indexers
        public virtual ICommand AddNewItemCommand => GetCommand(ref _addNewItemCommand, _ => AddNewItem());

        public bool CanEdit
        {
            get { return _canEdit; }
            private set { SetProperty(ref _canEdit, value); }
        }

        public virtual ICommand DeleteCommand
            => GetCommand(ref _deleteCommand, _ => Delete(), _ => SelectedItem?.Id != null);

        public virtual TNamedModel[] Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public virtual string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public virtual ICommand SaveCommand
            => GetCommand(ref _saveCommand, _ => Save(), _ => !string.IsNullOrEmpty(SelectedItem?.Name));

        public virtual TNamedModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (SetProperty(ref _selectedItem, value))
                {
                    CanEdit = SelectedItem != null;
                }
            }
        }
        #endregion


        #region Methods
        public virtual void AddNewItem()
        {
            SelectedItem = new TNamedModel();
        }

        public virtual void Delete()
        {
            if (SelectedItem.Id.HasValue)
            {
                DeleteItem(SelectedItem.Id.Value);
                Load();
            }
        }

        public virtual void Load()
        {
            Items = LoadItems();
            SelectedItem = Items?.Length > 0 ? Items[0] : null;
        }

        public virtual void Save()
        {
            var savedItem = SaveItem(SelectedItem);
            Items = LoadItems();
            SelectedItem = savedItem.Id.HasValue ? Items.FirstOrDefault(i => i.Id == savedItem.Id) : null;
        }
        #endregion
    }
}