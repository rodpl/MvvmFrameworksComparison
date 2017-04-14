﻿using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Mugen.ViewModels
{
    public class CompositeViewModel : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly CompositeNestedViewModel _firstNestedViewModel;
        private readonly CompositeNestedViewModel _secondNestedViewModel;
        private readonly CompositeNestedViewModel _thirdNestedViewModel;
        private string _displayName;
        private int _id;

        #endregion

        #region Constructors

        public CompositeViewModel()
        {
            _firstNestedViewModel = GetViewModel<CompositeNestedViewModel>();
            _firstNestedViewModel.DisplayName = "First nested view model";

            _secondNestedViewModel = GetViewModel(container => new CompositeNestedViewModel {DisplayName = "Second nested view model"});

            _thirdNestedViewModel = new CompositeNestedViewModel {DisplayName = "Third nested view model"};
            ViewModelProvider.InitializeViewModel(_thirdNestedViewModel, DataContext.Empty);
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id)
                {
                    return;
                }
                _id = value;
                _displayName = "Composite view model " + _id;
                OnPropertyChanged();
                this.OnPropertyChanged(() => vm => vm.DisplayName);
            }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public CompositeNestedViewModel FirstNestedViewModel
        {
            get { return _firstNestedViewModel; }
        }

        public CompositeNestedViewModel SecondNestedViewModel
        {
            get { return _secondNestedViewModel; }
        }

        public CompositeNestedViewModel ThirdNestedViewModel
        {
            get { return _thirdNestedViewModel; }
        }

        #endregion
    }
}