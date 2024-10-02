﻿using osu.Framework.Bindables;
using osu.Framework.Localisation;
using osu.Game.Beatmaps;
using osu.Game.Configuration;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.PumpTrainer.Beatmaps;

namespace osu.Game.Rulesets.PumpTrainer.Mods
{
    public class PumpTrainerModDiagonalTwists : Mod, IApplicableToBeatmapConverter
    {
        [SettingSource("Frequency")]
        public Bindable<double> DiagonalTwistFrequency { get; } = new BindableDouble(0.5)
        {
            MinValue = 0.1,
            MaxValue = 1.0,
            Default = 0.5,
            Precision = 0.1,
        };

        public override string Name => "[AT LEAST S] Diagonal twists";
        public override string Acronym => "DDD";
        public override LocalisableString Description =>
            "Crossovers across a single panel, including the center panel.\n" +
            "Requires the \"horizontal twists\" mod to be enabled.";
        public override double ScoreMultiplier => 1;
        public override ModType Type => ModType.DifficultyIncrease;

        public void ApplyToBeatmapConverter(IBeatmapConverter beatmapConverter)
        {
            var pumpBeatmapConverter = (PumpTrainerBeatmapConverter)beatmapConverter;

            pumpBeatmapConverter.Settings.DiagonalTwistFrequency = DiagonalTwistFrequency.Value;
        }
    }
}
