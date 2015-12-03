using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace FritzysPetCarePros.Controls
{
    public partial class GGP : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnGift.ImageUrl = Session["HomePath"] + "Images/giftcard.jpg";

            btnGrommer.ImageUrl = Session["HomePath"] + "Images/btn_groomers_blog.jpg";

            btnPetLover.ImageUrl = Session["HomePath"] + "Images/btn_pet_lovers_blog.jpg";

            btnAppointment.ImageUrl = Session["HomePath"] + "Images/make_appointment_now.jpg";
        }
    }
}