using DataAccess.Abstract;
using Entities;
using Services.Abstract;
using Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class OrderDetailService : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;

        public OrderDetailService(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public IResult Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult("Eklendi.");
        }

        public IResult AddByAll(OrderDetailDto orderDetailDto)
        {
            _orderDetailDal.AddByAll(orderDetailDto);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
            return new SuccessResult("Silindi.");
        }

        public IDataResult<List<OrderDetail>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll());
        }

        public IDataResult<List<OrderDetailDto>> GetAllByAll(Expression<Func<OrderDetail, bool>> filter = null)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDetailDal.GetAllByAll());
        }

        public IResult Update(OrderDetail orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
            return new SuccessResult("Güncellendi");
        }
    }
}
