 using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.BLL.Specifications
{
    public class BaseSpecifictions<T> : ISpecifications<T>
    {
        public BaseSpecifictions()
        {

        }
        public Expression<Func<T, bool>> criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnabled { get; set; }

        public BaseSpecifictions(Expression<Func<T, bool>> criteria)
        {
            this.criteria = criteria;
        }


        public void AddInclude(Expression<Func<T, object>> Include)
        {

            Includes.Add(Include);
        }
        public void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;

        }
        public void AddOrderByDec(Expression<Func<T, object>> orderByDec)
        {
            OrderByDesc = orderByDec;

        }
        public void ApplyPagination(int skip , int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;

        }

    }
}
