using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{
    public class FacturacionDAL
    {
        private readonly HospitalDBContext _context;

        public FacturacionDAL(HospitalDBContext context)
        {
            _context = context;
        }

        public List<FacturacionCLS> ListarFacturas()
        {
            try
            {
                var lista = (from f in _context.Facturacion
                             join p in _context.Pacientes on f.PacienteId equals p.id
                             select new FacturacionCLS
                             {
                                 Id = f.Id,
                                 Monto = f.Monto,
                                 FechaPago = f.FechaPago,
                                 MetodoPago = f.MetodoPago,
                                 PacienteId = f.PacienteId,
                                 NombrePaciente = p.nombre
                             }).ToList();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GuardarFactura(FacturacionCLS oFacturaCLS)
        {
            if (oFacturaCLS.Id == 0)
            {
                return _context.Database.ExecuteSqlRaw("EXEC uspInsertarFactura @p0, @p1, @p2, @p3",
                    oFacturaCLS.Monto, oFacturaCLS.FechaPago, oFacturaCLS.MetodoPago, oFacturaCLS.PacienteId);
            }
            else
            {
                return _context.Database.ExecuteSqlRaw("EXEC uspActualizarFactura @p0, @p1, @p2, @p3, @p4",
                    oFacturaCLS.Id, oFacturaCLS.Monto, oFacturaCLS.FechaPago, oFacturaCLS.MetodoPago, oFacturaCLS.PacienteId);
            }
        }

        public FacturacionCLS RecuperarFactura(int id)
        {
            return _context.Facturacion
                .FromSqlRaw("EXEC uspListarFacturas")
                .AsEnumerable()
                .FirstOrDefault(f => f.Id == id);
        }

        public int EliminarFactura(int id)
        {
            return _context.Database.ExecuteSqlRaw("EXEC uspEliminarFactura @p0", id);
        }
    }
}
