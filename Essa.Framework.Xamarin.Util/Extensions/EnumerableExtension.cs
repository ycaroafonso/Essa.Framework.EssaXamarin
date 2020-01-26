namespace Essa.Framework.Util.Extensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;


    public static class EnumerableExtension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> valor)
        {
            return new ObservableCollection<T>(valor);
        }
    }
}
