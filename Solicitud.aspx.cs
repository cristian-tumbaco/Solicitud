using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Threading;

namespace Solicitud
{
    public partial class Solicitud : System.Web.UI.Page
    {
        List<Usuario> micola1 = new List<Usuario>();
        List<Usuario> micola2 = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObtenerSolicitudes();
            }
            else
            {
                if (Session["cola1"] != null)
                    micola1 = (List<Usuario>)Session["cola1"];
                if (Session["cola2"] != null)
                    micola2 = (List<Usuario>)Session["cola2"];
            }
        }
        
        private void ObtenerSolicitudes()
        {
            try
            {
                using (SolicitudesEntities contex = new SolicitudesEntities())
                {
                    if (contex.Usuarios.Count() > 0)
                    {
                        var cola1 = (from em in contex.Usuarios
                                     where em.atendido == false && em.cola == 1
                                     select em).ToList();
                        
                        var cola2 = (from em in contex.Usuarios
                                     where em.atendido == false && em.cola == 2
                                     select em).ToList();

                        foreach (var item in cola1)
                        {
                            micola1.Add(item);
                        }
                        foreach (var item in cola2)
                        {
                            micola2.Add(item);
                        }
                        Session["cola1"] = cola1;
                        Session["cola2"] = cola2;

                        gdCola1.DataSource = cola1;
                        gdCola1.DataBind();

                        gdCola2.DataSource = cola2;
                        gdCola2.DataBind();

                        upColas.Update();
                        upCola2.Update();
                    }
                    else
                    {
                        gdCola1.DataSource = null;
                        gdCola2.DataSource = null;
                        gdCola1.DataBind();
                        gdCola2.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int valCola = ElegirCola();
                using (SolicitudesEntities contex = new SolicitudesEntities())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.nombre = txtNombre.Text.Trim();
                    objUsuario.cola = valCola;
                    objUsuario.atendido = false;
                    contex.Usuarios.Add(objUsuario);
                    contex.SaveChanges();
                    if (valCola == 1)
                        micola1.Add(objUsuario);
                    else
                        micola2.Add(objUsuario);
                    ObtenerSolicitudes();
                    txtNombre.Text = string.Empty;
                    upTexto.Update();
                    upColas.Update();
                    upCola2.Update();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int ElegirCola()
        {
            int usCol1, usCol2, rp = 0;
            usCol1 = micola1.Count;
            usCol2 = micola2.Count;
            if (usCol1 == 0 && usCol2 == 0)
                rp = 1;
            else if ((usCol1 * 2) > (usCol2 * 3))
                    rp = 2;
                else if ((usCol1 * 2) < (usCol2 * 3))
                    rp = 1;
                else
                    rp = 1;
            
            return rp;
        }

        public void AtenderCola1()
        {
            if (micola1.Count() > 0)
            {
                Usuario objUsuario = new Usuario();
                objUsuario = micola1[0];
                using (SolicitudesEntities contex = new SolicitudesEntities())
                {
                    var usu = contex.Usuarios.First(a => a.id == objUsuario.id);
                    usu.atendido = true;
                    contex.SaveChanges();
                    micola1.Remove(objUsuario);
                    gdCola1.DataSource = micola1;
                    gdCola1.DataBind();
                    upColas.Update();
                }
            }
        }

        public void AtenderCola2()
        {
            if (micola2.Count() > 0)
            {
                Usuario objUsuario = new Usuario();
                objUsuario = micola2[0];
                using (SolicitudesEntities contex = new SolicitudesEntities())
                {
                    var usu = contex.Usuarios.First(a => a.id == objUsuario.id);
                    usu.atendido = true;
                    contex.SaveChanges();
                    micola2.Remove(objUsuario);
                    gdCola2.DataSource = micola2;
                    gdCola2.DataBind();
                    upCola2.Update();
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblCola1.Text = "Atendiendo";
            AtenderCola1();
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            lblCola2.Text = "Atendiendo";
            AtenderCola2();
        }
    }
}