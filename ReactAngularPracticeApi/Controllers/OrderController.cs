using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactAngularPracticeApi.Data.Entities;
using ReactAngularPracticeApi.Service.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAngularPracticeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetOrderList")]
        public async Task<IActionResult> GetOrderList()
        {
            try
            {
                var res = await _service.GetOrderList();
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetOrderById/{orderId}")]
        public async Task<IActionResult> RetrieveSingleOrder(int orderId)
        {
            try
            {
                var res = await _service.RetrieveOrderInfo(orderId);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("PostOrder")]
        public async Task<IActionResult> OrderNewProduct(Order order)
        {
            try
            {
                var res = await _service.OrderNewProduct(order);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("DeleteById/{orderId}")]
        public async Task<IActionResult> DeleteOneOrder(int orderId)
        {

            try
            {
                var response = await _service.DeleteOrder(orderId);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPut]
        [Route("UpdateOrderStatus/{orderId}")]
        public async Task<IActionResult> UpdateOneOrder(int orderId, Order order)
        {
            try
            {
                var res = await _service.UpdateProductDetail(orderId, order);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
