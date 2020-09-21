using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lab15._1ConsumingAnAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab15._1ConsumingAnAPI.Controllers
{
    public class DrawHand : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com/api/");

            var response = await client.GetAsync("deck/new/shuffle/?deck_count=1");
            Deck info = await response.Content.ReadAsAsync<Deck>();



            return View(info);
        }


        public async Task<IActionResult> ShowHand(Deck deck)
        {
           
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://deckofcardsapi.com/api/");
            int cardCount = 5;

            var response = await client.GetAsync($"deck/{deck.deck_id}/draw/?count={cardCount}");
            Hand playingHand = new Hand();
            for (int i = 1; i == cardCount; i++)
            {

                Card drawnCard = await response.Content.ReadAsAsync<Card>();

                playingHand.handCards.Add(drawnCard);
            }



            return View(playingHand);
        }
        }
    }
