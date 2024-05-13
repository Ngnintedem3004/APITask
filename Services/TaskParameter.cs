namespace ManagementDesTaches.Services
{
    public class TaskParameter
    {
        const int MaxPageSize = 50;
        public int PageNumber = 1;
            int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize= (value>MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
