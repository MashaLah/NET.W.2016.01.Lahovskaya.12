﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IBookListStorage
    {
        void SaveBookList(IEnumerable<Book> bookList);
        IEnumerable<Book> LoadBookList();
    }
}
