namespace Dz_01._01.Models
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public int? PreviousPage => CurrentPage > 1 ? CurrentPage - 1 : (int?)null;
        public int? NextPage => CurrentPage < TotalPages ? CurrentPage + 1 : (int?)null;
    }
}
