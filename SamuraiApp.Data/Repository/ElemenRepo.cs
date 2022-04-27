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
    public class ElemenRepo : IElemen
    {
        private readonly SamuraiContext _context;

        public ElemenRepo(SamuraiContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteElemen = await GetById(id);
                _context.Elemens.Remove(deleteElemen);
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

        public async Task<IEnumerable<Elemen>> GetAll()
        {
            var result = await _context.Elemens.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Elemen> GetById(int id)
        {
            var result = await _context.Elemens.FirstOrDefaultAsync(s => s.ElemenId == id);
            if (result == null) throw new Exception($"Data samurai dengan nama: {id} tidak ditemukan");
            return result;
        }

        public async Task<Elemen> GetByName(string name)
        {
            var result = await _context.Elemens.FirstOrDefaultAsync(s => s.Name == name);
            if (result == null) throw new Exception($"Data samurai dengan nama: {name} tidak ditemukan");
            return result;
        }

        public async Task<Elemen> Insert(Elemen entity)
        {
            try
            {
                _context.Elemens.Add(entity);
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

        public async Task<Elemen> Update(int id, Elemen entity)
        {
            try
            {
                var updateElemen = await GetById(id);
                updateElemen.Name = entity.Name;
                await _context.SaveChangesAsync();
                return updateElemen;
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
