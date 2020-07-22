using System;
using System.Collections.Generic;
using System.Text;

namespace CustomGenericDemo
{
    /// <summary>
    /// T ~ Type (Data type)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyGeneric<T> where T : class
    {
        private T[] list;
        public int Count { get; private set; }
        public MyGeneric()
        {
            list = new T[0];
        }

        //init indexer
        public T this[int index]
        {
            get
            {
                if(index>=0 && index < list.Length)
                {
                    return list[index];
                }
                throw new IndexOutOfRangeException($"index must in between 0 and {list.Length - 1}");
            }
        }

        //Add
        public void Add(T item)
        {
            Array.Resize(ref list, list.Length + 1);
            list[list.Length - 1] = item;
            SetCount();

        }
        //Remove
        public void Remove(T item)
        {
            int pos = Find(item);
            RemoveAt(pos);
        }

        //RemoveAt
        public void RemoveAt(int index)
        {
            if(index >=0 && index < list.Length)
            {
                for(int i=index; i< list.Length-1; i++)
                {
                    list[i] = list[i + 1];
                }
                Array.Resize(ref list, list.Length - 1);
                SetCount();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }


        //Set count value
        private void SetCount()
        {
            Count = list.Length;
        }

        public int Find(T item)
        {
            for(int i=0; i<list.Length; i++)
            {
                if(list[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public T FindFirst(T item)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Equals(item))
                {
                    return list[i];
                }
            }
            return default(T);
        }
    }
}
