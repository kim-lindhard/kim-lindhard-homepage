# Is it ok for a factory to return null?

## Super short answer

No, it contradicts the intent of the factory patterns.

## The long answer

### The definition of a factory

[refactoring.guru](https://refactoring.guru/design-patterns/factory-comparison) has a great definition of a factory. They state:

>Factory is an ambiguous term that stands for a function, method or class that's supposed to be producing something. Most commonly, factories produce objects, but they may also produce files, records in databases, etc.

We can define 4 patterns as factories:

1. (Static) creation method \
   You make the constructor private and rely on other methods to instantiate the object.

1. Simple factory pattern \
   A method will return one of several implementations or sub-classes based on the input given the method.

1. Factory method \
   Your class defines an abstract interface for creating an object and lets its sub-classes decide what class to instantiate.

1. Abstract factory \
   Declare an interface for operations that creates abstract product objects.

### Why you shouldn't return null from a factory

Null is a reference that does not point to any object. We reserve a space for a given type and explicitly say the object is not there.

We will be met with a `NullPointerException` in any attempt to access the object that is not there. This means we will have to handle the fact that the object is null or face the consequences of getting a `NullPointerException`.

This leaves us with a choice: should we let the factory fail in the creation of an object or handle the noneexistence of an object. I recommend that we let the creation fail for the following reasons:

- If we return null from a factory, we abandon the opportunity to tell the caller why the factory could not create an object and leave it up to them to figure out on their own what to do differently to change the outcome.

- The less potential null pointers we have in our code, the simpler it is to read and write.
- The factory method and abstract factory patterns are creational patterns; In the book, [Design Patterns](https://en.wikipedia.org/wiki/Design_Patterns), the first paragraph describing creational patterns states:
    >Creational design patterns abstract the instantiation process

    hence returning a null pointer is opposite the intent of the creational patterns.

### What you can do instead of returning null

There are many alternatives to returning a null, some of them include:

- Return a null or a none object.
- Return a collection of results and enumerate over the result collection. In the case where the factory fails to produce a result the collection will be empty and 0 enumerations will happen.
- Return a option, maybe or either monad.
- Use a TryGet pattern to indicate if that the creation was successful or not.

The above are fine alternatives but none of them helps the client alter the input to produce a desired result.
I suggest we use one or both of the following strategies:

- Throw a meaningful exception, and let the caller handle the exception as they wish.  
- Ask the factory if it can instantiate an object with the given input before you command it to do so. If not, tell the client what their options are.

Both strategies are illustrated in the example below. I used a simple factory to illustrate the strategies; you should be able to apply the suggestions to any factory pattern.

```C#
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
```

[The rest of the code example can be found here](NoneNullFactoryExample.cs)

It is important to state that it is not enough for the factory to throw an exception or return a boolean on CanCreate if it can't create an object with the given input. The factory has to state what is wrong and optimally, also state what the client's options are for resolving the issue.

## Conclusion & thoughts

Null reference as a product of a factory is incompatible with the concept of a factory as an object where something is produced.

You usually do a null check soon after you get an object reference that potentially could be null. Why not do the work ahead of time and propagate the needed information back to the client or user that enables them to change the input to something that will let the factory produce a result.

## Sources

[Design Patterns: Elements of Reusable Object-Oriented Software](https://en.wikipedia.org/wiki/Design_Patterns) (Book)

[https://refactoring.guru/design-patterns/factory-comparison](https://refactoring.guru/design-patterns/factory-comparison)

[Wikipedia Factory](https://en.wikipedia.org/wiki/Factory_(object-oriented_programming))