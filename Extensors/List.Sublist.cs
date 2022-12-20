namespace Extensors;
public static class ListExtensions{
    public static List<T> SubList<T>(this List<T> items,int l,int r){
            List<T> L=new List<T>();
            for(int i=l;i<=r;i++){
                if(i>=items.Count)break;
                L.Add(items[i]);
            }
            return L;
    }
}