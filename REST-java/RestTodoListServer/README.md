# REST Java Server

A simple TODO list with Spring Data REST (and an embedded H2 in memory database).

## Getting Started

This projet is an entity Todo and a CRUD Repository TodoListRepository with is automatically loaded as a RepositoryRestResource by the spring-boot-starter-data-rest.

It was initialized with https://start.spring.io

Go on http://localhost:8081/ to see the HAL discovery. GET, PUT, PATCH or DELETE on /todos or /todos/{id} to use REST API. 

## A complete test

With Insomnia web client, POST a json {"titre": "test", "description": "test"} on localhost:8081/todos and get a 201 Created response.

Next, GET on localhost:8081/todos/1 a 200 OK with the item in the response.

GET on localhost:8081/todos and see your item in the list.

Try to PUT a json {"titre": "test2", "description": "test2"} on localhost:8081/todos/1

Check localhost:8081/todos

PATCH with {"titre": "test3"} on localhost:8081/todos/1

See the title in localhost:8081/todos/1

## OpenAPI documentation

The OpenAPI UI page is then be available at http://localhost:8081/swagger-ui.html

The OpenAPI description will be available at the following url for json format: http://localhost:8081/v3/api-docs

## Reference Documentation

For further reference, please consider the following sections:

* [Official Apache Maven documentation](https://maven.apache.org/guides/index.html)
* [Spring Boot Maven Plugin Reference Guide](https://docs.spring.io/spring-boot/docs/2.7.4/maven-plugin/reference/html/)
* [Create an OCI image](https://docs.spring.io/spring-boot/docs/2.7.4/maven-plugin/reference/html/#build-image)
* [Rest Repositories](https://docs.spring.io/spring-boot/docs/2.7.4/reference/htmlsingle/#howto.data-access.exposing-spring-data-repositories-as-rest)

## Spring Guides

The following guides illustrate how to use some features concretely:

* [Accessing JPA Data with REST](https://spring.io/guides/gs/accessing-data-rest/)
* [Accessing Neo4j Data with REST](https://spring.io/guides/gs/accessing-neo4j-data-rest/)
