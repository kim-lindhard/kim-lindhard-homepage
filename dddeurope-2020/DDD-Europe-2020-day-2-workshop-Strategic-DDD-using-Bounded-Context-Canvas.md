# DDD Europe 2020 day 2 workshop Strategic DDD using Bounded Context Canvas

## What happened

On day 2 of the workshop [Strategic DDD using Bounded Context Canvas](https://medium.com/nick-tune-tech-strategy-blog/modelling-bounded-contexts-with-the-bounded-context-design-canvas-a-workshop-recipe-1f123e592ab) was engaging and there was an introduction into the activity of design level event storming where we go from the broad event  storming  we started the workshop yesterday, and went into more narrow scope where we focused on events surrounding a capability we previously had identified. We moved post-its with events, commands, view models, and policies around a big sheet of paper. As we were designing how our system would accomplish the task we set before it, there were a lot of moments where we learned that we had different ideas of what an event or view model represented. Which led to some great discussions creating a common understanding.
After our design level event storming exercise, we talked about model traits or traits given to context and how it interact with other contexts. You can see  Nick's different suggestion for traits in the things I learned section. The idea of the model traits is to piggyback on the gut feelings of experts in the DDD field, when you see certain things or pattern in your context model then classify them with these traits and decide if you feel your model have traits you like.

## Things I learned

Invariance only work within an aggregate, everything else must be a policy, because it is only in an aggregate we can guarantee that a check against the invariant has been made before data is persisted. Since we can't guarantee that the check has been done anywhere else, we can call our check against our rules a policy and state that we will do a compensating action  if things are not in our desired state.

Policies live in domain services. If a rule lives in our aggregate, then the check against the rule happened in the transactional scope of the aggregate and should be called an invariance since we will cancel the transaction if the check fails. If the check against our rule has to live outside of an aggregate,  then it can only live in the domain layer and in the the domain layer, i only have a home for it in the domain service concept.

When deciding between an invariance and policy ask yourself how long you can accept the state of your domain to be out of sync with the rule, if the answer is not for a second then you have an invariance, if you say; I can live with x amount of seconds, minutes, hours, then you have a policy.

There is a conflict of interest between what is best for the organization and what is best for the individual in all organizations. Keep this in mind where you are trying to implement things that will improve the organization.

Nick Tune has defined/found some common traits for domain models, you can find his cheat sheet below:
| Trait  | Heuristic |
| ------------- | ------------- |
| Specification Model  | Produces a document describing a job / request the needs to be preformed. *Example: Advertising Campaign Builder*  |
| Execution Model | Performs or tracks a job. *Example: Advertising Campaign Engine* |
| Audit Model  | Monitors the execution. *Example: Advertising Campaign Analyser* |
| Approver | Receives requests and determines if they should progress to the next step of the process. *Example: Fraud check* |
| Enforcer | Ensures that other contexts carry out certain operations. *Example: GDPR Context (ensures other contexts delete all of an user's data)* |
| Octopus Enforcer | Ensures that multiple/all contexts in the system all comply with a standard rule, *Example: GDPR context (as above)* |
| Interchanger | Translates between multiple ubiquitous languages |
| Gateway | Sits at the edge of a system and manages inbound and/or outbound communication. *Example IoT message gateway* |
| Gateway Interchange | The combination of a gateway and an interchange. |
| Dogfood Context | Simulates the customer experience of using the core bounded contexts. *Example: Whitelabel music store* |
| Bubble Context | Sits in-front of legacy contexts providing a new, cleaner model while legacy contexts are being replaced. |
| Autonomous Bubble | Bubble context which has its own data store and synchronizes data asynchronously with the legacy contexts |
| Brain Context (likely anti-pattern) | Contains a large number of important rules and many other contexts depends on it. *Example: rules  engine containing all the domain rules* |
| Funnel Context | Receives documents from multiple upstream contexts and passes them to a single downstream context in a standard format (after applying its own rules) |
| Engagement Context | Provides key features which attracts users to keep using the product. *Example: Free financial advice context* |
Nick also made a point of stating that some of these traits have been borrowed from others work and that this should be no mean be considered a complete list.

My own contribution to this list would be:

| Trait  | Heuristic |
| ------------- | ------------- |
| Controller Context | Controls a third party software guided by rules we define within the context and acting on notifications and commands coming from other contexts in our system  |

## Things I will look deeper into

[People that make computers go crazy - Gojko Adzic](https://www.youtube.com/watch?v=1Rna6NvIIDk)

[Domain Modeling Made Functional - Scott Wlaschin](https://www.youtube.com/watch?v=1pSH8kElmM4)

[The Infinite Game - Simon Sinek](https://www.youtube.com/watch?v=tye525dkfi8)

## Random impressions

I have been working with Terje Heen for 2 days and NAV is very lucky to have him as a Tech lead.