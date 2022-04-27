using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.API.DTO.Pedangs;
using SamuraiApp.Data.Interface;
using SamuraiAppDomain;

namespace SamuraiApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedangsController : ControllerBase
    {
        private readonly IPedang _pedangs;
        private readonly IMapper _mapper;

        public PedangsController(IPedang pedangs, IMapper mapper)
        {
            _pedangs = pedangs;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PedangDTO>> Get()
        {
            var results = await _pedangs.GetAll();
            var output = _mapper.Map<IEnumerable<PedangDTO>>(results);

            return output;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedangDTO>> GetById(int id)
        {
            var results = await _pedangs.GetById(id);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<PedangDTO>(results));
        }

        [HttpGet("{nama}")]
        public async Task<ActionResult<PedangDTO>> GetByName(string nama)
        {
            var results = await _pedangs.GetByName(nama);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<PedangDTO>(results));
        }

        [HttpPost]
        public async Task<ActionResult> Post(PedangCreateDTO pedangCreateDTO)
        {
            try
            {
                var newPedang = _mapper.Map<Pedang>(pedangCreateDTO);
                var result = await _pedangs.Insert(newPedang);
                var pedangDto = _mapper.Map<PedangDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, pedangDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PedangCreateDTO pedangCreateDTO)
        //menambahkan docker extention
        {
            try
            {
                var updatePedang = _mapper.Map<Pedang>(pedangCreateDTO);
                var result = await _pedangs.Update(id, updatePedang);
                var pedangDTO = _mapper.Map<PedangDTO>(result);
                return Ok(pedangDTO);
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
                await _pedangs.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Elemen")]
        public async Task<ActionResult> PostPedangWithElemen(CreatePedangWithElemenDTO pedangCreateDTO)
        {
            try
            {
                var newPedang = _mapper.Map<Pedang>(pedangCreateDTO);
                var result = await _pedangs.Insert(newPedang);
                var pedangDto = _mapper.Map<ViewPedangWithElemenDTO>(result);
                return CreatedAtAction("GetByIdPedangWithElemen", new { id = result.Id }, pedangDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Elemen")]
        public async Task<IEnumerable<ViewPedangWithElemenDTO>> GetAllPedangWithElemen()
        {
            var results = await _pedangs.GetAllPedangWithElemen();
            var output = _mapper.Map<IEnumerable<ViewPedangWithElemenDTO>>(results);

            return output;
        }

        [HttpGet("Elemen/{id}")]
        public async Task<ActionResult<ViewPedangWithElemenDTO>> GetByIdPedangWithElemen(int id)
        {
            var results = await _pedangs.GetByIdPedangWithElemen(id);
            if (results == null)
                return NotFound();

            return Ok(_mapper.Map<ViewPedangWithElemenDTO>(results));
        }
    }
}

