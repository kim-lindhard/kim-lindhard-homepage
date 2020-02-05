# DDD Europe 2020 day 1 workshop Strategic DDD using Bounded Context Canvas

## Introduction

I am attending the 2020 DDD Europe conference with hopes of talking with and learning from some leaders in the field of domain driven design. Day 1 and 2 will be a workshop run by Nick Tune on named [Strategic DDD using Bounded Context Canvas](https://medium.com/nick-tune-tech-strategy-blog/modelling-bounded-contexts-with-the-bounded-context-design-canvas-a-workshop-recipe-1f123e592ab). The workshop takes place right next to an EventStorming Master Class from Alberto Brandolini (the man who invented event storming). It will be interesting to see what Nick brings to the workshop that would not be covered by Alberto next door. I have watched a couple of recordings of talks Nick has given and felt he had an easy going, down to earth but also insightful approach to telling about his learnings. I can only say that he does not disappoint in person.

## General impression

There are a lot of very, very intelligent people working in our field. All organizations are on similar journeys: they are scaling their IT workforce, they want agility in delivery, they are doing micro services to some extent.

DFDS is ahead of the field in some areas:

* We have identified the concept of a capability which resolves the problem other organizations are facing with how they group micro services that have business driven reasons be developed together.
* Building event driven software and the level of decoupling coming with it is still a foreign idea to many.
* Our colleagues have a hard time differentiating between the concept of events, the concept of event sourcing, and technical offerings like Kafka or Rabbit mq.

Nick Tune and Kacper Gunia have a lot of knowledge and experience running these types of workshops. I feel there is something here to learn for the novice, journeyman and expert. The workshop has a lot of hands on elements and a tempo where where you can dive deep into topics but you never have time to get bored,  

## Learnings I gained

* Telling a story has many benefits when doing event storming:
  * You don't fall in the trap of abstracting too far away from thedomain you are attempting to model.
  * You get more data points where you can create alternative flows.
  * The modeling is easier to reason about, because you are simply telling a story.

* Modeling message flows is a good bridge between describing the problem space and creating the solution space. Modeling message flows feels like rapid prototyping, or as Nick described it, "breaking the model". You are very quickly uncovering if your model will work as a system.
* When creating an event going out of your context only put data into it from a single context. This is relevant in our desire to create fat events that caters to the consumer of the events.
* Be wary of generic words when naming contexts; they are a sign that you haven't digged deep enough. An example would be, "fleet management", the word management can cover a lot of things.

## Things I will look deeper into

The [Business Model Canvas](https://en.wikipedia.org/wiki/Business_Model_Canvas). 

The three Amigos; Business Analyst, Developer and Quality Analyst(tester).

A good way to explain context identification. Saying that it is a linguistic boundary is not enough.

## An idea I gave away today

We have been talking about orchestration versus choreography. Orchestration is a central unit keeping track of a process and sending commands to other units to accomplish the goal of the process. Choreography is individual units acting when they receive notifications of an event happening in other units.

What if you could get the decoupling of choreography and the process insight of the orchestration?
This can be achieved by building a system based on choreography, but letting the interested parties listen to events in the system and keep a local record of the progress of a process they themselves define.

An example could be a context that manages employees. The employee context is interested in the progress of events that happens in other contexts after an employee entity is created. An access card is created, an updated personal handbook is printed. a bouquet of flowers are ordered. The employee context can state that an onboarding is complete when all these events have happened. The context can also implement a policy for how long it will wait for these events. If the flowers haven't been ordered in time for the new employee's first work day, increase the size of the bouquet and add a sorry for the delay card, or inform a manager if no access card has been printed after 3 days.

## Random impressions

When I explain what the development excellence department does, people go "oh you are a platform team". I either need a new elevator speech or a new direction for our department.
The venue Meervaart is freaking cold.
Dutch people are tall.