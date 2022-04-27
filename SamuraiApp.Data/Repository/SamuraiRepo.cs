using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Interface;
using SamuraiAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Repository
{
    public class SamuraiRepo : ISamurai
    {
        private readonly SamuraiContext _context;

        public SamuraiRepo(SamuraiContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteSamurai = await GetById(id);
                _context.Samurais.Remove(deleteSamurai);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbex)
            {
                throw new Exception(dbex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var result = await _context.Samurais.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Samurai>> GetAllSamuraiWithPedang()
        {
            var result = await _context.Samurais.Include(p=>p.Pedangs).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Samurai>> GetAllSamuraiWithPedangAndElemen()
        {
            var result = await _context.Samurais.Include(p => p.Pedangs)
                .ThenInclude(e=>e.Elemens).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Samurai> GetById(int id)
        {
            var result = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai dengan nama: {id} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> GetByIdSamuraiWithPedang(int id)
        {
            var result = await _context.Samurais.Include(p=>p.Pedangs).FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai dengan nama: {id} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> GetByIdSamuraiWithPedangAndElemen(int id)
        {
            var result = await _context.Samurais.Include(p => p.Pedangs)
                .ThenInclude(e=>e.Elemens).FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai dengan nama: {id} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> GetByName(string name)
        {
            var result = await _context.Samurais.FirstOrDefaultAsync(s => s.Name == name);
            if (result == null) throw new Exception($"Data samurai dengan nama: {name} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> Insert(Samurai entity)
        {
            try
            {
                _context.Samurais.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Samurai> Update(int id, Samurai entity)
        {
            try
            {
                var updateSamurai = await GetById(id);
                updateSamurai.Name = entity.Name;
                await _context.SaveChangesAsync();
                return updateSamurai;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception (dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
