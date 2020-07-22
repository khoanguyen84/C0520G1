using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NewManagement
{
    class SortByTitle : IComparer
    {
        public int Compare(object x, object y)
        {
            return string.Compare(((News)x).Title,((News)y).Title);
        }
    }

    class SortByAuthor : IComparer
    {
        public int Compare(object x, object y)
        {
            return string.Compare(((News)x).Author, ((News)y).Author);
        }
    }

    class SortByTitleGeneric<T> : IComparer<News>
    {
        public int Compare([AllowNull] News x, [AllowNull] News y)
        {
            return string.Compare(x.Title, y.Title);
        }
    }

    class SortByAuthorGeneric<T> : IComparer<News>
    {
        public int Compare([AllowNull] News x, [AllowNull] News y)
        {
            return string.Compare(x.Author, y.Author);
        }
    }
}
