using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalamAir.Domain.Contracts;
using SalamAir.Domain.Entities;
using SalamAir.TestApi.DTOs;

namespace SalamAir.TestApi.Controllers
{
    [Route("menu/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemController(IItemRepository itemRepository, IUnitOfWork unitOfWork, IMapper mapper, ISubCategoryRepository subCategoryRepository)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ItemDto itemDto)
        {
            if (itemDto.SubCategoryId <= 0)
            {
                return BadRequest("Sub category id is required.");
            }
            var subCategory = _subCategoryRepository.Get(itemDto.SubCategoryId);
            if (subCategory == null)
            {
                return BadRequest("The given sub category id not found.");
            }
            var item = _mapper.Map<Item>(itemDto);
            item.SubCategory = subCategory;
            _itemRepository.Add(item);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpGet("{item}")]
        public IActionResult Get(int item)
        {
            return Ok(_itemRepository.Get(item));

        }
    }
}
