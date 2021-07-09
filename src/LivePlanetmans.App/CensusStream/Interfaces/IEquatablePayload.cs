using LivePlanetmans.App.CensusStream.Models;
using System;

namespace LivePlanetmans.App.CensusStream
{
    public interface IEquatablePayload<T> : IEquatable<T> where T : PayloadBase
    {
    }
}
