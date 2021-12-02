using Microsoft.EntityFrameworkCore;
using ReactAngularPracticeApi.Data.Context;
using ReactAngularPracticeApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactAngularPracticeApi.Repository.OrderRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrderList();
        Task<Order> RetrieveOrderInfo(int orderId);
        Task<Order> OrderNewProduct(Order order);
        Task<string> DeleteOrder(int orderId);
        Task<string> UpdateProductDetail(int orderId,Order order);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly PracticeContext _context;

        public OrderRepository(PracticeContext context)
        {
            _context = context;
        }

        public async Task<string> DeleteOrder(int orderId)
        {
            try
            {
                var response = await _context.Orders.FindAsync(orderId);
                _context.Orders.Remove(response);
                await _context.SaveChangesAsync();
                return "Deleted SuccessFully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Order>> GetOrderList()
        {
            try
            {
                var res = await _context.Orders.ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Order> OrderNewProduct(Order order)
        {
            try
            {
                order.OrderDate = DateTime.Now;
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Order> RetrieveOrderInfo(int orderId)
        {
            try
            {
                var res = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == orderId);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> UpdateProductDetail(int orderId, Order order)
        {
            try
            {
                var res = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == orderId);
                res.ProductName = order.ProductName;
                res.ProductSize = order.ProductSize;
                res.ProductQty = order.ProductQty;
                res.Price = order.Price;
                res.OrderDate = res.OrderDate;
                res.DeliveryDate = DateTime.Now;
                res.DeliveryManName = order.DeliveryManName;
                _context.Update(res);
                await _context.SaveChangesAsync();
                return "Updated Record";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
