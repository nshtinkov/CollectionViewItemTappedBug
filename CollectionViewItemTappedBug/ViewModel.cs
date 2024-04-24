using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CollectionViewItemTappedBug
{
	public class ViewModel
	{
		public ObservableCollection<ItemDescriptor> GalleryList { get; private set; }

		public ObservableCollection<ItemDescriptor> SelectedItems { get; set; } = [];

		public ICommand ItemPressedCommand { get; private set; }

		public ViewModel()
		{
			GalleryList = new ObservableCollection<ItemDescriptor>();

			AddItems(25);

			ItemPressedCommand = new Command((item) => { if (item is ItemDescriptor collectionItem) OnItemPressed(collectionItem); });
		}

		void OnItemPressed(ItemDescriptor item)
		{
			if (SelectedItems.Contains(item))
			{
				SelectedItems.Remove(item);
				item.IsSelected = false;
			}
			else
			{
				SelectedItems.Add(item);
				item.IsSelected = true;
			}
		}

		void AddItems(int count)
		{
			for (int index = 0; index < count; index++)
			{
				GalleryList.Add(new ItemDescriptor());
			}
		}

	}
}
