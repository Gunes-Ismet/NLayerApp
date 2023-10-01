using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTO_s;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategoryWithDtoController : CustomBaseController
    {
        private readonly IServiceWithDto<Category, CategoryDto> _service;

        public CategoryWithDtoController(IServiceWithDto<Category, CategoryDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            return CreateActionResult(await _service.AddAsync(categoryDto));
        }

    }
}
