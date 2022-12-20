using System;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Net.Http;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Microservices.Subscriptions.Data;
using Span.Culturio.Microservices.Subscriptions.Models;

namespace Span.Culturio.Microservices.Subscriptions.Services
{
    public class SubscriptionService : ISubscriptionService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public SubscriptionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SubscriptionDto>> GetSubscriptions(int id)
        {
            var subscriptions = await _context.Subscriptions.Where(x => x.UserId.Equals(id)).ToListAsync();
            var subscriptionsDto = _mapper.Map<List<SubscriptionDto>>(subscriptions);

            return subscriptionsDto;

        }


        public async Task<SubscriptionDto> CreateSubscription(CreateSubscriptionDto subscription)
        {
            var subscriptionEntity = _mapper.Map<Data.Entities.Subscription>(subscription);

            subscriptionEntity.State = "not active";

            _context.Subscriptions.Add(subscriptionEntity);
            await _context.SaveChangesAsync();

            var subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptionDto;
        }


        //ovo je update za ovaj subscription
        public async Task<SubscriptionDto> ActivateSubscription(ActivateSubscriptionDto activateSubscription)
        {
            var subscription = await _context.Subscriptions.FindAsync(activateSubscription.SubscriptionId);
            if (subscription is not null && subscription.State != "active")
            {
                //var package = await _context.Packages.FindAsync(subscription.PackageId);

                //var package = new PackageDto();
                int days = 1;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://culturio-packages");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    string path = "api/packages/" + subscription.PackageId.ToString() + "/days";

                    var response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        days = response.Content.ReadAsAsync<int>().Result;

                    }

                }

                subscription.State = "active";
                subscription.ActiveFrom = DateTime.Now;
                //subscription.ActiveTo = subscription.ActiveFrom.AddDays(package.ValidDays); // uzima broj valid dana iz paketa na koji se subscribea

                subscription.ActiveTo = subscription.ActiveFrom.AddDays(days);

                _context.Subscriptions.Update(subscription);
                await _context.SaveChangesAsync();

            }

            SubscriptionDto subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptionDto;
        }




        public async Task<bool> TrackVisit(CreateTrackVisitDto trackVisit)
        {

            var subscription = await _context.Subscriptions.FindAsync(trackVisit.SubscriptionId);
            if (subscription is not null && subscription.ActiveTo >= DateTime.Now && subscription.State == "active")
            {

                //  prvo trebam GET package po id-ju koji je zadan u subscription.PackageId
                //      iz ovoga trebam izvuc available visits za cultureobject prema trackvisit.CultureObjectId
                //  drugo trebam GET timesVisited iz tablice (to vec potencijalno radi kako tre
                int availableVisits = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://culturio-packages");
                    //client.BaseAddress = new Uri("http://localhost:5005");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    string path = "api/packages/available-visits/" + subscription.PackageId.ToString() + "/" + trackVisit.CultureObjectId.ToString();
                    var response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        availableVisits = response.Content.ReadAsAsync<int>().Result;

                        //availableVisits = await package.CultureObjects;


                    }


                   
                    var timesVisited = _context.TrackVisits.Count(x => x.SubscriptionId == trackVisit.SubscriptionId && x.CultureObjectId == trackVisit.CultureObjectId);


                    if (timesVisited < availableVisits)
                    {
                        var trackVisitEntity = _mapper.Map<Data.Entities.TrackVisit>(trackVisit);
                        trackVisitEntity.TimeEntered = DateTime.Now;

                        _context.TrackVisits.Add(trackVisitEntity);
                        await _context.SaveChangesAsync();

                        return true;

                    }
                }


                return false;
            }

            return false;


        }
    }
}
