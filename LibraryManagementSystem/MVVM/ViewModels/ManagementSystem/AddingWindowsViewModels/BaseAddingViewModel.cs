using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels
{
    internal abstract class BaseAddingViewModel : BasicViewModel
    {
        protected dynamic model;
        protected ICommand? add;
        public bool IsOne
        {
            get => model.IsOne;
            set
            {
                model.IsOne = value;
                OnPropertyChanged(nameof(IsOne));
            }
        }

        public bool IsMany
        {
            get => model.IsMany;
            set
            {
                model.IsMany = value;
                OnPropertyChanged(nameof(IsMany));
            }
        }

        public string ManyValue
        {
            get => model.ManyValue;
            set
            {
                model.ManyValue = value;
                OnPropertyChanged(nameof(ManyValue));
            }
        }

        public bool ManyValueActive
        {
            get => model.ManyValueActive;
            set
            {
                model.ManyValueActive = value;
                OnPropertyChanged(nameof(ManyValueActive));
            }
        }

        public abstract ICommand Add { get; }
    }
}
