using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HelloWorld.Controllers
{
    public class GamesController:Controller
    {
        Deck model = new Deck();

        public ActionResult Solitaire()
        {
            model = new Deck();
            return View(model);
        }

        [HttpGet]
        public string GetCard()
        {
            CardModel newCard = model.getCard();
            return new JavaScriptSerializer().Serialize(newCard);
        }
    }
}