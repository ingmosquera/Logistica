﻿using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace WebApiLogistica.Providers
{
    public class RefreshTokenProvider : AuthenticationTokenProvider
    {
        public override void Create(AuthenticationTokenCreateContext context)
        {
            //Get the claim which holds creation date
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var creationDate = Convert.ToDateTime(identity.Claims.Where(c => c.Type == "creationDate").Single().Value);
            //Create a variable holding current time minus 30 seconds(This is how long time you can create new refresh tokens by providing your original refresh token)
            DateTime now = DateTime.UtcNow.AddSeconds(-30);


            //If the time has passed more than 30 seconds from the time you got your original access and refresh token by providing credentials
            //you may not create and return new refresh tokens(Obviously the 30  seconds could be changed to something less or more aswell)
            if (now < creationDate)
            {
                // Expiration time in seconds
                int expire = 2 * 60;
                context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddSeconds(expire));
                context.SetToken(context.SerializeTicket());
            }
        }


        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
    }
}