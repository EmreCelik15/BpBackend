using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Abstract.IEntityRepository;

namespace DataAccess.Abstract
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>
    {
        List<OrderDetailDto> GetAllByAll(Expression<Func<OrderDetail, bool>> filter = null);
        void AddByAll(OrderDetailDto orderDetailDto);
    }
}
