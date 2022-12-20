using System;
using AutoMapper;
using Span.Culturio.Microservices.Subscriptions.Data.Entities;
using Span.Culturio.Microservices.Subscriptions.Models;

namespace Span.Culturio.Microservices.Subscriptions.Profiles
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<Subscription, SubscriptionDto>();
            CreateMap<SubscriptionDto, Subscription>();

            CreateMap<CreateSubscriptionDto, SubscriptionDto>();

            CreateMap<CreateSubscriptionDto, Subscription>();
        }
    }
}

