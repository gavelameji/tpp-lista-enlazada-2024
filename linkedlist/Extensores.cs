using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist
{
    public static class Extensores
    {
        public static T Buscar<T>(this IEnumerable<T> en, Predicate<T> pr)
        {
            foreach (T t in en)
                if (pr(t)) return t;
            return default(T);
        }

        public static IEnumerable<T> Filtrar<T>(this IEnumerable en, Predicate<T> pr)
        {
            IList<T> res = new List<T>();
            foreach (T t in en)
                if (pr(t)) res.Add(t);
            return res;
        }

        public static T2 Reducir<T1, T2>(this IEnumerable<T1> en, Func<T1, T2, T2> f, T2 op = default(T2))
        {
            T2 res = default(T2);
            foreach (T1 t in en)
                res = f(t, res);
            return res;
        }
        public static IEnumerable<T> Invertir<T>(this IEnumerable<T> list)
        {
            IList<T> reversedList = new List<T>();
            foreach (var item in list)
            {
                reversedList.Insert(0, item);
            }
            return reversedList;
        }

        public static IEnumerable<T2> MapLazy<T1, T2>(this IEnumerable<T1> en, Func<T1, T2> f)
        {
            foreach(T1 elem in en)
                yield return f(elem);
        }

        public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> en, Func<T1, T2> f)
        {
            IList<T2> res = new List<T2>();
            foreach (T1 elem in en)
                res.Add(f(elem));
            return res;
        }

        public static void ForEach<T>(this IEnumerable<T> en, Action<T> action)
        {
            foreach(T elem in en)
                action(elem);
        }
    }
}
