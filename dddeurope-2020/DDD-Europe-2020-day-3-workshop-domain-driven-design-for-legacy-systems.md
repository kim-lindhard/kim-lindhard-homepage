# DDD Europe 2020 day 3 workshop Domain driven design for legacy systems

## Introduction to the workshop

Coming to the workshop I had one big nagging question: "how do you apply the concept of contexts to a existing system"? Unfortunately the answer laid in one of the first statements made by Marjin Huizendveld and it was that there is no silver bullet when it comes to applying domain driven design to legacy systems. However, there are some great heuristics we can use.

The workshop revolved around a fictional case of a National Rail-transport company. We where given  a workbook with information about the lessons we learned doing to day, data models from the fictional company and exercises. The exercises were made with an emphasis on how can we improve the experience for the potential passenger, this aligns very well with the idea Simon Wardley had where he states that the highest value of a company or system or even the smallest entity is what is of utmost visibility to the consumer.

The workshop introduced us to Wardley maps and added an extra dimension of drawing our context boundaries around groups of components in the map. The Wardley map made the training interesting because the finished map can help you make decisions about where to put your development energy and what to outsource. But in making the map you could also undertake the discipline of mapping out what is needed to fulfill a certain want from your customer. A example could be that I want a hot bagel at a cafe:

<img src='https://g.gravizo.com/svg?
@startuml;
    state "Hot bagel" as HotBagel;
    Customer --> HotBagel: Wants;
    state "Froozen bagels" as FroozenBagel;
    HotBagel --> FroozenBagel: needs;
    state "Bagel delivery" as BagelDelivery;
    FroozenBagel --> Freezer: needs;
    FroozenBagel --> BagelDelivery: needs;
    HotBagel --> Oven: needs;
    Freezer --> Electricity: needs;
    Oven --> Electricity: needs;
@enduml
'>

During the workshop we also got introduced to bubble contexts, a short lived bounded context that has a high coupling to context(s) in the existing system with the goal of evaluating the newly formed context within the bubble.

Overall a great workshop, a great introduction to applying ddd to legacy systems, but no silver bullets. This is mainly due to the fact that the is no one answer and that you can't get that deep into the topic transforming legacy systems within the span of a single day, even with a great facilitator as Marjin.

## Things I learned today

* Ideas are cheap, don't run with the first one, try to think objectively to come up with three or four alternative ideas and compare their benefits, importance and drawbacks.
* When considering a solution always give some real thoughts to the following questions; how is this going to impact our current operations, are we strongly altering the existing system? What degree of risk will there be when deploying this solution?
* When looking at a domain consider the possibilities of what implicit concepts or flows one would benefit from modeling explicitly?
* Bubbles can be bigger than the original system they stem from, this could happen if only we are more explicit when modeling the bubble than how the original context is modeled.
* When gauging if we should rewrite or refactor the code, make sure you ask yourself the question: "Is it currently in production?" if the answer is yes then you will most likely have a world of dependencies to the system and should most likely opt for refactoring the system while it stays in place.
* As developers and architects we make a lot of design decisions, maybe too many, we should ask us self if what we are about to make should be is a technical decision or a business decision / policy?
* It can take a lot of effort to get people understand and reason about bounded contexts.  
* Service boundaries are not context boundaries but they exist in different realms

## Things I will look deeper into

* A big part of the worked we did today was a based on Wardley maps, there are a lot of great resources I want to dig into:\
[Crossing the River by Feeling the Stones - Simon Wardley](https://www.youtube.com/watch?v=oZZKjxeg5W0)\
[A community around Wardsley mapping](https://community.wardleymaps.com/)\
[Simon Wardley free online book](https://community.wardleymaps.com/)

* The first part of value chain mapping or user needs [a example](https://community.wardleymaps.com/t/a-first-look-at-mapping-chat-messaging-apps/550)

* Good a simple way to describe Eric Evens concept of a bubble.

## Random impressions

A cool way to mix up existing workshop teams is to ask a team member to join the team standing to their left, and another team member to join the team on their right.\
Marijin minimized the workshop into 25 minutes [Pomodoro](https://en.wikipedia.org/wiki/Pomodoro_Technique) detailed sessions and he  would yell "respect the break" and give us a 3 minutes break to go to the bathroom or just relax. It worked wonderfully well, I have put a neat [Timer timer](https://www.timetimer.com/collections/timers) on my wish-list.\
A good way to get people to speak up doing presentation is to encourage them to use their bar voice regularly which Marijn did, thanks Marijn.
