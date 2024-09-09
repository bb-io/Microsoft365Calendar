# Blackbird.io Microsoft 365 Calendar

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

Microsoft 365 Calendar app that allows you to access and manage your calendar events.

## Before setting up

Before you can connect you need to make sure that you have a Microsoft 365 account.

## Connecting

1. Navigate to apps and search for Microsoft 365 Calendar.
2. Click _Add Connection_.
3. Name your connection for future reference e.g. 'My organization'.
4. Click _Authorize connection_.
5. Follow the instructions that Microsoft gives you, authorizing Blackbird.io to act on your behalf.
6. When you return to Blackbird, confirm that the connection has appeared and the status is _Connected_.

![Connecting](image/README/connecting.png)

## Actions

- **List calendars** returns a list of current user's calendars.
- **Get calendar** retrieves a calendar. If calendar is not specified, default calendar is returned.
- **Create calendar**
- **Get users' schedule information** returns the free/busy availability information for a collection of users in specified time period.
- **Rename calendar** renames a calendar. If calendar is not specified, default calendar is renamed.
- **Delete calendar**
- **List events** retrieves a list of events in a calendar. If calendar is not specified, default calendar's events are listed.
- **Get event**
- **List occurrences of event** returns the occurrences of an event for a specified time range.
- **List recently created events** retrieves a list of events created during past hours. If number of hours is not specified, events created during past 24 hours are listed. If calendar is not specified, default calendar's events are listed.
- **List recently updated events** retrieves a list of events updated during past hours. If number of hours is not specified, events updated during past 24 hours are listed. If calendar is not specified, default calendar's events are listed.
- **Create event in a calendar** create a new event in a calendar. If calendar is not specified, the event is created in the default calendar. If the event is an online meeting, a Microsoft Teams meeting is automatically created. To create a recurring event specify recurrence pattern and interval which can be in days, weeks or months, depending on recurrence pattern type. If interval is not specified, it is set to 1. For weekly or monthly patterns provide days of week on which the event occurs.
- **Cancel event** sends a cancellation message and cancels the event. Can be performed only by organizer or a meeting.
- **Cancel event occurrence** sends a cancellation message and cancels an occurrence of a recurring meeting. Can be performed only by organizer or a meeting.
- **Forward event** forwards the meeting request to a new recipient
- **Update event**
- **Update event occurrence**
- **Delete event**

## Events

- **On event created** is triggered when a new event is created in specified calendar.

## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->
