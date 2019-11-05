using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CodeSamples
{
    public class Speaker
    {
        public virtual string SayHello() => "Hello";
        public string SayNothing() => "";
    }

    public class SpanishSpeaker : Speaker
    {
        public override string SayHello() => "Hola";
    }

    public class DanishSpeaker : Speaker
    {
        public override string SayHello() => "Hej";
    }

    public class Capable
    {
    }

    public class IsCapable : Capable
    {
    }

    public class IsNotCapable : Capable
    {
        public ReadOnlyCollection<string> ReasonsWhy { get; private set; }

        public IsNotCapable(params string[] reasonsWhy)
        {
            ReasonsWhy = reasonsWhy.ToList().AsReadOnly();
        }
    }

    public static class SpeakerFactory
    {
        private static readonly Dictionary<string, Func<Speaker>> Alpha2CodeToSpeaker =
            new Dictionary<string, Func<Speaker>>
            {
                {"ES", () => new SpanishSpeaker()},
                {"DK", () => new DanishSpeaker()}
            };

        public static Capable CanCreateFromAlphaCode2(string alpha2Code)
        {
            if (Alpha2CodeToSpeaker.ContainsKey(alpha2Code))
            {
                return new IsCapable();
            }

            var isNotCapable = new IsNotCapable(
                $"Can't create a speaker from the given value: '{alpha2Code}'," +
                $" valid values are '{string.Join(", ", Alpha2CodeToSpeaker.Keys)}'");

            return isNotCapable;
        }

        public static Speaker CreateFromAlphaCode2(string alpha2Code)
        {
            var capability = CanCreateFromAlphaCode2(alpha2Code);
            if (capability is IsNotCapable notCapable)
            {
                throw new NotSupportedException(
                    string.Join(Environment.NewLine, notCapable.ReasonsWhy)
                );
            }

            return Alpha2CodeToSpeaker[alpha2Code].Invoke();
        }
    }

    public class UnitTest
    {
        private readonly ITestOutputHelper output;

        public UnitTest(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Fact]
        public void WillTellYouWhatYouCanDoIfItCantCreate()
        {
            var alpha2Code = "NotAAlpha2Code";
            var capable = SpeakerFactory.CanCreateFromAlphaCode2(alpha2Code);
            if (capable is IsNotCapable notCapable)
            {
                foreach (var reason in notCapable.ReasonsWhy)
                {
                    output.WriteLine("Couldn't create a speaker, here is why:");
                    output.WriteLine(reason);
                }

                return;
            }

            var speaker = SpeakerFactory.CreateFromAlphaCode2(alpha2Code);


            output.WriteLine(speaker.SayHello());
        }

        [Fact]
        public void WillSayHeyWhenAlpha2CoDeIsDK()
        {
            var alpha2Code = "DK";
            var capable = SpeakerFactory.CanCreateFromAlphaCode2(alpha2Code);
            if (capable is IsNotCapable notCapable)
            {
                foreach (var reason in notCapable.ReasonsWhy)
                {
                    output.WriteLine("Coulden't create a speaker, here is why:");
                    output.WriteLine(reason);
                }

                return;
            }

            var speaker = SpeakerFactory.CreateFromAlphaCode2(alpha2Code);


            output.WriteLine(speaker.SayHello());
        }
    }
}