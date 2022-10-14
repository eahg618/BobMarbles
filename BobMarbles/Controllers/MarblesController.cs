using BobMarbles.Repository;
using BobMarbles.Models;
using Microsoft.AspNetCore.Mvc;

namespace BobMarbles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarblesController : Controller
    {
        private readonly IRepository _repository;
        public MarblesController(IRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<DataController>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marble>>> MarbleList()
        {
            List<Marble> filterList = new List<Marble>();

            try
            {
                filterList = _repository.SelectAll<Marble>().Result;
                int a = filterList.RemoveAll(x => x.Weight <= 0.5 && this.Palindromo(x.Name.ToLower()) == false);
            }
            catch (Exception)
            {

                throw;
            }

            return filterList;

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Marble>> GetMarble(int id)
        {
            var model = await _repository.SelectById<Marble>(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarble(long id, Marble model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<Marble>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Marble>> InsertMarble([FromBody] Marble model)
        {
            await _repository.CreateAsync<Marble>(model);

            return CreatedAtAction("GetMarble", new { id = model.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Marble>> DeleteMarble(int id)
        {
            var model = await _repository.SelectById<Marble>(id);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Marble>(model);

            return model;
        }


        private bool Palindromo(string word)
        {
            bool response = true;
            word = word.Replace(" ", String.Empty);

            do
            {
                if (word[0] == word[word.Length - 1])
                {
                    word = word.Remove(0, 1);
                    word = word.Remove(word.Length - 1, 1);
                    response = true;
                }
                else
                {
                    response = false;

                }
            } while ((word.Length > 1) && (response == true));



            return response;
        }


    }
}
