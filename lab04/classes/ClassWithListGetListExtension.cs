using lab04.Interfaces;

namespace lab04.classes;

public static class ClassWithListGetListExtension
{
    public static IList<T> GetList<T>(this IClassWithIList obj)
    {
        if (obj == null) return null;
        var objType = obj.GetType();
        var collection = objType
            .GetProperties()
            .FirstOrDefault(p => typeof(IList<T>).IsAssignableFrom(p.PropertyType));
        if(collection == null)return null;
        if(collection.GetValue(obj) is not  IList<T> list) return null;
        return list;

    }

    public static void Add<T>(this IClassWithIList obj, T item)
    {
         GetList<T>(obj)?.Add(item); 
}

    public static void AddRange<T>(this IClassWithIList obj, IList<T> items)
    {
        if (obj == null || items == null)
        {
            return;
        }
        var list = GetList<T>(obj);
        if (list == null)
        {
            
            return;
        }
        foreach (var item in items)
        {
            list.Add(item);
        }
    }

    public static void Clear<T>(this IClassWithIList obj)
    {
        
            GetList<T>(obj)?.Clear();
        
    }

    public static bool Contains<T>(this IClassWithIList obj, T item)
    {
        if (obj == null) return false;
        
        var list = GetList<T>(obj);

        
        return list != null && list.Contains(item);
    }

    public static int IndexOf<T>(this IClassWithIList obj, T item)
    {
        if (obj == null) return -1;
        var list = GetList<T>(obj);
        if( list == null) return -1;
        return list.IndexOf(item);
    }

    public static bool Remove<T>(this IClassWithIList obj, T item)
    {
        var list = GetList<T>(obj);
        return list?.Remove(item) ?? false;
    }

    public static void RemoveAt<T>(this IClassWithIList obj, int index)
    {
        var list = GetList<T>(obj);
        if (index >= 0 && index < list.Count)
        {
            list.RemoveAt(index);
        }
    }
    public static void Update<T>(this IClassWithIList obj, T oldItem, T newItem)
    {
        var list = GetList<T>(obj);
        int index = list?.IndexOf(oldItem) ?? -1;
        if (index >= 0 && index < list.Count)
        {
            list[index] = newItem;
        }
    }

    public static void ForEach<T>(this IClassWithIList obj, Action<T> action)
    {
        var list = GetList<T>(obj);
        if (action != null)
        {
            foreach (var e in list) action(e);
        }
    }

    public static void RemoveAll<T>(this IClassWithIList obj, Func<T, bool> predicate)
    {
        var list = GetList<T>(obj);
        if (list != null)
        {
            var itemsToRemove = list.Where(predicate).ToList();
            foreach (var item in itemsToRemove)
            {
                list.Remove(item);
            }
        }
    }
    
    
}