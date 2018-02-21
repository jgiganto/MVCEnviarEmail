using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Security.Cryptography;

namespace MVCEnviarEmail.Controllers
{
    public class CifradoController : Controller
    {
        // GET: Cifrado
        public ActionResult CifradoHash()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CifradoHash(String texto,String resultado,String accion)
        {
            String datocifrado = this.EncriptarTexto(texto);
            if (accion == "cifrar")
            {
                ViewBag.Resultado = datocifrado;
            }
            else if (accion == "comparar")
            {
                //comparamos el dato cifrado con el resultado
                if (resultado != datocifrado)
                {
                    ViewBag.Mensaje = "<h2 style='color:red'>Diferentes</h2>";
                }
                else
                {
                    ViewBag.Mensaje = "<h2 style='color:red'>Iguales</h2>";
                }
                ViewBag.Resultado=resultado;
            }
            return View();
        }

        public String EncriptarTexto(String texto)
        {
            byte[] entrada;
            byte[] salida;
            //conversor de byte a String y al reves..
            UnicodeEncoding conversor = new UnicodeEncoding();
            //objeto para realizar el cifrado (sha)
            SHA1Managed cypher = new SHA1Managed();
            //convertimos el texto a bytes
            entrada = conversor.GetBytes(texto);
            //con los bytes de entrada se indica que genere un hash unico y nos devuelva otro byte[]
            salida = cypher.ComputeHash(entrada);
            //lo convertimos a cadena para poder visualizarlo.. 
            return conversor.GetString(salida);


        }
    }
}