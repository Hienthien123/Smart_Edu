using System.Linq;

namespace LamLaiBaiCuoiKhoa.Helpers
{

    public class PageResult<T>
    {
        public Pagination Pagination { get; set; }
        public IEnumerable<T> Data { get; set; }   
        public PageResult(Pagination pagination, IEnumerable<T> data)
        {
            Pagination = pagination;
            Data = data;
        }
        public static PageResult<T> ToPagedResult(Pagination pagination, IEnumerable<T> query)
        {
            pagination.PageNumber = pagination.PageNumber < 1 ? 1 : pagination.PageNumber;

            int totalCount = query.Count(); 

            query = query.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize).AsQueryable();

            return new PageResult<T>(pagination, query)
            {
                Pagination = { TotalCount = totalCount } 
            };
        }
    }
}
