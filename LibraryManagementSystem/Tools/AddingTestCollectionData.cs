using LibraryManagementSystem.Data.DataModels;
using LibraryManagementSystem.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace LibraryManagementSystem.Tools
{
    public class AddingTestCollectionData : IAddingTestCollectionData<LibDataModel>
    {
        public AddingTestCollectionData()
        {
                
        }

        public void AddingTestAdminsCollection(
            ref IList<LibDataModel> collection, uint numberOfRecords)
        {
            if (collection != null)
            {
                for (uint i = 0; i <= numberOfRecords; i++)
                {
                    LibDataModel library = new LibDataModel()
                    {
                        Id = collection.Count() > 0
                            ? collection.ToList().Max(x => x.Id) + 1 : 1,
                        Address = (string?)"ul. Marszałkowska 1",
                        TelephoneNumber = 923784698,
                        WebsiteAddress = (string?)"https://testwebsite.com",
                        EmailAddress = (string?)"test@gmail.com",
                        NipNumber = 1111111111,
                        RegonNumber = 1111111111,
                        DunsNumber = 1111111111,
                        DateOfCommencementOfActivities = (DateTime?)DateTime.Now,
                        Voivodeship = (string?)"Mazowieckie",
                        City = (string?)"Warsaw",
                        ZipCode = 05235
                    };

                    collection.Add(library);
                }
            }
        }
    }
}
