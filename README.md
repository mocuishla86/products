# products

If you get a "Your connection is not private", follow [these instructions](https://stackoverflow.com/a/44126123).

How did I configure functional tests: https://ilovedotnet.org/blogs/functional-testing-your-asp-net-webapi/

Architecture: Hexagonal.
- For this specifc example, perhaps a bit overkilling, but just to show that Iknow it . 
- One project for API (starts the application and wires dependencies)
- One project for domain (Project class)
- One project for application layer (use cases)
- One project for persistence (spefic adapter for output port). 

TODO: Include diagram. 
TODO: Validation?