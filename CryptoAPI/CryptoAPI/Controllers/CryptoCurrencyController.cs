using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CryptoAPI.Model;
using CryptoAPI.Model.ResponseModel;
using CryptoAPI.Model.RequestModel;

namespace CryptoAPI.Controllers
{
    [Route("api/coins")]
    [ApiController]
    public class CryptoCurrencyController : ControllerBase
    {
        private readonly CryptoDatabaseContext _context;

        public CryptoCurrencyController(CryptoDatabaseContext context)
        {
            _context = context;
        }

        // GET: all coins
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var response = new ResponseModel();

            var items = await (from category in _context.Currencycategories
                               join symbol in _context.Currencysymbols on category.Id equals symbol.CategoryId
                               select new CryptoCurrency()
                               {
                                   symbolId = symbol.Id,
                                   Symbol = symbol.Symbol,
                                   Price = symbol.Price,
                                   Category = category.Category,
                                   CategoryId= category.Id,
                               }).ToListAsync();

            response.StatusCode = 200;
            response.StatusDescription = "Succesfull.";
            response.Items = items;
            return Ok(response);
        }

        // GET: all coin by id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ResponseModel();

            var items = await (from category in _context.Currencycategories
                               join symbol in _context.Currencysymbols on category.Id equals symbol.CategoryId
                               where symbol.Id == id
                               select new CryptoCurrency()
                               {
                                   symbolId = symbol.Id,
                                   Symbol = symbol.Symbol,
                                   Price = symbol.Price,
                                   Category = category.Category
                               }).ToListAsync();

            response.StatusCode = 200;
            response.StatusDescription = "Succesfull.";
            response.Items = items;
            return Ok(response);
        }

        // GET: all list id 
        [HttpGet("categories/list")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = new ResponseModel();

            var items = await (from category in _context.Currencycategories
                               select new
                               {
                                   category.Id,
                                   Category = category.Category,
                               }).ToListAsync();

            response.StatusCode = 200;
            response.StatusDescription = "Succesfull.";
            response.Items = items;
            return Ok(response);
        }

        // GET: by id 
        [HttpGet("categories/{id}")]
        public async Task<IActionResult> GetAllCategories(int id)
        {
            var response = new ResponseModel();

            var items = await (from category in _context.Currencycategories
                               where category.Id == id
                               select new
                               {
                                   category.Id,
                                   Category = category.Category,
                                   Coins = _context.Currencysymbols.Where(p => p.CategoryId == id).Select(p => new { p.Id, p.Symbol, p.Price }).
ToList()
                               }).ToListAsync();

            response.StatusCode = 200;
            response.StatusDescription = "Succesfull.";
            response.Items = items;
            return Ok(response);
        }

        // GET: coin by symbol
        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetBySymbol(string symbol)
        {
            var response = new ResponseModel();

            var item = await (from category in _context.Currencycategories
                              join currSymbol in _context.Currencysymbols on category.Id equals currSymbol.CategoryId
                              where currSymbol.Symbol.Trim() == symbol.Trim()
                              select new CryptoCurrency()
                              {
                                  symbolId = currSymbol.Id,
                                  Symbol = currSymbol.Symbol,
                                  Price = currSymbol.Price,
                                  Category = category.Category
                              }).FirstOrDefaultAsync();

            if (item == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Coin does not exist.";
                return NotFound(response);
            }
            response.StatusCode = 200;
            response.StatusDescription = "Succesfull";
            response.Items = item;
            return Ok(response);
        }

        // POST: add new coin 
        [HttpPost("add")]
        public async Task<IActionResult> Add(CurrencysymbolModel currencysymbol)
        {
            var response = new ResponseModel();

            var cat = await _context.Currencycategories.FirstOrDefaultAsync(p=>p.Id == currencysymbol.CategoryId);
            if (cat == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Coin Category does not exist .";
                return Ok(response);
            }

            var item = await _context.Currencysymbols.Where(p => p.Symbol.Trim() == currencysymbol.Symbol.Trim() && p.Price == currencysymbol.Price).Select(p => p).FirstOrDefaultAsync();
            if (item != null)
            {
                response.StatusCode = 200;
                response.StatusDescription = "Coin already exists.";
                return Ok(response);
            }

            var currencySymbol = new Currencysymbol()
            {
                CategoryId = currencysymbol.CategoryId,
                Price = currencysymbol.Price,
                Symbol = currencysymbol.Symbol,
            };

            _context.Currencysymbols.Add(currencySymbol);
            await _context.SaveChangesAsync();

            response.StatusCode = 200;
            response.StatusDescription = "Coin added, sucessful.";
            return Ok(response);
        }

        // POST: add new coin category
        [HttpPost("category/add")]
        public async Task<IActionResult> AddCategory(CategoryModel categoryModel)
        {
            var response = new ResponseModel();

            var category = await _context.Currencycategories.FirstOrDefaultAsync(p => p.Category.ToLower().Trim() == categoryModel.CategoryName.ToLower().Trim());
            if (category != null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Coin Category already exist.";
                return Ok(response);
            }

            var currencyCategory= new Currencycategory()
            {
                Category = categoryModel.CategoryName,
            };

            _context.Currencycategories.Add(currencyCategory);
            await _context.SaveChangesAsync();

            response.StatusCode = 200;
            response.StatusDescription = "Coin Category added succesfully.";
            return Ok(response);
        }

        // Delete: delete coin by Id
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ResponseModel();

            var currency = await _context.Currencysymbols.FirstOrDefaultAsync(p => p.Id == id);
            if (currency == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Coin Id does not exist.";
                return Ok(response);
            }

            _context.Currencysymbols.Remove(currency);
            await _context.SaveChangesAsync();

            response.StatusCode = 200;
            response.StatusDescription = "Coin Deleted succesfully.";
            return Ok(response);
        }

        // Delete: delete coin category by categoryId
        [HttpDelete("category/delete")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = new ResponseModel();

            var category = await _context.Currencycategories.FirstOrDefaultAsync(p => p.Id == id);
            if (category == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Coin Category does not exist.";
                return Ok(response);
            }
            var coins = _context.Currencysymbols.Where(p => p.CategoryId == category.Id).ToList();
            _context.RemoveRange(coins);
            _context.Currencycategories.Remove(category);
            await _context.SaveChangesAsync();

            response.StatusCode = 200;
            response.StatusDescription = "Coin Category Deleted succesfully.";
            return Ok(response);
        }
    }
}

