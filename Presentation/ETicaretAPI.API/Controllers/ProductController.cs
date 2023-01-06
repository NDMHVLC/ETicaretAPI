using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;

        public ProductController(
            IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository,
            IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, 
            IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //var customerId = Guid.NewGuid();
            // await _customerWriteRepository.AddAsync(new() { Id= customerId, Name="Nedim" });

            // await _orderWriteRepository.AddAsync(new() { Description = "Çorap", Address = "Maltepe", CustomerId = customerId });
            // await _orderWriteRepository.AddAsync(new() { Description = "Ayakkabı", Address = "Maltepe", CustomerId = customerId });
            // await _orderWriteRepository.SaveAsync();

            Order order = await _orderReadRepository.GetByIdAsync("e20e8012-29fc-4363-91f1-6d74adba9db7");
            order.Address = "Kadıköy";
            await _orderWriteRepository.SaveAsync();
        }
    }
}
