namespace BlazorApp.Extensions;

public class PageableResults<T>
{
    public PageableResults() {}

    public PageableResults<T> From(List<T> items, int totalItems)
    {
        var result = new PageableResults<T>();
        result.Items = items;
        result.TotalItems = totalItems;
        //result.Page = parameters.Page;
        //result.PageSize = parameters.PageSize;
        return result;
    }

    public List<T> Items { get; set; } = [];
    public int TotalItems { get; set; }
    //public int Page { get; set; }
    //public int PageSize { get; set; }
    //public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    //public bool HasPreviousPage => Page > 1;
    //public bool HasNextPage => Page < TotalPages;
}
