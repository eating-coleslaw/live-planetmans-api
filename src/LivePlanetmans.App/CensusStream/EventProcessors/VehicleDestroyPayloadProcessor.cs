using LivePlanetmans.Data.Models.Events;
using LivePlanetmans.Data.Repositories;
using Microsoft.Extensions.Logging;
using LivePlanetmans.App.CensusStream.Models;
using System;
using System.Threading.Tasks;
using LivePlanetmans.Data.Models.Census;
using LivePlanetmans.App.Services.Planetside;

namespace LivePlanetmans.App.CensusStream.EventProcessors
{
    [CensusEventProcessor("VehicleDestroy")]
    public class VehicleDestroyPayloadProcessor : EventProcessorBase, IEventProcessor<VehicleDestroyPayload>
    {
        private readonly IEventRepository _eventRepository;
        private readonly ICharacterService _characterService;
        private readonly ILogger<VehicleDestroyPayloadProcessor> _logger;

        private PayloadUniquenessFilter<VehicleDestroyPayload> _vehicleDestroyFilter = new PayloadUniquenessFilter<VehicleDestroyPayload>();

        public VehicleDestroyPayloadProcessor(IEventRepository eventRepository, ICharacterService characterService, ILogger<VehicleDestroyPayloadProcessor> logger)
        {
            _eventRepository = eventRepository;
            _characterService = characterService;
            _logger = logger;
        }

        public async Task Process(VehicleDestroyPayload payload)
        {
            if (!await _vehicleDestroyFilter.TryFilterNewPayload(payload, p => $"{p.Timestamp:s}^{p.AttackerCharacterId}^{p.CharacterId}^{p.AttackerVehicleId}"))
            {
                return;
            }

            var attackerId = payload.AttackerCharacterId;
            var victimId = payload.CharacterId;

            var isValidAttackerId = IsValidCharacterId(attackerId);
            var isValidVictimId = IsValidCharacterId(victimId);

            // By default, don't track players destroying unclaimed vehicles
            if (!isValidVictimId)
            {
                return;
            }

            try
            {
                if (isValidAttackerId)
                {
                    // Do stuff like look up the Character name, faction, etc.
                }

                if (isValidVictimId)
                {
                    // Do stuff like look up the Character name, faction, etc.
                }

                var dataModel = new VehicleDestruction
                {
                    Timestamp = payload.Timestamp,
                    AttackerCharacterId = attackerId,
                    VictimCharacterId = victimId,
                    VictimVehicleId = payload.VehicleId,
                    AttackerVehicleId = payload.AttackerVehicleId,
                    WeaponId = payload.AttackerWeaponId,
                    ZoneId = payload.ZoneId,
                    WorldId = payload.WorldId
                };

                if (ShouldStoreEvent())
                {
                    await _eventRepository.AddAsync(dataModel);
                }


                // Send dataModel to other services for additional handling

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing VehicleDestroy payload: {ex}");

                return;
            }
        }

        protected override bool ShouldStoreEvent()
        {
            return base.ShouldStoreEvent();
        }

    }
}
