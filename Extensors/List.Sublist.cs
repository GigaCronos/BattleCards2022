namespace Extensors;
public static class ListExtensions{
   
    //Returns a new List that is the Range [l,r] of the Given One
    public static List<T> SubList<T>(this List<T> items,int l,int r){
            List<T> L=new List<T>();
            for(int i=l;i<=r;i++){
                if(i>=items.Count)break;
                L.Add(items[i]);
            }
            return L;
    }
}