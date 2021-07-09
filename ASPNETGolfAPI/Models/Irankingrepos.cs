using System;
using System.Collections.Generic;

namespace ASPNETGolfAPI.Models
{
    public interface Irankingrepos
    {

        public IEnumerable<Ranking> GetAllRankings();
    }
}
