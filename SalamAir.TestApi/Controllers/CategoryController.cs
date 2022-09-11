using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalamAir.Domain.Contracts;
using SalamAir.Domain.Entities;
using SalamAir.TestApi.DTOs;

namespace SalamAir.TestApi.Controllers
{
    [Route("menu/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper, 
            ISubCategoryRepository subCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _mapper.Map<IList<CategoryDto>>(_categoryRepository.GetAll());
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _categoryRepository.Add(category);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpPost("{parentCategory}")]
        public IActionResult Post(int parentCategory, [FromBody] CategoryDto categoryDto)
        {
            if (parentCategory == 0)
            {
                return BadRequest("Sub category should contain a parent category");
            }
            var category = _categoryRepository.Get(parentCategory);
            if (category == null)
            {
                return BadRequest("No categories found for the given category id.");
            }
            var subCategory = _mapper.Map<SubCategory>(categoryDto);
            subCategory.Category = category;
            _subCategoryRepository.Add(subCategory);
            _unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
