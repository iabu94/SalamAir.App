using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalamAir.Domain.Contracts;
using SalamAir.Domain.Entities;
using SalamAir.TestApi.DTOs;

namespace SalamAir.TestApi.Controllers
{
    [Route("cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartController(IUnitOfWork unitOfWork, IMapper mapper, ICartRepository cartRepository, IItemRepository itemRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
        }

        [HttpPost("add")]
        public IActionResult Post([FromBody] CartDto cartDto)
        {
            var item = _itemRepository.Get(cartDto.ItemId);
            if (item == null)
            {
                return BadRequest("The item you have selected doesn't exists");
            }
            if (cartDto.OptionIds.Count > 2)
            {
                return BadRequest("You cannot select more than 2 options for this item.");
            }
            var cart = _mapper.Map<Cart>(cartDto);
            _cartRepository.Add(cart);
            _unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
