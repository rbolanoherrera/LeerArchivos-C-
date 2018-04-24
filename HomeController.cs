using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppLeerArchivo.Controllers
{

public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int counter = 0;
            string line;
            string[] campos;
            int linesProc = 0;//lineas procesadas
            int linesNoProc = 0;//lineas no procesadas

            System.IO.StreamReader file = null;

            try
            {
                file = new System.IO.StreamReader(@"D:\_rafa\_net\LeerArchivo\WebAppLeerArchivo\Files\test1.txt");

                while ((line = file.ReadLine()) != null)
                {
                    System.Diagnostics.Debug.WriteLine(line);
                    counter++;
                    campos = line.Split('|');

                    if (campos != null)
                    {
                        if (campos.Length >= 7)
                        {
                            try
                            {
                                System.Diagnostics.Debug.WriteLine("tipoDoc:" + campos[0]);
                                System.Diagnostics.Debug.WriteLine("Doc:" + campos[1]);
                                System.Diagnostics.Debug.WriteLine("Nombres:" + campos[2]);
                                System.Diagnostics.Debug.WriteLine("Apellidos:" + campos[3]);
                                System.Diagnostics.Debug.WriteLine("Email:" + campos[4]);
                                System.Diagnostics.Debug.WriteLine("Valor:" + campos[5]);
                                System.Diagnostics.Debug.WriteLine("%Iva:" + campos[6]);

                                linesProc++;
                            }
                            catch (Exception ex)
                            {
                                linesNoProc++;

                                System.Diagnostics.Debug.WriteLine("Error1: " +  ex.Message);
                                System.Diagnostics.Debug.WriteLine("Linea no procesada (error al procesar datos):" + line);
                            }

                        }
                        else if (line.Length <= 0)
                        {
                            System.Diagnostics.Debug.WriteLine("Linea no procesada (en blanco):");
                        }
                        else if (!line.Contains("|"))
                        {
                            System.Diagnostics.Debug.WriteLine("Linea no procesada (sin caracter separador):" + line);
                        }
                        else if (campos.Length > 1)
                        {
                            linesNoProc++;
                            System.Diagnostics.Debug.WriteLine("Linea no procesada (campos incompletos):" + line);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Linea no procesada:" + line);
                        }
                    }
                    else
                    {
                        linesNoProc++;
                        System.Diagnostics.Debug.WriteLine("Linea no procesada (sin caracter separador):" + line);
                    }
                }
            }
            catch (FieldAccessException fe)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + fe.Message);
            }
            finally
            {
                if(file != null)
                    file.Close();
            }
            
            System.Diagnostics.Debug.WriteLine("Total de lineas: {0}", counter);
            System.Diagnostics.Debug.WriteLine("Lineas procesadas: {0}", linesProc);
            System.Diagnostics.Debug.WriteLine("Lineas NO procesadas: {0}", linesNoProc);

            return View();
        }
   }
}
