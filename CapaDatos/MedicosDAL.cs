using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class MedicosDAL
    {
        private readonly HospitalDBContext _context;

        public MedicosDAL(HospitalDBContext context)
        {
            _context = context;
        }

        // Listar tratamientos con el nombre del paciente (JOIN con Pacientes)
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

        // Guardar o actualizar un tratamiento
        public int GuardarMedico(MedicosCLS oMedicoCLS)
        {
            try
            {
                if (oMedicoCLS.Id == 0)
                {
                    _context.Medicos.Add(oMedicoCLS);
                }
                else
                {
                    var MedicoDB = _context.Medicos.FirstOrDefault(m => m.Id == oMedicoCLS.Id);
                    if (MedicoDB != null)
                    {
                        MedicoDB.Nombre = oMedicoCLS.Nombre;
                        MedicoDB.Apellido = oMedicoCLS.Apellido;
                        MedicoDB.Telefono = oMedicoCLS.Telefono;
                        MedicoDB.Email = oMedicoCLS.Email;
                        MedicoDB.EspecialidadId = oMedicoCLS.EspecialidadId;
                    }
                }
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en GuardarEspecialidad: " + ex.Message);
                throw;
            }
        }

        public MedicosCLS RecuperarMedico(int id)
        {
            try
            {
                var Medico = (from m in _context.Medicos
                                   join e in _context.Especialidades on m.EspecialidadId equals e.id
                                   where m.Id == id
                                   select new MedicosCLS
                                   {
                                       Id = m.Id,
                                       Nombre = m.Nombre,
                                       Apellido = m.Apellido,
                                       Telefono = m.Telefono,
                                       Email = m.Email,
                                       EspecialidadId = m.EspecialidadId,
                                       NombreEspecialidad = e.nombre
                                   }).FirstOrDefault();
                return Medico;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int EliminarMedico(int id)
        {
            try
            {
                var medico = _context.Medicos.FirstOrDefault(m => m.Id == id);
                if (medico != null)
                {
                    _context.Medicos.Remove(medico);
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
