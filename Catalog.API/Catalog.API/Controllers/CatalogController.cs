using AutoMapper;
using Catalog.API.Dtos;
using Catalog.API.Entities;
using Catalog.API.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {
   

            private readonly IProductRepository _productRepository;
            private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CatalogController(IProductRepository productRepository, IUnitOfWork uow, IMapper mapper)
            {
                _productRepository = productRepository;
                _uow = uow;
            _mapper = mapper;

        }

        [HttpGet]
            public async Task<ActionResult<IEnumerable<Product>>> Get()
            {
                var products = await _productRepository.GetAll();

                return Ok(products);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Product>> Get(Guid id)
            {
                var product = await _productRepository.GetById(id);

                return Ok(product);
            }

            [HttpPost, Route("PostSimulatingError")]
            public IActionResult PostSimulatingError([FromBody] Product product)
            {
                _productRepository.Add(product);

                // The product will not be added
                return BadRequest();
            }

            [HttpPost]
            public async Task<ActionResult<Product>> Post([FromBody] AddProductDto product)
            {
            
                _productRepository.Add(_mapper.Map<Product>(product));
            // If everything is ok then:
            await _uow.Commit();
                return Ok(product);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Product>> Put(Guid id, [FromBody] AddProductDto product)
            {

                _productRepository.Update(_mapper.Map<Product>(product));

                await _uow.Commit();

                return Ok(await _productRepository.GetById(id));
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(Guid id)
            {
                _productRepository.Remove(id);

                // it won't be null
                var testProduct = await _productRepository.GetById(id);

                // If everything is ok then:
                await _uow.Commit();

                // not it must by null
                testProduct = await _productRepository.GetById(id);

                return Ok();
            }
        }
   
}

