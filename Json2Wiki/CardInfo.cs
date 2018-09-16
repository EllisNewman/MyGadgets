using System;
using System.Collections.Generic;

namespace Json2Wiki
{
    public class Costume
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// [あじさいドロップ]春日未来
        /// </summary>
        public string name { get; set; }

        public string description { get; set; }
    }

    public class BonusCostume
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// [あじさいドロップ+]春日未来
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 「あじさいドロップ」の
        /// </summary>
        public string description { get; set; }
    }

    public class CenterEffect
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Princessタイプのみ編成時、ボーカル値が95％アップ
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// IdolType
        /// </summary>
        public int idolType { get; set; }
        /// <summary>
        /// SpecificIdolType
        /// </summary>
        public int specificIdolType { get; set; }
        /// <summary>
        /// Attribute
        /// </summary>
        public int attribute { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public int value { get; set; }
    }

    public class Skill
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 9秒ごとに{0}％の確率で5秒間、Perfectのスコアが10％アップ、コンボボーナスが5％アップ
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// EffectId
        /// </summary>
        public int effectId { get; set; }
        /// <summary>
        /// Evaluation
        /// </summary>
        public int evaluation { get; set; }
        /// <summary>
        /// Duration
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// Interval
        /// </summary>
        public int interval { get; set; }
        /// <summary>
        /// Probability
        /// </summary>
        public int probability { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public List<int> value { get; set; }
    }

    public class CardInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 無邪気なレイニーデイズ　春日未来
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// SortId
        /// </summary>
        public int sortId { get; set; }
        /// <summary>
        /// IdolId
        /// </summary>
        public int idolId { get; set; }
        /// <summary>
        /// 014mir0064
        /// </summary>
        public string resourceId { get; set; }
        /// <summary>
        /// Rarity
        /// </summary>
        public int rarity { get; set; }
        /// <summary>
        /// ExtraType
        /// </summary>
        public int extraType { get; set; }
        /// <summary>
        /// Costume
        /// </summary>
        public Costume costume { get; set; }
        /// <summary>
        /// BonusCostume
        /// </summary>
        public BonusCostume bonusCostume { get; set; }

        public string flavorText { get; set; }

        public string flavorTextAwakened { get; set; }
        /// <summary>
        /// LevelMax
        /// </summary>
        public int levelMax { get; set; }
        /// <summary>
        /// LevelMaxAwakened
        /// </summary>
        public int levelMaxAwakened { get; set; }
        /// <summary>
        /// VocalMin
        /// </summary>
        public int vocalMin { get; set; }
        /// <summary>
        /// VocalMax
        /// </summary>
        public int vocalMax { get; set; }
        /// <summary>
        /// VocalMinAwakened
        /// </summary>
        public int vocalMinAwakened { get; set; }
        /// <summary>
        /// VocalMaxAwakened
        /// </summary>
        public int vocalMaxAwakened { get; set; }
        /// <summary>
        /// VocalMasterBonus
        /// </summary>
        public int vocalMasterBonus { get; set; }
        /// <summary>
        /// DanceMin
        /// </summary>
        public int danceMin { get; set; }
        /// <summary>
        /// DanceMax
        /// </summary>
        public int danceMax { get; set; }
        /// <summary>
        /// DanceMinAwakened
        /// </summary>
        public int danceMinAwakened { get; set; }
        /// <summary>
        /// DanceMaxAwakened
        /// </summary>
        public int danceMaxAwakened { get; set; }
        /// <summary>
        /// DanceMasterBonus
        /// </summary>
        public int danceMasterBonus { get; set; }
        /// <summary>
        /// VisualMin
        /// </summary>
        public int visualMin { get; set; }
        /// <summary>
        /// VisualMax
        /// </summary>
        public int visualMax { get; set; }
        /// <summary>
        /// VisualMinAwakened
        /// </summary>
        public int visualMinAwakened { get; set; }
        /// <summary>
        /// VisualMaxAwakened
        /// </summary>
        public int visualMaxAwakened { get; set; }
        /// <summary>
        /// VisualMasterBonus
        /// </summary>
        public int visualMasterBonus { get; set; }
        /// <summary>
        /// Life
        /// </summary>
        public int life { get; set; }
        /// <summary>
        /// CenterEffect
        /// </summary>
        public CenterEffect centerEffect { get; set; }
        /// <summary>
        /// Princessディーヴァ
        /// </summary>
        public string centerEffectName { get; set; }
        /// <summary>
        /// Skill
        /// </summary>
        public List<Skill> skill { get; set; }
        /// <summary>
        /// 愛らしく咲いて
        /// </summary>
        public string skillName { get; set; }
        /// <summary>
        /// 2018-06-29T15:00:00+09:00
        /// </summary>
        public string addDate { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// CardInfo2
        /// </summary>
        public CardInfo CardInfo { get; set; }
        /// <summary>
        /// TrimArray
        /// </summary>
        public string trimArray { get; set; }
        /// <summary>
        /// Remove
        /// </summary>
        public string remove { get; set; }
        /// <summary>
        /// Unique
        /// </summary>
        public string unique { get; set; }
        /// <summary>
        /// SameCount
        /// </summary>
        public string sameCount { get; set; }
        /// <summary>
        /// Contains
        /// </summary>
        public string contains { get; set; }
    }
}
