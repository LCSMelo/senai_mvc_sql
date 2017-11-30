using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using cadastro_senai.Repositorio;
using cadastro_senai.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace cadastro_senai.Controllers
{
    public class ClienteController : Controller
    {
       ClienteRep objClienteRep = new ClienteRep();   
   
    // GET: /<controller>/   
        public IActionResult Index()   
        {   
            List<Cliente> lstCliente = new List<Cliente>();  
            try
            {
                lstCliente = objClienteRep.Listar().ToList();       
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return View(lstCliente);
            
        }   

        [HttpGet]     
        public IActionResult Cadastrar()     
        {     
            return View();     
        }     
        
        [HttpPost]     
        [ValidateAntiForgeryToken]     
        public IActionResult Cadastrar([Bind] Cliente cliente)     
        {     
            if (ModelState.IsValid)     
            {     
                //objClienteRep.Cadastrar(cliente);     
                return RedirectToAction("Index");     
            }     
            return View(cliente);     
        } 

        [HttpGet]   
        public IActionResult Edit(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   
            Cliente cliente = objClienteRep.BuscarClientePorId(id);   
        
            if (cliente == null)   
            {   
                return NotFound();   
            }   
            return View(cliente);   
        }   
        
        [HttpPost]   
        [ValidateAntiForgeryToken]   
        public IActionResult Editar(int id, [Bind]Cliente cliente)   
        {   
            if (id != cliente.Id)   
            {   
                return NotFound();   
            }   
            if (ModelState.IsValid)   
            {   
                //objClienteRep.Atualizar(cliente);   
                return RedirectToAction("Index");   
            }   
            return View(cliente);   
        }  

        [HttpGet]   
        public IActionResult Detalhes(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   
            Cliente cliente = objClienteRep.BuscarClientePorId(id);   
        
            if (cliente == null)   
            {   
                return NotFound();   
            }   
            return View(cliente);   
        }

        [HttpGet]   
        public IActionResult Excluir(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            Cliente cliente = null;// objClienteRep.BuscarClientePorId(id);  
        
            if (cliente == null)   
            {   
                return NotFound();   
            }   
            return View(cliente);   
        }   
        
        [HttpPost, ActionName("Excluir")]   
        [ValidateAntiForgeryToken]   
        public IActionResult ExclusaoConfirmada(int? id)   
        {   
            objClienteRep.Excluir(id);   
            return RedirectToAction("Index");   
        }
    }
}