Feature: Create New Appointment API
	create a new appointment using API on the Healthone connect app


@Ignore 
Scenario Outline: Create new Appointment API
	Given a user creates new appointment  "<ScenarioNumber>" using worksheet "0162DWLGUDPF3B77SI7FCKFFKPLK32ET7K" sheet "appointment"
	When a user updates the payload with required data from the worksheet using file "<Path>"
	And a user sends a post request to create new appointment usings "<URL>" and "<Path>" and "<MEMAPIKEY>"
	Then a successful message is returned 
Examples: 
| ScenarioNumber | URL                                                | Path                                     | MEMAPIKEY                        |
| 1              | https://testelive.medemass.com/api/v1/appointments | TestData\\HealthOneAPI\\Appointment.json | 15131460635136132230714773221870 |
| 2              | https://testelive.medemass.com/api/v1/appointments | TestData\\HealthOneAPI\\Appointment.json | 15131460635136132230714773221870 |
| 3              | https://testelive.medemass.com/api/v1/appointments | TestData\\HealthOneAPI\\Appointment.json | 15131460635136132230714773221870 |
