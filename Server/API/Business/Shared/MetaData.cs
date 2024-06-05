using CloudinaryDotNet.Actions;

namespace API.Business.Shared
{
    public class MetaData
    {
        public int Count { get; set; }
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
        public int TotolPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotolPages;
    }
}
