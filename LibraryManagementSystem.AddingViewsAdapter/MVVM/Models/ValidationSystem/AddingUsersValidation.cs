using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels;

namespace LibraryManagementSystem.MVVM.Models.ValidationSystem
{
	public class AddingUsersValidation
	{
		private readonly AddingUsersModel model;

		public AddingUsersValidation(AddingUsersModel model)
		{
			this.model = model;
		}

		public List<string> Validate
		{
			get
			{
				var errors = new List<string>();

				if (model.Pesel.Length != 11)
					errors.Add("PESEL should contain 11 numbers!");

				if (!model.Email.Contains('@'))
					errors.Add("Email address is incorrect!");

				if (model.Name.Any(char.IsDigit))
					errors.Add("Name cannot contain any digit!");

				if (model.Surname.Any(char.IsDigit))
					errors.Add("Surname cannot contain any digit!");

				if (model.Name == String.Empty || model.Name == null)
					errors.Add("Name cannot be empty!");

				if (model.Surname == String.Empty || model.Surname == null)
					errors.Add("Surname cannot be empty!");

				if (model.Email == String.Empty || model.Email == null)
					errors.Add("Email cannot be empty!");

				return errors;
			}
		}
	}
}
