# Refactoring Test 
The test consists in refactoring the ProductService class, specifically the AddProduct method, with a particular focus on SOLID principles, asynchronous programming best practices, 
code readability/maintainability, minimizing cyclomatic complexity and optimizing performance.
As part of the test, the candidate is asked to implement at least 1 unit test (the happy path) for the AddProduct method in the ProductService class.

# Projects description
RefactoringTest.ProductService is a .NET core function app made of 1 HTTP Trigger that allows a client to add a product to the database.
RefactoringTest.LegacyClient emulates an external legacy application that is currently using the ProductService class from the RefactoringTest.ProductService project.

# Objectives
1. Refactor the ProductService class according to the brief
2. Add the happy path unit test for the AddProduct method (xunit or any other framework of choice)

# Constraints
The static class ProductRepository cannot be changed in any way.
The RefactoringTest.LegacyClient project cannot be changed in any way.
Available time: 2 hours.


