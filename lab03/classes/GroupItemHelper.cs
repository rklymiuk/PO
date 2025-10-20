namespace lab03.classes;

static class GroupItemsHelper {
    public static List<GroupedItemsByKeyReport<TKey,TValue>>? GroupItemsBy<TKey, TValue>(
        IEnumerable<TValue> items,
        Func<TValue,TKey> keySelector) {
        
        var groupedItems = items
            .GroupBy(keySelector) 
            .Select(group => new GroupedItemsByKeyReport<TKey, TValue>(
                group.Key,  
                group.ToList()         
            ))
            .ToList();
        return groupedItems;
    }
}