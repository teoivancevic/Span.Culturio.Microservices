using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Span.Culturio.Microservices.Core.Models;
using Span.Culturio.Microservices.Subscriptions.Services;

namespace Span.Culturio.Microservices.Subscriptions.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]

    public class SubscriptionsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IConfiguration _configuration;

        public SubscriptionsController(ILogger<SubscriptionsController> logger, ISubscriptionService subscriptionService, IConfiguration configuration)
        {
            _logger = logger;
            _subscriptionService = subscriptionService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubscriptionDto>>> GetSubscriptions(int userId)
        {
            var subscriptions = await _subscriptionService.GetSubscriptions(userId);

            return Ok(subscriptions);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubscription([FromBody] CreateSubscriptionDto subscription)
        {
            var subscriptionDto = await _subscriptionService.CreateSubscription(subscription);
            if (subscription is null)
            {
                return BadRequest("Could not create subscription.");
            }

            return Ok();

        }

        [HttpPost("activate")]
        public async Task<ActionResult> ActivateSubscription([FromBody] ActivateSubscriptionDto subscription)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];
            var result = await _subscriptionService.ActivateSubscription(subscription, accessToken);
            if (!result)
            {
                return BadRequest("Could not activate subscription.");
            }

            return Ok();

        }

        
        // Ova API metoda radi, ali na ja mislim glup nacin
        [HttpPost("track-visit")]
        public async Task<ActionResult> TrackVisit([FromBody] CreateTrackVisitDto trackVisit)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];

            var result = await _subscriptionService.TrackVisit(trackVisit, accessToken);
            if (!result)
            {
                return BadRequest("Invalid request. Subscription already used up all visits to this culture object.\n(also check if input is correct and if subscription is active)");
            }

            return Ok();
        }
        

        

    }
}

