using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal1.Data;
using ProyectoFinal1.Models;
using System.Text.Json;

namespace ProyectoFinal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tbl_clientesEntityController : ControllerBase
    {
        public tbl_bitacora bitacora = new tbl_bitacora();

        private readonly ProyectoFinal1Context _context;

        public tbl_clientesEntityController(ProyectoFinal1Context context)
        {
            _context = context;
        }

        // PUT: api/tbl_clientesEntity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_clientes(int id, tbl_clientes tbl_clientes)
        {
            if (id != tbl_clientes.id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_clientes).State = EntityState.Modified;

            try
            {
                bitacora.id_proc = 1;
                bitacora.id_request = 2;
                bitacora.fecha_trn = DateTime.Now;
                string jsonString = JsonSerializer.Serialize<tbl_clientes>(tbl_clientes);
                bitacora.JSON = "Detalles: " + jsonString;
                _context.tbl_bitacora.Add(bitacora);
                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_clientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/tbl_clientesEntity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_clientes(int id)
        {
            var tbl_clientes = await _context.tbl_clientes.FindAsync(id);
            if (tbl_clientes == null)
            {
                return NotFound();
            }
            bitacora.id_proc = 1;
            bitacora.id_request = 4;
            bitacora.fecha_trn = DateTime.Now;
            string jsonString = JsonSerializer.Serialize<tbl_clientes>(tbl_clientes);
            bitacora.JSON = "Detalles: " + jsonString;
            _context.tbl_bitacora.Add(bitacora);
            await _context.SaveChangesAsync();
            _context.tbl_clientes.Remove(tbl_clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_clientesExists(int id)
        {
            return _context.tbl_clientes.Any(e => e.id == id);
        }

    }
}
