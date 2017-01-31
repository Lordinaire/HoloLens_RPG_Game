using System;
using System.Collections.Generic;
using Assets.Scripts.Models;
using UniRx;

namespace Assets.Scripts.ReactiveModels
{
    public class RxMap
    {
        public Map Data;

        public ReactiveCollection<Case> Cases { get; private set; }

        public RxMap(Map data)
        {
            Data = data;
            Cases = new ReactiveCollection<Case>(data.Cases);
        }
    }
}
