using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaCreditos.AccesoDatos.Data;
using PruebaCreditos.Modelos;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;

namespace PruebaCreditos.Controllers
{
    public class CreditoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly string _connectionString;
        public CreditoesController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        // GET: Creditoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Credito.Include(c => c.Clientes);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Creditoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credito = await _context.Credito
                .Include(c => c.Clientes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (credito == null)
            {
                return NotFound();
            }

            return View(credito);
        }

        // GET: Creditoes/Create
        public IActionResult Create()
        {
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: Creditoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoCredito,Monto,Plazo,Tasa,TipoAmortizacion,ClientesId")] Credito credito)
        {
            if (ModelState.IsValid)
            {
                //var connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
                using (SqlConnection sql = new SqlConnection(_connectionString)) {
                    using (SqlCommand cmd = new SqlCommand("sp_create_credit", sql)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@i_toperacion", credito.TipoCredito));
                        cmd.Parameters.Add(new SqlParameter("@i_monto", credito.Monto));
                        cmd.Parameters.Add(new SqlParameter("@i_plazo", credito.Plazo));
                        cmd.Parameters.Add(new SqlParameter("@i_tasa", credito.Tasa));
                        cmd.Parameters.Add(new SqlParameter("@i_tipo_amort", credito.TipoAmortizacion));
                        var claimIdentidad = (ClaimsIdentity)User.Identity;
                        var claim = claimIdentidad.FindFirst(ClaimTypes.NameIdentifier);
                        credito.ClientesId = claim.Value;
                        cmd.Parameters.Add(new SqlParameter("@i_cliente_id", credito.ClientesId));
                        cmd.Connection = sql;
                        sql.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                //_context.Add(credito);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Id", credito.ClientesId);
            return View(credito);
        }

        // GET: Creditoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credito = await _context.Credito.FindAsync(id);
            if (credito == null)
            {
                return NotFound();
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Id", credito.ClientesId);
            return View(credito);
        }

        // POST: Creditoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoCredito,Monto,Plazo,Tasa,TipoAmortizacion,ClientesId")] Credito credito)
        {
            if (id != credito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditoExists(credito.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesId"] = new SelectList(_context.Clientes, "Id", "Id", credito.ClientesId);
            return View(credito);
        }

        // GET: Creditoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credito = await _context.Credito
                .Include(c => c.Clientes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (credito == null)
            {
                return NotFound();
            }

            return View(credito);
        }

        // POST: Creditoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credito = await _context.Credito.FindAsync(id);
            _context.Credito.Remove(credito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditoExists(int id)
        {
            return _context.Credito.Any(e => e.Id == id);
        }
    }
}
