using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{
    public class MedicosDAL
    {
        private readonly HospitalDBContext _context;

        public MedicosDAL(HospitalDBContext context)
        {
            _context = context;
        }
        public List<MedicosCLS> ListarMedicos()
        {
            try
            {
                var lista = (from m in _context.Medicos
                             join e in _context.Especialidades on m.EspecialidadId equals e.id
                             select new MedicosCLS
                             {
                                 Id = m.Id,
                                 Nombre = m.Nombre,
                                 Apellido = m.Apellido,
                                 Telefono = m.Telefono,
                                 Email = m.Email,
                                 EspecialidadId = m.EspecialidadId,
                                 NombreEspecialidad = e.nombre
                             }).ToList();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GuardarMedico(MedicosCLS oMedicoCLS)
        {
            if (oMedicoCLS.Id == 0)
            {
                return _context.Database.ExecuteSqlRaw("EXEC uspInsertarMedico @p0, @p1, @p2, @p3, @p4",
                    oMedicoCLS.Nombre, oMedicoCLS.Apellido, oMedicoCLS.Telefono, oMedicoCLS.Email, oMedicoCLS.EspecialidadId);
            }
            else
            {
                return _context.Database.ExecuteSqlRaw("EXEC uspActualizarMedico @p0, @p1, @p2, @p3, @p4, @p5",
                    oMedicoCLS.Id, oMedicoCLS.Nombre, oMedicoCLS.Apellido, oMedicoCLS.Telefono, oMedicoCLS.Email, oMedicoCLS.EspecialidadId);
            }
        }

        public MedicosCLS RecuperarMedico(int id)
        {
            return _context.Medicos
                .FromSqlRaw("EXEC uspListarMedicos")
                .AsEnumerable()
                .FirstOrDefault(m => m.Id == id);
        }

        public int EliminarMedico(int id)
        {
            return _context.Database.ExecuteSqlRaw("EXEC uspEliminarMedico @p0", id);
        }
    }
}
