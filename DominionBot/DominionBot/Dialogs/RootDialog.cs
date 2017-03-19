using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Linq;

namespace DominionBot.Dialogs
{
    [LuisModel("51e04523-a3e7-40f7-8cff-133423318062", "73d3cded73bf4406ae01093d9c1e32b3")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        public RootDialog()
        {

        }

        public RootDialog(ILuisService service)
            : base(service)
        {
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent), result.Entities.Select(i=>i.Entity));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }


        [LuisIntent("Card Type")]
        public async Task CardType(IDialogContext context, LuisResult result)
        {
            
            //string message = $"Card Type: " + string.Join(", ", result.Intents.Select(i => i.Intent), result.Entities.Select(i => i.Entity));
            
            var DB = new Models.DominionBot_dbEntities();
            

            var card = DB.Dominions.Find("Estate");

            var resultMessage = context.MakeMessage();

            //activity.Attachments.Add(new Attachment()
            //{
            //    ContentUrl = "https://upload.wikimedia.org/wikipedia/en/a/a6/Bender_Rodriguez.png",
            //ContentType = "image/png",
            //    Name = card.Card
            //});

            //activity.Type = "message";
            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: card.PictureUrl));
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = card.Url,
                Type = "openUrl",
                Title = card.Card + " Wiki Page"
            };
            cardButtons.Add(plButton);
            HeroCard plCard = new HeroCard()
            {
                Title = card.Card,
                Images = cardImages,
                Buttons = cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();
            resultMessage.Attachments.Add(plAttachment);

            await context.PostAsync(resultMessage);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Game")]
        public async Task Game(IDialogContext context, LuisResult result)
        {
            string message = $"Game: " + string.Join(", ", result.Intents.Select(i => i.Intent), result.Entities.Select(i => i.Entity));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Expansion")]
        public async Task Expansion(IDialogContext context, LuisResult result)
        {
            string message = $"Expansion: " + string.Join(", ", result.Intents.Select(i => i.Intent), result.Entities.Select(i => i.Entity));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Hello")]
        public async Task Hello(IDialogContext context, LuisResult result)
        {
            string message = $"Hello: " + string.Join(", ", result.Intents.Select(i => i.Intent), result.Entities.Select(i => i.Entity));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}