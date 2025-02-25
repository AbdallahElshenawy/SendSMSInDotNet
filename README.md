# DotNet SMS Service

A .NET application to send SMS messages using Twilio and VictoryLink APIs.

## Overview
This project provides a simple API to send SMS messages, initially built with Twilio and later adapted for VictoryLink’s `SendToMany` API. It uses environment variables for secure credential management and supports sending SMS to multiple recipients.

## Features
- Send SMS to one or multiple recipients via VictoryLink’s `SendToMany` API.
- Configurable via environment variables.
- Built with ASP.NET Core, using `HttpClient` for API requests.

## Prerequisites
- .NET SDK (e.g., 6.0 or later)
- VictoryLink account credentials (`UserName`, `Password`, `SMSSender`)
- Twilio account (`AccountSID`, `AuthToken`, `TwilioPhoneNumber`)

