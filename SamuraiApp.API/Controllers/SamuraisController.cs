using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.API.DTO;
using SamuraiApp.API.DTO.Samurais;
using SamuraiApp.Data.Interface;
using SamuraiAppDomain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamuraiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samurais;
        private readonly IMapper _mapper;

        public SamuraisController(ISamurai samurais, IMapper mapper)
        {
            _samurais = samurais;
            _mapper = mapper;
        }


        // GET: api/<SamuraisController>
        [HttpGet]
        public async Task<IEnumerable<SamuraiDTO>> Get()
        {
            var results = await _samurais.GetAll();
            var output = _mapper.Map<IEnumerable<SamuraiDTO>>(results);

            return output;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SamuraiDTO>>GetById(int id)
        {
            var results = await _samurais.GetById(id);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<SamuraiDTO>(results));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<SamuraiDTO>> GetByName(string name)
        {
            var results = await _samurais.GetByName(name);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<SamuraiDTO>(results));
        }

        // POST api/<SamuraisController>
        [HttpPost]
        public async Task<ActionResult> Post(SamuraiCreateDTO samuraiCreateDTO)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurais.Insert(newSamurai);
                var samuraiDto = _mapper.Map<SamuraiDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, samuraiDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SamuraisController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, SamuraiCreateDTO samuraiCreateDTO)
        //menambahkan docker extention
        {
            try
            {
                var updateSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurais.Update(id, updateSamurai);
                var samuraiDTO = _mapper.Map<SamuraiDTO>(result);
                return Ok(samuraiDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SamuraisController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _samurais.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Pedang")]
        public async Task<ActionResult> PostSamuraiWithPedang(CreateSamuraiWithPedangDTO samuraiCreateDTO)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurais.Insert(newSamurai);
                var samuraiDto = _mapper.Map<ViewSamuraiWithPedangDTO>(result);
                return CreatedAtAction("GetByIdSamuraiWithPedang", new { id = result.Id }, samuraiDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Pedang")]
        public async Task<IEnumerable<ViewSamuraiWithPedangDTO>> GetSamuraiWithPedang()
        {
            var results = await _samurais.GetAllSamuraiWithPedang();
            var output = _mapper.Map<IEnumerable<ViewSamuraiWithPedangDTO>>(results);

            return output;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("Pedang/{id}")]
        public async Task<ActionResult<ViewSamuraiWithPedangDTO>> GetByIdSamuraiWithPedang(int id)
        {
            var results = await _samurais.GetByIdSamuraiWithPedang(id);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<ViewSamuraiWithPedangDTO>(results));
        }

        [HttpGet("Pedang/Elemen")]
        public async Task<IEnumerable<ViewSamuraiWithPedangAndElemenDTO>> GetSamuraiWithPedangAndElemen()
        {
            var results = await _samurais.GetAllSamuraiWithPedangAndElemen();
            var output = _mapper.Map<IEnumerable<ViewSamuraiWithPedangAndElemenDTO>>(results);

            return output;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("Pedang/Elemen/{id}")]
        public async Task<ActionResult<ViewSamuraiWithPedangAndElemenDTO>> GetByIdSamuraiWithPedangAndElemen(int id)
        {
            var results = await _samurais.GetByIdSamuraiWithPedangAndElemen(id);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<ViewSamuraiWithPedangAndElemenDTO>(results));
        }

        [HttpPost("Pedang/Elemen")]
        public async Task<ActionResult> PostSamuraiWithPedangAndElemen(CreateSamuraiWithPedangAndElemenDTO samuraiCreateDTO)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurais.Insert(newSamurai);
                var samuraiDto = _mapper.Map<ViewSamuraiWithPedangAndElemenDTO>(result);
                return CreatedAtAction("GetByIdSamuraiWithPedangAndElemen", new { id = result.Id }, samuraiDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
