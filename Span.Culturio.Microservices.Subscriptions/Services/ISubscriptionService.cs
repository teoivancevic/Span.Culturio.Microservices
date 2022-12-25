using System;
using Span.Culturio.Microservices.Subscriptions.Models;

namespace Span.Culturio.Microservices.Subscriptions.Services
{
    public interface ISubscriptionService
    {
        public Task<IEnumerable<SubscriptionDto>> GetSubscriptions(int id);

        public Task<SubscriptionDto> CreateSubscription(CreateSubscriptionDto subscription);
        public Task<bool> TrackVisit(CreateTrackVisitDto trackVisit, string accessToken);
        public Task<bool> ActivateSubscription(ActivateSubscriptionDto activateSubscription, string accessToken);
    }
}

