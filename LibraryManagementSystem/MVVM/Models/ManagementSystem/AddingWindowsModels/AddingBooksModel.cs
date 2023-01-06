using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels
{
    internal class AddingBooksModel : BaseAddingModel
    {
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public string DateOfPublished { get; set; } = String.Empty;

        public override Task<bool> Add()
        {
            throw new NotImplementedException();
        }
    }
}
