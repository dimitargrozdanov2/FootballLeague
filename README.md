Business requirements:

	a. Create a system, which will be used to display the following:

		i. Teams ranking
		ii. Teams played matches

	b. The system should have the following functionality:

		i. CRUD operations for teams
		ii. CRUD operations for matches(only for played matches)
		iii. After the result is added, the table with the rankings and results in the customers portal should be updated accordingly
		iv. Should have following scoring: win – 3 points, draw – 1points and loss: 0 points

Technical requirements: 

	a. Create a web Application
	b. Use .Net Framework > 4
	c. Use MVC > 4
	d. All required entities should be saved in the DB. Connection to be:
		i. EF, LinqToSQL, ADO.NET …
	e. Create an exception handling mechanism
	f. Implement at least one design pattern, different than Singleton
	g. Try to follow S.O.L.I.D principles


This project could have been improved in the following ways:

1. Use Redis for ranking
2. Could have been created with Domain-Driven-Design
3. Automapper could be optimized using Reflection and Attributes
4. More Unit tests

Project uses design patterns and is a REST API with no front-end.
