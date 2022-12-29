﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalBlank.SqlFormatter.core.util
{
    public class JSLikeList<T> : IEnumerable
    {
        private readonly List<T> tList;

        public JSLikeList(List<T> tList)
        {
            this.tList = tList ?? new List<T>();
        }

        public List<T> ToList()
        {
            return tList;
        }

        public JSLikeList<R> Map<R>(Func<T, R> mapper)
        {
            List<R> list = new List<R>();
            foreach (T t in tList)
            {
                list.Add(mapper.Invoke(t));
            }
            return new JSLikeList<R>(list);
        }

        public string Join(string delimiter)
        {
            return string.Join(delimiter, tList);
        }

        public JSLikeList<T> With(List<T> other)
        { 
            List<T> list = new List<T>();
            list.AddRange(ToList());
            list.AddRange(other);
            return new JSLikeList<T>(list);
        }

        public string Join()
        {
            return Join(",");
        }

        public bool IsEmpty()
        { 
            return tList == null || tList.Count == 0;
        }

        public T Get(int index)
        {
            if (index < 0)
                return default;

            if (tList.Count <= index)
                return default;

            return tList.ElementAt(index);
        }

        public IEnumerator GetEnumerator()
        {
            return tList.GetEnumerator();
        }

        public int Size()
        {
            return tList.Count;
        }
    }
}