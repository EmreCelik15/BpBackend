using Entities;
using Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IOrderDetailService
    {
        IResult Add(OrderDetail orderDetail);
        IResult Delete(OrderDetail orderDetail);
        IResult Update(OrderDetail orderDetail);
        IDataResult<List<OrderDetail>> GetAll();
        IDataResult<List<OrderDetailDto>> GetAllByAll(Expression<Func<OrderDetail, bool>> filter = null);
        IResult AddByAll(OrderDetailDto orderDetailDto);
    }
}
