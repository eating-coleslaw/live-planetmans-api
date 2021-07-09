﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivePlanetmans.App.CensusStream.EventProcessors
{
    
    // Contains properties / methods that should be available to all Event Processors
    public class EventProcessorBase
    {

        protected virtual bool ShouldStoreEvent()
        {
            return false;
        }

        protected bool IsValidCharacterId(string characterId)
        {
            return !string.IsNullOrWhiteSpace(characterId) && characterId.Length > 18;
        }
    }
}