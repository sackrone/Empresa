using Empresa.Models;
using Empresa.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Empresa.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            List<EmpleadosViewModel> list;
            using (EmpresaEntities db = new EmpresaEntities())
            {
                list = (from d in db.Empleados
                        select new EmpleadosViewModel
                        {
                            Id = d.id,
                            Nombre = d.nombre,
                            Correo = d.correo
                        }).ToList();
            }

            return View(list);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(EmpleadosViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using(EmpresaEntities db = new EmpresaEntities())
                    {
                        var oTabla = new Empleados();
                        oTabla.correo = model.Correo;
                        oTabla.fecha_nacimiento = model.FechaNacimiento;
                        oTabla.nombre = model.Nombre;

                        db.Empleados.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}