using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

﻿namespace C_2_Lessons
{
    internal class ObservableList<T>
    {
        private List<T> _list;
        Func<T, bool> AddPredicate;
        public event Action<T> OnAdd;
        public event Action<T> OnRemove;

        public ObservableList(Func<T, bool> predicate)
        {
            AddPredicate = predicate;
            _list = new List<T>();
        }
        public ObservableList()
        {
            AddPredicate = (T t) => true;
            _list = new List<T>();
        }

        public void TryAdd(T item)
        {
            if (AddPredicate(item)) _list.Add(item);
            else return;
            OnAdd?.Invoke(item);
        }
        public void Remove(T item)
        {
            _list.Remove(item);
            OnRemove?.Invoke(item);
        }
        public ObservableList<T> Where(Func<T, bool> predicate)
        {
            ObservableList<T> list = new ObservableList<T>(AddPredicate);
            foreach (var item in _list)
            {
                if (predicate(item)) list.TryAdd(item);
            }
            return list;
        }
        private void ForEach(Action<string> action)
        {
            foreach (var item in _list)
            {
                action(item.ToString());
            }
        }

        public void PrintAll()
        {
            ForEach(Console.WriteLine);
        }
    }
}