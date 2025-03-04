using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

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
            try
            {
                if (oFacturaCLS.Id == 0)
                {
                    _context.Facturacion.Add(oFacturaCLS);
                }
                else
                {
                    var facturaDB = _context.Facturacion.FirstOrDefault(f => f.Id == oFacturaCLS.Id);
                    if (facturaDB != null)
                    {
                        facturaDB.PacienteId = oFacturaCLS.PacienteId;
                        facturaDB.Monto = oFacturaCLS.Monto;
                        facturaDB.FechaPago = oFacturaCLS.FechaPago;
                        facturaDB.MetodoPago = oFacturaCLS.MetodoPago;
                    }
                }
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en GuardarCita: " + ex.Message);
                throw;
            }
        }


        public FacturacionCLS RecuperarFactura(int id)
        {
            try
            {
                var factura = (from f in _context.Facturacion
                            join p in _context.Pacientes on f.PacienteId equals p.id
                            where f.Id == id
                            select new FacturacionCLS
                            {
                                Id = f.Id,
                                Monto = f.Monto,
                                FechaPago = f.FechaPago,
                                MetodoPago = f.MetodoPago,
                                PacienteId = f.PacienteId,
                                NombrePaciente = p.nombre,
                            }).FirstOrDefault();
                return factura;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int EliminarFactura(int id)
        {
            try
            {
                var factura = _context.Facturacion.FirstOrDefault(f => f.Id == id);
                if (factura != null)
                {
                    _context.Facturacion.Remove(factura);
                    return _context.SaveChanges();
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
