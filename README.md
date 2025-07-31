# MovieRental Exercise
 * In the MovieFeatures class, there is a method to list all movies, tell us your opinion about it.
	* In terms of scalability this method might have problems, imagining we get to query thousands of movies.
	* Paging and filtering should be added to this method as a lazy loading approach or a Skip/Take.
	* No DTO use, it is bad practice to return the entire entity back to the client.
	* Consider the use of memory cache, since movies will probablty not change very often.
 * No exceptions are being caught in this api, how would you deal with these exceptions?
	* You may use an exception middleware for global purposes
	* You should try catch inside the database context for insertion or timeout related errors (specific errors), and even log the error
 * I have added a launch profile to start both projects
