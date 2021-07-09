using LivePlanetmans.Data.Models.Events;
using LivePlanetmans.Data.Repositories;
using Microsoft.Extensions.Logging;
using LivePlanetmans.App.CensusStream.Models;
using System;
using System.Threading.Tasks;

namespace LivePlanetmans.App.CensusStream.EventProcessors
{
    [CensusEventProcessor("Death")]
    public class DeathPayloadProcessor : EventProcessorBase, IEventProcessor<DeathPayload>
    {
        private readonly IEventRepository _eventRepository;
        private readonly ILogger<DeathPayloadProcessor> _logger;

        private readonly PayloadUniquenessFilter<DeathPayload> _deathFilter = new PayloadUniquenessFilter<DeathPayload>();

        public DeathPayloadProcessor(IEventRepository eventRepository, ILogger<DeathPayloadProcessor> logger)
        {
            _eventRepository = eventRepository;
            _logger = logger;
        }

        public async Task Process(DeathPayload payload)
        {
            if (!await _deathFilter.TryFilterNewPayload(payload, p => p.Timestamp.ToString("s")))
            {
                return;
            }

            string attackerId = payload.AttackerCharacterId;
            string victimId = payload.CharacterId;

            bool isValidAttackerId = IsValidCharacterId(attackerId);
            bool isValidVictimId = IsValidCharacterId(victimId);

            try
            {
                if (isValidAttackerId == true)
                {
                    // Do stuff like look up the Character name, faction, etc.
                }

                if (isValidVictimId == true)
                {
                    // Do stuff like look up the Character name, faction, etc.
                }

                var dataModel = new Death
                {
                    Timestamp = payload.Timestamp,
                    AttackerCharacterId = attackerId,
                    VictimCharacterId = victimId,
                    ZoneId = payload.ZoneId,
                    WorldId = payload.WorldId,
                    AttackerLoadoutId = payload.AttackerLoadoutId,
                    VictimLoadoutId = payload.CharacterLoadoutId,
                    WeaponId = payload.AttackerWeaponId,
                    AttackerVehicleId = payload.AttackerVehicleId,
                    IsHeadshot = payload.IsHeadshot
                };

                if (ShouldStoreEvent())
                {
                    await _eventRepository.AddAsync(dataModel);
                }


                // Send dataModel to other services for additional handling

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing Death payload: {ex}");

                return;
            }
        }

        protected override bool ShouldStoreEvent()
        {
            return base.ShouldStoreEvent();
        }
    }
}
