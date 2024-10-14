# Akka Component

## Akka (Core)
It contains the definition of an actor, the default object serialization mechanism, routing rules, Human-Optimized Config Object Notation (HOCON) configuration rules, the message dispatching mechanism, and much more. In order to use Akka.NET, we have to have a dependency on this library.

## Akka.TestKit
Akka.TestKit is a base library with building blocks that allow the effective testing of an actor system. Akka.TestKit defines the core libraries, and every unit-testing framework will implement the plumbing needed to translate the unit-testing engine’s specific needs.

## Akka.Remote
Akka.Remote brings the capability to build an ActorSystem across multiple processes over a computer network. Akka.NET supports communication between actors deployed remotely (living on different servers), with the great advantage that the programming model hides this complexity. Communication from the programming view is not different from the local versus remote, as the code would look exactly the same. Usually the Akka.Remote package is not used in isolation, but as a building block for the clustering capability.

Remoting enables the following functionalities:
- Referencing (individual) actors or actor systems on a remote host.
- Messaging between the two actor systems (local and remote). This involves managing low-level aspects of network (re)connections.

## Akka.Cluster
While Akka.Remoting solves the problem of addressing and communicating with components on remote systems, clustering gives the ability to organize a number of ActorSystems to behave as a **single unit**, which enables the scalability and high availability of the system itself.

Clustering provides additional services on top of remoting, such as:
- Handling the remote systems so that they can communicate with each other in a reliable way.
- Handling the change in the server’s setup: new cluster memberships, removal (failure) of servers, etc.
- Detecting disconnected systems that are temporarily unreachable.
- Distributing the computation between members (scaling out).

## Akka.Streams
Sometimes actors are not the most suitable tool when it comes to processing a stream (unlimited) of data. In this sense, Akka.Streams builds on top of actors and provides a higher level of abstraction.

Streams implement the following:
- Handling streams of events or large datasets, keeping the proper usage of performance and resources.
- Flexible pipelines in order to reuse functionalities.
- Enabling consumption of Reactive Streams compliant interfaces of other, third-type libraries.

## Akka.Persistence
Persistence provides a means to enable actors to persist their current state. There are several libraries that implement persisting data to various systems, such as Microsoft SQL Server, MySql, and Redis.

Persistence resolves the following:
- How to restore the state of an entity/actor when system restarts or crashes.
- Implementation of a system following a CQRS/Event Sourcing pattern.
- Reliable delivery of messages.