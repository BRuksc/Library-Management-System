﻿using LibraryManagementSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces.Data
{
    internal interface IManyRecordsOperations<T>
    {
        public Task<bool> AddMany(T[] data);
        public Task<bool> RemoveMany(T[] data);
        public List<T> SelectAll(int LibraryId);
        public List<T> SelectAll(LibDataModel library);
    }
}
