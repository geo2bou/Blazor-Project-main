namespace BlazorApp.Extensions;

public static class PageableSearchOptionsFilter
{
    public static PageableResults<T> AsPagedResponse<T>(this List<T> items, int totalItems)
    {
        return new PageableResults<T>().From(items, totalItems);
    }
}