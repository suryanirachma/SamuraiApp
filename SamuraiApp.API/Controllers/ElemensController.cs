using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.API.DTO.Elemens;
using SamuraiApp.Data.Interface;
using SamuraiAppDomain;

namespace SamuraiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElemensController : ControllerBase
    {
        private readonly IElemen _elemens;
        private readonly IMapper _mapper;

        public ElemensController(IElemen elemens, IMapper mapper)
        {
            _elemens = elemens;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ElemenDTO>> Get()
        {
            var results = await _elemens.GetAll();
            var output = _mapper.Map<IEnumerable<ElemenDTO>>(results);

            return output;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElemenDTO>> GetById(int id)
        {
            var results = await _elemens.GetById(id);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<ElemenDTO>(results));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ElemenDTO>> GetByName(string name)
        {
            var results = await _elemens.GetByName(name);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<ElemenDTO>(results));
        }

        [HttpPost]
        public async Task<ActionResult> Post(ElemenCreateDTO elemenCreateDTO)
        {
            try
            {
                var newElemen = _mapper.Map<Elemen>(elemenCreateDTO);
                var result = await _elemens.Insert(newElemen);
                var elemenDto = _mapper.Map<ElemenDTO>(result);
                return CreatedAtAction("GetById", new { id = result.ElemenId }, elemenDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ElemenCreateDTO elemenCreateDTO)
        //menambahkan docker extention
        {
            try
            {
                var updateElemen = _mapper.Map<Elemen>(elemenCreateDTO);
                var result = await _elemens.Update(id, updateElemen);
                var elemenDTO = _mapper.Map<ElemenDTO>(result);
                return Ok(elemenDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _elemens.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
