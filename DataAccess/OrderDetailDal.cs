using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDal : EntityRepository<OrderDetail, BupaAcıbademDatabase>, IOrderDetailDal
    {
        public List<OrderDetailDto> GetAllByAll(Expression<Func<OrderDetail, bool>> filter = null)
        {
            using (BupaAcıbademDatabase bupaAcıbademContext=new BupaAcıbademDatabase())
            {
                var result = from od in bupaAcıbademContext.OrderDetails
                             join c in bupaAcıbademContext.Customers
                             on od.CustomerId equals c.Id
                             join p in bupaAcıbademContext.Products
                             on od.ProductId equals p.Id
                             join o in bupaAcıbademContext.Orders
                             on od.OrderId equals o.Id
                             select new OrderDetailDto
                             {
                                 FirstName=c.FirstName,
                                 LastName = c.LastName,
                                 Name = p.Name,
                                 Description = p.Description,
                                 Price = p.Price,
                                 OrderName = o.OrderName,
                                 Installment = o.Installment
                             };
                //foreach (var item in result)
                //{
                //    Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
                //        item.FirstName, item.LastName, item.Name, item.Description, item.Price, item.OrderName, item.Installment);
                //}

                return result.ToList();
            }

        }
        
        public void AddByAll(OrderDetailDto orderDetailDto)
        {
            using (BupaAcıbademDatabase bupaAcıbademContext=new BupaAcıbademDatabase())
            {
                var result = from od in bupaAcıbademContext.OrderDetails
                             join c in bupaAcıbademContext.Customers
                             on od.CustomerId equals c.Id
                             join p in bupaAcıbademContext.Products
                             on od.ProductId equals p.Id
                             join o in bupaAcıbademContext.Orders
                             on od.OrderId equals o.Id
                             select new OrderDetailDto
                             {
                                 FirstName=c.FirstName,
                                 LastName = c.LastName,
                                 Name = p.Name,
                                 Description = p.Description,
                                 Price = p.Price,
                                 OrderName = o.OrderName,
                                 Installment = o.Installment
                             };
                
                var orderDetailDtos= result.ToList();

                Customer customer = new Customer()
                {
                    FirstName = orderDetailDto.FirstName,
                    LastName=orderDetailDto.LastName,
                    
                };
                
                Order order = new Order()

                {
                    Installment = orderDetailDto.Installment,
                    OrderName=orderDetailDto.OrderName,
                    
                    
                };

                Product product = new Product()
                {
                    Description=orderDetailDto.Description,
                    Name=orderDetailDto.Name,
                    Price=orderDetailDto.Price,
                    
                };

                var productEntity = bupaAcıbademContext.Entry(product);
                var orderEntity = bupaAcıbademContext.Entry(order);
                var customerEntity = bupaAcıbademContext.Entry(customer);
                productEntity.State = EntityState.Added;
                orderEntity.State = EntityState.Added;
                customerEntity.State = EntityState.Added;
                bupaAcıbademContext.SaveChanges();
            }

        }
    }


}
