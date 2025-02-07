using System;

using Microsoft.EntityFrameworkCore;

namespace EFCoreWithAspDotnetCore.Models
{
    public class PaginatedList<T> // Generic
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public int FirstItemIndex => (PageIndex - 1) * PageSize + 1;

        public int LastItemIndex => Math.Min(PageIndex * PageSize, TotalItems);

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            // Count total number of items in data source
            var count = await source.CountAsync();

            /**
              * Skip((pageIndex - 1) * pageSize) skips over the items that come before the start
                of the current page.
              * Skip method bypasses a specified number of elements in a sequence then returns
                the remaining elements.
              * For example, if pageIndex is 2 and pageSize is 10, it would skip the first 10
                items.
              * Take(pageSize) selects the next pageSize items after the skipping
              * Take method returns a specified number of contiguous elements from the start
                of a sequence.
              * For example, if pageIndex is 2 and pageSize is 10, this would take items 11 to
                20.
              * ToListAsync() executes the query and materializes the results into a list
                asynchronously
            */
            var items = await source.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
