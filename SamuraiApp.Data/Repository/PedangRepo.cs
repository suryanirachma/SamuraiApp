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
    public class PedangRepo : IPedang
    {
        private readonly SamuraiContext _context;

        public PedangRepo(SamuraiContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deletePedang = await GetById(id);
                _context.Pedangs.Remove(deletePedang);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbex)
            {
                throw new Exception(dbex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Pedang>> GetAll()
        {
            var result = await _context.Pedangs.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Pedang>> GetAllPedangWithElemen()
        {
            var result = await _context.Pedangs.Include(e=>e.Elemens).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Pedang> GetById(int id)
        {
            var result = await _context.Pedangs.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai dengan nama: {id} tidak ditemukan");
            return result;
        }

        public async Task<Pedang> GetByIdPedangWithElemen(int id)
        {
            var result = await _context.Pedangs.Include(e=>e.Elemens).FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai dengan nama: {id} tidak ditemukan");
            return result;
        }

        public async Task<Pedang> GetByName(string nama)
        {
            var result = await _context.Pedangs.FirstOrDefaultAsync(s => s.Nama == nama);
            if (result == null) throw new Exception($"Data samurai dengan nama: {nama} tidak ditemukan");
            return result;
        }

        public async Task<Pedang> Insert(Pedang entity)
        {
            try
            {
                _context.Pedangs.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedang> Update(int id, Pedang entity)
        {
            try
            {
                var updatePedang = await GetById(id);
                updatePedang.Nama = entity.Nama;
                updatePedang.Tahun = entity.Tahun;
                updatePedang.Berat = entity.Berat;
                updatePedang.SamuraiId = entity.SamuraiId;
                await _context.SaveChangesAsync();
                return updatePedang;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
