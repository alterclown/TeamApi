using ReactAngularPracticeApi.Data.Entities;
using ReactAngularPracticeApi.Repository.OrderRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactAngularPracticeApi.Service.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrderList();
        Task<Order> RetrieveOrderInfo(int orderId);
        Task<Order> OrderNewProduct(Order order);
        Task<string> DeleteOrder(int orderId);
        Task<string> UpdateProductDetail(int orderId, Order order);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> DeleteOrder(int orderId)
        {
            try
            {
                var res = await _repository.DeleteOrder(orderId);
                return res;
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
                var res = await _repository.GetOrderList();
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
                var res = await _repository.OrderNewProduct(order);
                return res;
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
                var res = await _repository.RetrieveOrderInfo(orderId);
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
                var res = await _repository.UpdateProductDetail(orderId,order);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
