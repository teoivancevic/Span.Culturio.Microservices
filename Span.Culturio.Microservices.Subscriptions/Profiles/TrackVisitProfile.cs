using System;
using AutoMapper;
using Span.Culturio.Microservices.Subscriptions.Data.Entities;
using Span.Culturio.Microservices.Core.Models;

namespace Span.Culturio.Microservices.Subscriptions.Profiles
{
    public class TrackVisitProfile : Profile
    {
        public TrackVisitProfile()
        {
            CreateMap<TrackVisitDto, TrackVisit>();
            CreateMap<TrackVisit, TrackVisitDto>();

            CreateMap<CreateTrackVisitDto, TrackVisit>();
            CreateMap<CreateTrackVisitDto, TrackVisitDto>();
        }
    }
}

